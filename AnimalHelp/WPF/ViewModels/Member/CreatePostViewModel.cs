using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.Authentication;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Application.Utility.Validators;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ValidationError = AnimalHelp.Domain.Model.ValidationError;

namespace AnimalHelp.WPF.ViewModels.Member
{
    public class CreatePostViewModel : ViewModelBase, INavigableDataContext
    {
        private string? _description;
        private List<Photo> _photos;
        private Animal _animal;

        private string? _errorDescriptionRequired;
        private string? _errorPhotos;
        private string? _errorAnimalRequired;

        public ICommand CreatePostCommand { get; }

        private readonly IPostService _postService;
        private readonly INavigationService _navigationService;


        public NavigationStore NavigationStore { get; }

        public CreatePostViewModel(IPostService postService, INavigationService navigationService, NavigationStore navigationStore)
        {
            _postService = postService;
            _navigationService = navigationService;
            NavigationStore = navigationStore;
            CreatePostCommand = new RelayCommand(CreatePost!);
        }

        public string? ErrorDescriptionRequired
        {
            get => _errorDescriptionRequired;
            set => SetField(ref _errorDescriptionRequired, value);
        }

        public string? ErrorPhotos
        {
            get => _errorPhotos;
            set => SetField(ref _errorPhotos, value);
        }

        public string? ErrorAnimalRequired
        {
            get => _errorAnimalRequired;
            set => SetField(ref _errorAnimalRequired, value);
        }

        public string? Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }

        public List<Photo>? Photos
        {
            get => _photos;
            set => SetField(ref _photos, value);
        }

        public Animal? Animal
        {
            get => _animal;
            set => SetField(ref _animal, value);
        }

        private void CreatePost(object parameter)
        {
            ErrorDescriptionRequired = "";
            ErrorPhotos = "";
            ErrorAnimalRequired = "";

            string? description = Description;
            List<Photo>? photos = Photos;
            Animal? animal = Animal;

            if(Description == null || Animal == null)
            {
                return;
            }    

            _postService.Add(new Post(Description, null, photos, animal));
        }
    }
}
