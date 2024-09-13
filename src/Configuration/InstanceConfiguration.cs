using Fso.ScorchGore;
using ScorchGore.Constants;
using System.Diagnostics;
using System.Management;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace ScorchGore.Configuration;

internal class InstanceConfiguration
{
    private static readonly char[] signature = [(char)4, 'L', 'S', 'L', (char)3, 'J', 'M', 'L', (char)5, '$', 'c', 'g'];
    private static Guid? _instanceId;
    private static int _retries = 0;

    internal static bool IsRunningOnLocalWebserver
    {
        get
        {
#if DEBUG
            if (Debugger.IsAttached)
            {
               // return true;
            }
#endif
            return false;
        }
    }

    internal static string ApiUrl
    {
        get
        {
            if(IsRunningOnLocalWebserver)
            {
                return InfrastructureConstants.LocalApiUrl;
            }

            return InfrastructureConstants.RemoteApiUrl;
        }
    }

    internal static void Read()
    {
        Ensure();

        var fullPath = FullPath();
        using var instanceConfigFile = File.Open(fullPath, FileMode.Open, FileAccess.Read, FileShare.None);
        try
        {
            var instanceId = InstanceId();

            for (var i = 0; i < signature.Length; ++i)
            {
                if (signature[i] != (byte)instanceConfigFile.ReadByte())
                {
                    instanceConfigFile.Dispose();
                    Corrupted();

                    if (_retries == 1)
                    {
                        throw new Exception("Instance configuration corrupted, could not recover");
                    }

                    ++_retries;
                    Read();

                    return;
                }
            }

            var ivLen = ((byte)instanceConfigFile.ReadByte()) + 0xe;
            var iv = new byte[ivLen];

            for (var i = 0; i < ivLen; i++)
            {
                iv[i] = (byte)instanceConfigFile.ReadByte();
            }

            using var fileReader = new BinaryReader(instanceConfigFile);

            var cooked = new List<byte>();
            int nextValue;

            do
            {
                nextValue = instanceConfigFile.ReadByte();
                if (nextValue != -1)
                {
                    cooked.Add((byte)nextValue);
                }
            } while (nextValue != -1);

            instanceConfigFile.Dispose();
            var uncooked = Decrypt([.. cooked], instanceId, iv);

            InstanceSettings.DeserializeFrom(uncooked);
        }
        finally
        {
            instanceConfigFile.Dispose();
        }
    }

    internal static void Write()
    {
        var fullPath = FullPath();
        using var instanceConfigFile = File.Open(fullPath, FileMode.Open, FileAccess.Write, FileShare.None);

        foreach (var preambleCharacter in signature)
        {
            var rawByte = Encoding.ASCII.GetBytes([preambleCharacter]).First();

            instanceConfigFile.WriteByte(rawByte);
        }

        var instanceId = InstanceId();
        var rawValue = InstanceSettings.GetSerialized();
        (var cookedValue, var iv) = Encrypt(rawValue, instanceId);

        instanceConfigFile.WriteByte((byte)(iv.Length - 0xe));
        instanceConfigFile.Write(iv);
        instanceConfigFile.Write(cookedValue);
        instanceConfigFile.Flush();
        instanceConfigFile.Dispose();
    }

    public static string LocalSharedDataPath
    {
        get
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            return Path.Combine(
                appData,
                InfrastructureConstants.ManufacturerName,
                Assembly.GetExecutingAssembly()!.GetName().Name!
            );
        }
    }

    private static string LocalInstanceDataPath
    {
        get
        {
            return Path.Combine(
                LocalSharedDataPath,
                InstanceId().ToString("D")
            );
        }
    }

    private static string FullPath()
    {
        return Path.Combine(
            LocalInstanceDataPath,
            InfrastructureConstants.InstanceConfigFile
        );
    }

    private static void Ensure()
    {
        var fullPath = FullPath();

        if(!File.Exists(fullPath))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
            using var newFile = File.Create(fullPath, 1, FileOptions.RandomAccess);
            
            newFile.Dispose();
            InstanceSettings.InitializeFromEnvironment();
            Write();
        }
    }

    private static void Corrupted()
    {
        var fullPath = FullPath();

        File.Move(fullPath, Path.Combine(Path.GetDirectoryName(fullPath)!, Guid.NewGuid().ToString("D")));
        Ensure();
    }

    private static Guid InstanceId()
    {
        if(_instanceId != null)
        {
            return _instanceId.Value;
        }

        ManagementObjectSearcher mbs = new("SELECT * FROM Win32_processor");
        ManagementObjectCollection? mbsList = mbs.Get();
        string id = string.Empty;
        foreach (var mo in mbsList)
        {
            id = mo["ProcessorID"]?.ToString() ?? id;

            if (!string.IsNullOrWhiteSpace(id))
            {
                break;
            }
        }

        ManagementObjectSearcher mos = new("SELECT * FROM Win32_BaseBoard");
        var moc = mos.Get();
        string motherBoard = string.Empty;
        foreach (var mo in moc.Cast<ManagementObject>())
        {
            motherBoard = (string)mo["SerialNumber"];
        }

        _instanceId = new Guid(MD5.HashData(Encoding.ASCII.GetBytes($"{id}::#{Program.WhichInstanceAmI}@{motherBoard}")));

        return _instanceId.Value;
    }

    private static (byte[] result, byte[] iv) Encrypt(string clearText, Guid secret)
    {
        using var aes = Aes.Create();
        aes.Key = secret.ToByteArray();
        using MemoryStream output = new();
        using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(Encoding.ASCII.GetBytes(clearText));
        cryptoStream.FlushFinalBlock();

        return (output.ToArray(), aes.IV);
    }

    private static string Decrypt(byte[] encrypted, Guid secret, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = secret.ToByteArray();
        aes.IV = iv;
        using MemoryStream input = new(encrypted);
        using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using MemoryStream output = new();
        cryptoStream.CopyTo(output);

        return Encoding.ASCII.GetString(output.ToArray());
    }
}
