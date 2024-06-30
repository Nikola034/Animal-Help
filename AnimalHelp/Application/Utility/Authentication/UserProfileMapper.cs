using System;
using System.Collections.Generic;
using AnimalHelp.Application.DTO;
using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;
using UserType = AnimalHelp.Domain.Model.UserType;

namespace AnimalHelp.Application.Utility.Authentication;

public class UserProfileMapper : IUserProfileMapper, IObserver<PersonProfileMapping>
{
    private readonly Dictionary<string, PersonProfileMapping> _profileToUser;
    private readonly Dictionary<string, string> _memberToProfile = new();
    private readonly Dictionary<string, string> _volunteerToProfile = new();
    private readonly Dictionary<string, string> _adminToProfile = new();

    private readonly IProfileService _profileService;
    private readonly IVolunteerRepository _volunteerRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IAdminRepository _adminRepository;

    public UserProfileMapper(IPersonProfileMappingRepository personProfileMappingRepository, IProfileService profileService, IVolunteerRepository volunteerRepository, IMemberRepository memberRepository, IAdminRepository adminRepository)
    {
        _profileService = profileService;
        _memberRepository = memberRepository;
        _volunteerRepository = volunteerRepository;
        _adminRepository = adminRepository;
        
        _profileToUser = personProfileMappingRepository.GetMap();
        InitPersonToProfileMappings();
        personProfileMappingRepository.Subscribe(this);
    }

    private void InitPersonToProfileMappings()
    {
        foreach (var mapping in _profileToUser.Values)
        {
            var mapper = mapping.UserType switch
            {
                UserType.Member => _memberToProfile,
                UserType.Volunteer => _volunteerToProfile,
                UserType.Admin => _adminToProfile,
                _ => throw new ArgumentException("User type not supported.")
            };
            mapper.Add(mapping.UserId, mapping.Email);
        }
    }

    public UserDto GetPerson(Profile profile)
    {
        var mapping = _profileToUser[profile.Email];
        Person? person = mapping.UserType switch
        {
            UserType.Member => _memberRepository.Get(mapping.UserId),
            UserType.Volunteer => _volunteerRepository.Get(mapping.UserId),
            UserType.Admin => _adminRepository.Get(mapping.UserId),
            _ => null
        };
        return new UserDto(person, mapping.UserType);
    }

    public Profile? GetProfile(UserDto user)
    {
        if (user.Person == null) return null;

        var email = user.UserType switch
        {
            UserType.Member => _memberToProfile.ContainsKey(((Member)user.Person).Id)
                ? _memberToProfile[((Member)user.Person).Id]
                : null,
            UserType.Volunteer => _volunteerToProfile.ContainsKey(((Volunteer)user.Person).Id)
                ? _volunteerToProfile[((Volunteer)user.Person).Id]
                : null,
            UserType.Admin => _adminToProfile.ContainsKey(((Admin)user.Person).Id)
                ? _adminToProfile[((Admin)user.Person).Id]
                : null,
            _ => throw new ArgumentException("User type not supported.")
        };

        return email == null ? null : _profileService.GetProfile(email);

        return email == null ? null : _profileService.GetProfile(email);
    }

    public void OnCompleted()
    {
        _profileToUser.Clear();
        _memberToProfile.Clear();
        _volunteerToProfile.Clear();
        _adminToProfile.Clear();
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(PersonProfileMapping mapping)
    {
        _profileToUser.Add(mapping.Email, mapping);
        var mapper = mapping.UserType switch
        {
            UserType.Member => _memberToProfile,
            UserType.Volunteer => _volunteerToProfile,
            UserType.Admin => _adminToProfile,
            _ => throw new ArgumentException("User type not supported.")
        };
        mapper.Add(mapping.UserId, mapping.Email);
    }
}