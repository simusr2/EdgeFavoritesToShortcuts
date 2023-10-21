using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EdgeFavoritesToShorcuts.Core.Utils
{
    static class Util
    {
        public static string MakeValidFileName(string name)
        {
            name = string.Join(" ", new Regex("[ -~]+").Matches(name).Select(m => m.Value));
            //+ new string(Path.GetInvalidPathChars()
            name = new Regex(string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidFileNameChars())))).Replace(name, "_");

            return name;
        }
    }
}
