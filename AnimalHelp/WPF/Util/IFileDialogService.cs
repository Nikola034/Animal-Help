using System.Collections.Generic;

namespace AnimalHelp.WPF.Util;

public interface IFileDialogService
{
    string? OpenFileDialog(string title, IEnumerable<string> extensions);
}