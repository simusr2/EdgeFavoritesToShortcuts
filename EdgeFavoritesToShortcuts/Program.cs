using EdgeFavoritesToShortcuts.Core.Models;
using System.CommandLine;

Option<string> outputFolderArgument = new Option<string>
    (name: "--output-folder",
     description: "Bookmarks destination folder.",
     getDefaultValue: () => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Bookmarks"));

Option<string> userArgument = new Option<string>
    (name: "--user",
     description: "Name of the user to use to extract bookmarks.",
     getDefaultValue: () => Environment.UserName);

Option<bool> deleteArgument = new Option<bool>
    (name: "--delete",
     description: "Delete after extraction.",
     getDefaultValue: () => false);

RootCommand rootCommand = new RootCommand
{
    userArgument,
    outputFolderArgument,
    deleteArgument
};

rootCommand.SetHandler((userArgument, outputFolderArgument, deleteArgument) =>
{
    EdgeFavorites favorites = EdgeFavorites.FromUserFile(userArgument);
    favorites.SaveShortcuts(outputFolderArgument);
    if (deleteArgument)
    {
        EdgeFavorites.DeleteFile(userArgument);
    }
}, userArgument, outputFolderArgument, deleteArgument);

await rootCommand.InvokeAsync(args);
