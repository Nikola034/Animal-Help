using AnimalHelp.Application.Services;
using AnimalHelp.Application.Services.AdoptionServices;
using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.Users;
using AnimalHelp.Domain.RepositoryInterfaces;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Member;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;


namespace AnimalHelp.WPF.ViewModels.Volounteer
{
    public class VotingViewModel : ViewModelBase, INavigableDataContext 
    {
        private readonly IAuthenticationStore _authenticationStore;
        private readonly IVolunteeringApplicationService _volunteeringApplicationService;
        private readonly IVolunteeringApplicationRepository _volunteeringApplicationRepository;
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IAdoptionRequestService _adoptionRequestService;
        private readonly IAdoptionService _adoptionService;
        public ObservableCollection<VolunteeringApplication> VolunteeringApplications { get; set; }
        public ObservableCollection<AdoptionRequest> AdoptionRequests { get; set; }
        public ICommand AcceptAdoptionCommand { get; }
        public ICommand RejectAdoptionCommand { get; }
        public ICommand PositiveApplicationCommand { get; }
        public ICommand NegativeApplucationCommand { get; }


        public NavigationStore NavigationStore { get; }
        public VotingViewModel(IAuthenticationStore authenticationStore, NavigationStore navigationStore, 
            IVolunteeringApplicationRepository applicationRepository, 
            IVolunteeringApplicationService applicationService, 
            IVolunteerRepository volunteerRepository, IMemberRepository memberRepository, IAdoptionRequestService adoptionRequestService,
            IPostService postService, IAdoptionService adoptionService)
        {
            _authenticationStore = authenticationStore;
            NavigationStore = navigationStore;
            _volunteeringApplicationRepository = applicationRepository;
            _volunteeringApplicationService = applicationService;
            _volunteerRepository = volunteerRepository;
            _adoptionRequestService = adoptionRequestService;
            _adoptionService = adoptionService;

            VolunteeringApplications = new();
            LoadApplications();

            AdoptionRequests = new();
            LoadAdoptionRequests();

            NegativeApplucationCommand = new RelayCommand<string>(NegativeApplucation);
            PositiveApplicationCommand = new RelayCommand<string>(PositiveApplication);

            AcceptAdoptionCommand = new RelayCommand<string>(AcceptAdoption);
            RejectAdoptionCommand = new RelayCommand<string>(RejectAdoption);

        }

        private void RejectAdoption(string requestId)
        {
            // delete adoption request (maybe create a notification if needed)
            _adoptionRequestService.DeleteAdoptionRequest(requestId);
            LoadAdoptionRequests();
        }

        private void AcceptAdoption(string requestId)
        {
            _adoptionService.AcceptAdoptionRequest(_adoptionRequestService.GetById(requestId));
            _adoptionRequestService.DeleteAdoptionRequest(requestId);
            LoadAdoptionRequests();
            MessageBox.Show("Adoption request accepted!", "Success");
        }

        private void LoadAdoptionRequests()
        {
            AdoptionRequests.Clear();
            foreach (AdoptionRequest adoptionRequest in _adoptionRequestService.GetAll())
            {
                AdoptionRequests.Add(adoptionRequest);
            }
        }

        private void LoadApplications()
        {
            foreach(VolunteeringApplication application in _volunteeringApplicationRepository.GetPedingApplications())
            {
                VolunteeringApplications.Add(application);
            }

        }

        private void PositiveApplication(string applicationId)
        {
            Volunteer volunteer = _volunteerRepository.GetByEmail(_authenticationStore.CurrentUserProfile.Email);
            String volunteerId =volunteer.Id;
            bool success = _volunteeringApplicationService.VoteForVolunteeringApplication(volunteerId, applicationId, Vote.VoteVerdict.Positive);
            if (!success)
            {
                MessageBox.Show($"You already voted for this applicant!", "Fail");
                return;
            }

            MessageBox.Show($"Vote marked!", "Success");
            VolunteeringApplication application = _volunteeringApplicationRepository.Get(applicationId);
            if(application.State == VolunteeringApplication.ApplicationState.Accepted)
            {
                MessageBox.Show($"Member became a volunteer!", "Success");
                VolunteeringApplications.Remove(application);

            }


        }

        private void NegativeApplucation(string applicationId)
        {
            Volunteer volunteer = _volunteerRepository.GetByEmail(_authenticationStore.CurrentUserProfile.Email);
            String volunteerId = volunteer.Id;
            bool success = _volunteeringApplicationService.VoteForVolunteeringApplication(volunteerId, applicationId, Vote.VoteVerdict.Negative);
            if (!success)
            {
                MessageBox.Show($"You already voted for this applicant!", "Fail");
                return;
            }

            MessageBox.Show($"Vote marked!", "Success");
            VolunteeringApplication application = _volunteeringApplicationRepository.Get(applicationId);
            if (application.State == VolunteeringApplication.ApplicationState.Denied)
            {
                MessageBox.Show($"Member denied from becoming a volunteer.", "Success");
                VolunteeringApplications.Remove(application);
            }

        }

    }
}
