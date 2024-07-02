using System.Collections.Generic;
using System.Linq;
using AnimalHelp.WPF.ViewModels.Donations;
using Microsoft.Win32;

namespace AnimalHelp.WPF.Util;

public class FileDialogService : IFileDialogService
{
    public string? OpenFileDialog(string title, IEnumerable<string> extensions)
    {
        var openFileDialog = new OpenFileDialog
        {
            Title = title,
            Filter = CreateFilter(extensions),
            CheckFileExists = true,
            CheckPathExists = true,
            Multiselect = false
        };

        var result = openFileDialog.ShowDialog();

        return result == true ? openFileDialog.FileName : null;
    }

    private string CreateFilter(IEnumerable<string> extensions)
    {
        var filter = extensions.Select(ext => $"{ext.ToUpper()} Files (*.{ext})|*.{ext}");
        return string.Join("|", filter);
    }
}