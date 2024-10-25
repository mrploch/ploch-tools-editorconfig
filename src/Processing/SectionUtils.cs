using System.Text.RegularExpressions;

namespace Ploch.EditorConfigTools.Processing;

public static class SectionUtils
{
    private static readonly Regex FileExtensionsRegex = new(@"(?<pattern>.*)\.\{?((?<ext>[\w\+]+),?)*\}?", RegexOptions.Compiled);

    public static (string, IEnumerable<string>) ParseFileExtensions(string sectionName)
    {
        var matches = FileExtensionsRegex.Matches(sectionName);
        var extensions = new List<string>();

        var fileNamePattern = string.Empty;

        foreach (Match match in matches)
        {
            var patternCaptures = match.Groups["pattern"].Captures;

            fileNamePattern = patternCaptures.Count == 1 ? patternCaptures[0].Value : string.Empty;

            foreach (Capture matchGroupCapture in match.Groups["ext"].Captures)
            {
                extensions.Add(matchGroupCapture.Value);
            }
        }

        return (fileNamePattern, extensions);
    }

    public static string NormalizeSectionName(IEnumerable<string> fileExtensions)
    {
        var sortedExtensions = fileExtensions.Select(ext => ext.ToLower()).OrderBy(ext => ext);

        return string.Join(',', sortedExtensions);
    }
}