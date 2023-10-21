using EdgeFavoritesToShorcuts.Core.Bookmarks;
using EdgeFavoritesToShorcuts.Core.Utils;
using EdgeFavoritesToShortcuts.Core.Enums.Favorite;
using IWshRuntimeLibrary;
using System.Text.Json;
using File = System.IO.File;

namespace EdgeFavoritesToShortcuts.Core.Models;

public partial class EdgeFavorites
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    private static string GetPath(string user)
    {
        return $"C:\\Users\\{user}\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Bookmarks";
    }
    public static void DeleteFile(string user)
    {
        string path = GetPath(user);
        File.Move(path, $"{path}.{DateTime.Now.ToLocalTime():yyyyMMddHHmmss}.bak");
    }

    public static EdgeFavorites? FromFile(string path)
    {
        try
        {
            EdgeFavorites? favorites = JsonSerializer.Deserialize<EdgeFavorites>(File.ReadAllBytes(path), _jsonSerializerOptions);

            return favorites;
        }
        catch (Exception ex)
        {
            throw new Exception("Cannot parse input file", ex);
        }
    }

    public static EdgeFavorites? FromUserFile(string user)
    {
        return FromFile(GetPath(user));
    }

    public void SaveShortcuts(string output)
    {
        Directory.CreateDirectory(output);

        if (Roots != null)
        {
            ProcessFolder(nameof(Roots.BookmarkBar), Roots.BookmarkBar, output);
            ProcessFolder(nameof(Roots.Synced), Roots.Synced, output);
            ProcessFolder(nameof(Roots.Other), Roots.Other, output);
        }
    }

    private static void ProcessFolder(string rootName, Favorite? folder, string destination)
    {
        if (folder == null)
        {
            return;
        }

        destination = Path.Combine(destination, Util.MakeValidFileName(folder.Name ?? ""));
        Directory.CreateDirectory(destination);

        foreach (Favorite favorite in folder.Children)
        {
            switch (favorite.Type)
            {
                case FavoriteType.Folder:
                    ProcessFolder(rootName, favorite, Path.Combine(destination));
                    break;
                case FavoriteType.Url:
                    ProcessUrl(rootName, favorite, destination);
                    break;
            };
        }
    }

    private static List<ExtractionError> ProcessUrl(string rootName, Favorite favorite, string destination)
    {
        List<ExtractionError> errors = new List<ExtractionError>();

        if (string.IsNullOrEmpty(favorite.Name))
        {
            errors.Add(new ExtractionError(rootName, favorite, new InvalidOperationException("Bookmark name cannot be null")));
        }
        else
        {
            string fileName = Util.MakeValidFileName(favorite.Name);
            destination = Path.Combine(destination, fileName);

            if (destination.Length > 252)
            {
                destination = destination[..252];
            }

            string url = favorite.Url ?? "";
            try
            {
                DK.WshRuntime.WshInterop.CreateShortcut(destination + ".lnk", "", url, "", "");
            }
            catch (Exception ex)
            {
                errors.Add(new ExtractionError(rootName, favorite, ex));
            }
        }
        return errors;
    }

}
