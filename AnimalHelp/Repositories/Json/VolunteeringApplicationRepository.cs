using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.Users;
using AnimalHelp.Domain.RepositoryInterfaces;
using System.Collections.Generic;

namespace AnimalHelp.Repositories.Json;

public class VolunteeringApplicationRepository : AutoIdRepository<VolunteeringApplication>, IVolunteeringApplicationRepository
{
    public VolunteeringApplicationRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
    {
    }

    public VolunteeringApplication GetApplicationForMember(string memberId)
    {
        var applications = Load();
        foreach(var application in applications.Values)
        {   
            if(application.Applicant.Id == memberId)
            {
                return application;
            }

        }
        return null;
    }

    public List<VolunteeringApplication> GetPedingApplications()
    {
        var applications = Load();
        List<VolunteeringApplication> result = new();

        foreach (var application in applications.Values)
        {
            if (application.State == VolunteeringApplication.ApplicationState.Pending)
            {
                result.Add(application);
            }

        }
        return result;
    }



    public VolunteeringApplication Get(Member member)
    {
        var applications = Load();
        foreach (var application in applications.Values)
        {
            if (application.Applicant == member)
            {
                return application;
            }

        }
        return null;

    }

}