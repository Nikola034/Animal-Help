using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.Authentication;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Application.Utility.Validators;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string? _photoDescription;
        private string? _photoURL;

        private string? _errorDescriptionRequired;
        private string? _errorPhotos;
        private string? _errorAnimalRequired;

        public RelayCommand AddPostCommand { get; }
        public RelayCommand DeletePostCommand { get; }
        public RelayCommand UpdatePostCommand { get; }

        public RelayCommand AddPhotoCommand { get; }

        private readonly IPostService _postService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<Post> Posts { get; set; }

        public ObservableCollection<Animal> Animals { get; set; }

        public bool selectingPost;
        private Post? _selectedItem;
        public Post? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                selectingPost = true;
                if (_selectedItem != null)
                {
                    Domain.Model.Post? post = _postService.GetById(_selectedItem.Id);
                    if (post == null)
                        return;
                    Description = post.Description;
                    Photos = post.Photos;
                    Animal = post.Animal;
                }
                selectingPost = false;
                OnPropertyChanged();
            }
        }

        public NavigationStore NavigationStore { get; }

        public CreatePostViewModel(IPostService postService, INavigationService navigationService, NavigationStore navigationStore)
        {
            _postService = postService;
            _navigationService = navigationService;
            NavigationStore = navigationStore;

            Posts = new();
            Animals = new();

            LoadCollections();

            AddPostCommand = new RelayCommand(AddPost!);
            DeletePostCommand = new RelayCommand(DeletePost!);
            UpdatePostCommand = new RelayCommand(UpdatePost!);
            AddPhotoCommand = new RelayCommand(AddPhoto!);
        }

        private void LoadCollections()
        {
            LoadPosts();
            LoadAnimals();
        }
        private void LoadPosts()
        {
            Posts.Clear();
            List<Domain.Model.Post> posts;

            posts = _postService.GetAll();
            foreach (Domain.Model.Post post in posts)
                Posts.Add(post);
        }

        private void RefreshSelection() => SelectedItem = _selectedItem;


        private void LoadAnimals()
        {
            //Animals.Clear();
            //List<Domain.Model.Animal> animals;

            //animals = _animalService.GetAll();
            //foreach (Domain.Model.Animal animal in animals)
            //    Posts.Add(animal);
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

        public string? PhotoDescription
        {
            get => _photoDescription;
            set => SetField(ref _photoDescription, value);
        }

        public string? PhotoURL
        {
            get => _photoURL;
            set => SetField(ref _photoURL, value);
        }

        public Animal? Animal
        {
            get => _animal;
            set => SetField(ref _animal, value);
        }

        private void AddPost(object parameter)
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

        private void UpdatePost(object parameter)
        {
            ErrorDescriptionRequired = "";
            ErrorPhotos = "";
            ErrorAnimalRequired = "";

            string? description = Description;
            List<Photo>? photos = Photos;
            Animal? animal = Animal;

            if (Description == null || Animal == null)
            {
                return;
            }

            _postService.Add(new Post(Description, null, null, null));
        }

        private void DeletePost (object parameter)
        {
            ErrorDescriptionRequired = "";
            ErrorPhotos = "";
            ErrorAnimalRequired = "";

            string? description = Description;
            List<Photo>? photos = Photos;
            Animal? animal = Animal;

            if (Description == null || Animal == null)
            {
                return;
            }

            _postService.Add(new Post(Description, null, photos, animal));
        }

        private void AddPhoto(object parameter)
        {
            string? photoDescription = PhotoDescription;
            string? photoURL = PhotoURL;

            Photo photo = new Photo();
        }
    }
}
