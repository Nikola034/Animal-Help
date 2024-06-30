using System;
using AnimalHelp.Domain.RepositoryInterfaces;
using AnimalHelp.Application.DTO;
using AnimalHelp.Domain.Model;


namespace AnimalHelp.Application.UseCases.User
{
    public class AccountService : IAccountService
    {
        private readonly IMemberService _memberService;
        private readonly IVolunteerService _volunteerService;
        private readonly IMemberRepository _memberRepository;
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IAdminRepository _adminRepository;

        public AccountService(IMemberService memberService, IVolunteerService volunteerService, IAdminRepository adminRepository, IMemberRepository memberRepository, IVolunteerRepository volunteerRepository)
        {
            _memberService = memberService;
            _volunteerService = volunteerService;
            _adminRepository = adminRepository;
            _memberRepository = memberRepository;
            _volunteerRepository = volunteerRepository;
        }

        public bool IsEmailTaken(string email)
        {
            bool found = _memberRepository.GetByEmail(email) != null;
            found = _volunteerRepository.GetByEmail(email) != null;
            found = _adminRepository.GetByEmail(email) != null;
            return found;
        }

        public UserDto GetPerson(Profile profile)
        {
            if(profile.UserType == UserType.Member)
            {
                return new UserDto(_memberRepository.GetByEmail(profile.Email), UserType.Member);
            }else if(profile.UserType == UserType.Volunteer)
            {
                return new UserDto(_volunteerRepository.GetByEmail(profile.Email), UserType.Volunteer);
            }
            else
            {
                return new UserDto(_adminRepository.GetByEmail(profile.Email), UserType.Admin);
            }
        }

        public UserDto GetPerson(string email)
        {
            Volunteer volunteer = _volunteerRepository.GetByEmail(email);
            if(volunteer != null)
            {
                return new UserDto(volunteer, UserType.Volunteer);
            }
            Member member = _memberRepository.GetByEmail(email);
            if (member != null)
            {
                return new UserDto(member, UserType.Member);
            }
            Admin admin = _adminRepository.GetByEmail(email);
            if (admin != null)
            {
                return new UserDto(admin, UserType.Admin);
            }
            return new UserDto((Admin)null, null);
        }

        public string GetEmailByUserId(string userId, UserType userType)
        {
            if(userType == UserType.Admin)
            {
                return _adminRepository.Get(userId).Profile.Email;
            }else if(userType == UserType.Member) {
                return _memberRepository.Get(userId).Profile.Email;
            }
            return _volunteerRepository.Get(userId).Profile.Email;
        }

        public void UpdateMember(string userId, string password, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber)
        {
            Member member = _memberService.GetMemberById(userId)!;
            member.ChangePassword(password);
            _memberService.UpdateMember(member, name, surname, birthDate, gender, phoneNumber);
        }

        public void RegisterMember(RegisterMemberDto registerDto)
        {
            Member member = new Member(
                registerDto.Name,
                registerDto.Surname,
                registerDto.BirthDay,
                registerDto.Gender,
                registerDto.PhoneNumber
            );
            member.AddProfile(registerDto.Email, registerDto.Password, UserType.Member);
            _memberService.AddMember(member);
        }

        public Volunteer RegisterVolunteer(RegisterVolunteerDto registerDto)
        {
            Volunteer volunteer = new Volunteer(
                registerDto.Name,
                registerDto.Surname,
                registerDto.BirthDay,
                registerDto.Gender,
                registerDto.PhoneNumber
            );
            volunteer.AddProfile(registerDto.Email, registerDto.Password, UserType.Volunteer);
            _volunteerService.AddVolunteer(volunteer);
           
            return volunteer;
        }
        public Volunteer UpdateVolunteer(string volunteerId, string password, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber, DateTime dateJoined)
        {
            Volunteer volunteer = _volunteerService.GetVolunteerById(volunteerId)!;
            volunteer.ChangePassword(password);
            _volunteerService.UpdateVolunteer(volunteer, name, surname, birthDate, gender, phoneNumber, dateJoined);

            return volunteer;
        }

        public void DeleteMember(Member member)
        {
            _memberService.DeleteAccount(member);
        }
    }
}
