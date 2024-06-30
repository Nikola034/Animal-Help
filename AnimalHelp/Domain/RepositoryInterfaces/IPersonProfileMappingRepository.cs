using System;
using System.Collections.Generic;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Domain.RepositoryInterfaces;

public interface IPersonProfileMappingRepository : IRepository<PersonProfileMapping>, IObservable<PersonProfileMapping>
{
    public Dictionary<string, PersonProfileMapping> GetMap();
    public string GetEmailByUserId(string userId);
}