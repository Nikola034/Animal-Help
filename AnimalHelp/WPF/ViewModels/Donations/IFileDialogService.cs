using System.Collections.Generic;

namespace AnimalHelp.WPF.ViewModels.Donations;

public interface IFileDialogService
{
    string? OpenFileDialog(string title, IEnumerable<string> extensions);
}