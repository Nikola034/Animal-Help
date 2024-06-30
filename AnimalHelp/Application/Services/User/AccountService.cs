using System;
using AnimalHelp.Application.Utility.Authentication;
using AnimalHelp.Domain.RepositoryInterfaces;
using AnimalHelp.Application.DTO;

using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.UseCases.User
{
    public class AccountService : IAccountService
    {
        private readonly IProfileService _profileService;
        private readonly IMemberService _memberService;
        private readonly IVolunteerService _volunteerService;
        private readonly IPersonProfileMappingRepository _personProfileMappingRepository;
        private readonly IUserProfileMapper _userProfileMapper;

        public AccountService(IProfileService profileService, IMemberService memberService, IVolunteerService volunteerService, IPersonProfileMappingRepository personProfileMappingRepository, IUserProfileMapper userProfileMapper)
        {
            _profileService = profileService;
            _memberService = memberService;
            _volunteerService = volunteerService;
            _personProfileMappingRepository = personProfileMappingRepository;
            _userProfileMapper = userProfileMapper;
        }

        public string GetEmailByUserId(string userId, UserType userType)
        {

            return _personProfileMappingRepository.GetEmailByUserId(userId);
        }

        public void UpdateMember(string userId, string password, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber)
        {
            Member member = _memberService.GetMemberById(userId)!;
            _memberService.UpdateMember(member, name, surname, birthDate, gender, phoneNumber);

            Profile profile = _userProfileMapper.GetProfile(new UserDto(member, UserType.Member))
                              ?? throw new InvalidOperationException("No profile associated with member.");
            _profileService.UpdatePassword(profile, password);
        }



        public void RegisterMember(RegisterMemberDto registerDto)
        {
            var profile = _profileService.AddProfile(new Profile(
                registerDto.Email,
                registerDto.Password
            ));
            var member = _memberService.AddMember(new Member(
                registerDto.Name,
                registerDto.Surname,
                registerDto.BirthDay,
                registerDto.Gender,
                registerDto.PhoneNumber,
                false, 
                true
            ));
            _personProfileMappingRepository.Add(new PersonProfileMapping(
                profile.Email,
                UserType.Member,
                member.Id
            ));
        }

        public Volunteer RegisterVolunteer(RegisterVolunteerDto registerDto)
        {
            var profile = _profileService.AddProfile(new Profile(
                registerDto.Email,
                registerDto.Password
            ));
            var volunteer = _volunteerService.AddVolunteer(new Volunteer(
                registerDto.Name,
                registerDto.Surname,
                registerDto.BirthDay,
                registerDto.Gender,
                registerDto.PhoneNumber
            ));
            _personProfileMappingRepository.Add(new PersonProfileMapping(
                profile.Email,
                UserType.Volunteer,
                volunteer.Id
            ));
            return volunteer;
        }
        public Volunteer UpdateVolunteer(string volunteerId, string password, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber, DateTime dateJoined)
        {
            Volunteer volunteer = _volunteerService.GetVolunteerById(volunteerId)!;
            _volunteerService.UpdateVolunteer(volunteer, name, surname, birthDate, gender, phoneNumber, dateJoined);

            Profile profile = _userProfileMapper.GetProfile(new UserDto(volunteer, UserType.Volunteer))
                              ?? throw new InvalidOperationException("No profile associated with volunteer.");
            _profileService.UpdatePassword(profile, password);
            return volunteer;
        }

        public void DeleteMember(Member member)
        {
            _memberService.DeleteAccount(member);
            var profile = _userProfileMapper.GetProfile(new UserDto(member, UserType.Member));
            if (profile != null)
            {
                _profileService.DeleteProfile(profile.Email);
                _personProfileMappingRepository.Delete(profile.Email);
            }
        }
    }
}
