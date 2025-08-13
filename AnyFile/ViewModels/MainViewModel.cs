using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace AnyFile.ViewModels
{
    public enum ViewMode
    {
        [Display(Name = "œÍœ∏")]
        Detail,

        [Display(Name = "Àı¬‘Õº")]
        Thumbnail
    }

    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            LoadFiles();
        }

        [ObservableProperty]
        private ViewMode currentViewMode = ViewMode.Thumbnail;

        [ObservableProperty]
        private string currentPath = Directory.GetCurrentDirectory();

        [ObservableProperty]
        private ObservableCollection<FileInfo>? fileItems;

        [RelayCommand]
        private void Enter(string path)
        {
            CurrentPath = path;
            LoadFiles();
        }

        partial void OnCurrentPathChanged(string value)
        {
            LoadFiles();
        }

        private void LoadFiles()
        {
            DirectoryInfo dir = new(CurrentPath);
            FileItems = new(dir.GetFiles());
        }
    }
}
