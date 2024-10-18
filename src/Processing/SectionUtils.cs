using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ploch.EditorConfigTools.Processing
{
    public static class SectionUtils
    {
        private static readonly Regex FileExtensionsRegex = new(@"\*\.\{?((?<ext>[\w\+]+),?)*\}?", RegexOptions.Compiled);

        public static IEnumerable<string> ParseFileExtensions(string sectionName)
        {
            var matches = FileExtensionsRegex.Matches(sectionName);
            var extensions = new List<string>();
            foreach (Match match in matches)
            {
                foreach (Capture matchGroupCapture in match.Groups["ext"].Captures)
                {
                    extensions.Add(matchGroupCapture.Value);
                }
            }

            return extensions;
        }

        public static string NormalizeSectionName(IEnumerable<string> fileExtensions)
        {
            var sortedExtensions = fileExtensions.Select(ext => ext.ToLower()).OrderBy(ext => ext);

            return string.Join(',', sortedExtensions);
        }
    }
}