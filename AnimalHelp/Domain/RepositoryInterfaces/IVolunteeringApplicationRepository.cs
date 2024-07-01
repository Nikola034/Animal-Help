using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.Users.Volunteer;
using System.Collections.Generic;

namespace AnimalHelp.Domain.RepositoryInterfaces;

public interface IVolunteeringApplicationRepository : IRepository<VolunteeringApplication>
{
    public VolunteeringApplication GetApplicationForMember(string memberId);
    public List<VolunteeringApplication> GetPedingApplications();
    public VolunteeringApplication Get(Member member);

}