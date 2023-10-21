using EdgeFavoritesToShortcuts.Core.Models;

namespace EdgeFavoritesToShorcuts.Core.Bookmarks;

/// <summary>
/// Struct representing Extraction error
/// </summary>
/// <param name="rootName">Current roots's name</param>
/// <param name="favorite">Current favorite</param>
/// <param name="exception">Exception occurred</param>
public struct ExtractionError
{
    public string RootName;
    public Favorite Favorite;
    public Exception Exception;

    public ExtractionError(string rootName, Favorite favorite, Exception exception)
    {
        RootName = rootName;
        Favorite = favorite;
        Exception = exception;
    }
}
