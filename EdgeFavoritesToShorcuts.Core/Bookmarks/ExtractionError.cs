using EdgeFavoritesToShortcuts.Core.Models;
using System;

namespace EdgeFavoritesToShorcuts.Core.Bookmarks
{
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
}
