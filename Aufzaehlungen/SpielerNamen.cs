using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ScorchGore
{
    public class SpielerNamen
    {
        private static readonly string roheNamensPaare = @"TGF1cmVsSGFyZHlNaW5nZUJyYWNrZXRTaGVybG9ja1dhdHNvblBoaW5lYXNGZXJiRmlubkpha2VMdWthc0pvbmFzTm9vYlNvb3NKw7xyZ2VuUsO8ZGlnZXJEw7ZydGVFYmVyaGFyZENhc2VUYXJzTWFjQ2hlZXNlQWxpY2VCb2JCYXRtYW5Sb2Jpbk1hcmxpbkRvcnlLZWx2aW5DZWxzaXVzVGVzbGFFZGlzb25GYXN0RnVyaW91c1JvbWVvSnVsaWV0SG9tZXJVbHlzc2VzRG9uYWxkRGFpc3lTY3VsZGVyTW9sbHlNaWNrUm9ydHlEb2N0b3JBbXlGZWV0TWV0ZXJBbm5hRWxzYVNjcml0Y2h5QXRjaHlUaGVsbWFMb3Vpc2VTdGFuS3lsZUxpbmtSYXZpb2xpU2FrdXJhU2FzdWtlQ3ludGhpYUhlbnJ5SGVybWVzU2FsbWFjaXNNYXJpZVBpZXJyZVBldGVyUGF1bEJvamFja0Nhcm9seW5WZW51c1NlcmVuYU9ydmlsbGVXaWxidXJBZG9sZkpvc2VmTmljb2xhZUVsZW5hRWxpc2FNYWRlbGVpbmVEYXZpZEdvbGlhdGhDYWluQWJlbEV2ZUFkYW1Mb3RFZGl0aE1laVNhdHN1a2lTb3BoaWVIYWt1QmFydExpc2FZaW5ZYW5nRmVuZ1NodWlIdW5kS2F0emVSb3NlSmFja0NhdGh5SGVhdGhjbGlmZlNhbGx5QW5naWVFbGVwaGFudENhc3RsZQ==";

        protected static string[] namensPaare = AlsFeldvariable(
            Encoding.UTF8.GetString(Convert.FromBase64String(roheNamensPaare))
        );

        protected static int AnzahlNamenspaare => namensPaare.Length / 2;

        public static Tuple<string, string> ZufallsNamenspaar => NamensPaar(
            new Random().Next(AnzahlNamenspaare)
        );

        private static Tuple<string, string> NamensPaar(int namensIndex) => new Tuple<string, string>(
            namensPaare[namensIndex * 2],
            namensPaare[namensIndex * 2 + 1]
        );

        private static string[] AlsFeldvariable(string rohString) => Regex.Split(rohString, @"(?<!^)(?=[A-Z])");
    }
}