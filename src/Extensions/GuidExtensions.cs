namespace ScorchGore.Extensions;

internal static class GuidExtensions
{
    internal static string ToGore(this Guid guid)
    {
        return guid.ToString("N").ToUpperInvariant();
    }

    internal static bool TryParseGore(string s, out Guid token)
    {
        return Guid.TryParseExact(s, "N", out token);
    }
}
