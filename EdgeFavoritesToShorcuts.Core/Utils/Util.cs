using System.Text.RegularExpressions;

namespace EdgeFavoritesToShorcuts.Core.Utils;

/// <summary>
/// Generic utilities
/// </summary>
static partial class Util
{
    /// <summary>
    /// Replace invalid chars with '_' from filename
    /// </summary>
    /// <param name="name">Filename</param>
    /// <returns>Valid filename</returns>
    public static string MakeValidFileName(string name)
    {
        string escapedName = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
        name = new Regex(string.Format("[{0}]", escapedName)).Replace(name, "_");
        return name;
    }
}
