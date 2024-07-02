using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;

namespace AnimalHelp.Application.Services.AdoptionServices;

public class AdoptionService : IAdoptionService
{
    private readonly IAdoptionRepository _adoptionRepository;
    public AdoptionService(IAdoptionRepository adoptionRepository)
    {
        _adoptionRepository = adoptionRepository;
    }

    public Adoption AcceptAdoptionRequest(AdoptionRequest request)
    {
        var adoption = new Adoption(request.Type, true, request.PostId, request.UserEmail);
        return _adoptionRepository.Add(adoption);
    }

    public Adoption AddAdoption(AdoptionType type, bool isActive, Domain.Model.Post post, string userId)
    {
        if (userId == "")
        {
            throw new ArgumentException("User id required for donation");
        }
        return _adoptionRepository.Add(new Adoption(type, isActive, post.Id, userId));
    }

    public void DeactivateAdoption(string id)
    {
        var adoption = _adoptionRepository.Get(id);
        if (adoption == null)
        {
            throw new ArgumentException("Invalid id provided, there is no adoption with given id");
        }
        adoption.IsActive = false;
        _adoptionRepository.Update(adoption.Id, adoption);
    }

    public void DeleteAdoption(string id)
    {
        if (id == "")
        {
            throw new ArgumentException("Adoption id not provided!");
        }
        _adoptionRepository.Delete(id);

    }

    public List<Adoption> GetActive()
    {
        return _adoptionRepository.GetActive();
    }

    public List<Adoption> GetAll()
    {
        return _adoptionRepository.GetAll();
    }

    public Adoption GetById(string id)
    {
        return _adoptionRepository.Get(id);
    }

    public List<Adoption> GetByPostId(string id)
    {
        return _adoptionRepository.GetByPostId(id);
    }

    public List<Adoption> GetByType(AdoptionType type)
    {
        return _adoptionRepository.GetByType(type);
    }

    public List<Adoption> GetByUserEmail(string email)
    {
        return _adoptionRepository.GetByUserEmail(email);
    }

    public void RateAnimal(string id, int rating)
    {
        var adoption = _adoptionRepository.Get(id);
        if (adoption == null)
        {
            throw new ArgumentException("Invalid id provided, there is no adoption with given id");
        }
        adoption.RateAnimal(rating);
        _adoptionRepository.Update(adoption.Id, adoption);
    }

    public void RateMember(string id, int rating)
    {
        var adoption = _adoptionRepository.Get(id);
        if (adoption == null)
        {
            throw new ArgumentException("Invalid id provided, there is no adoption with given id");
        }
        adoption.RateMember(rating);
        _adoptionRepository.Update(adoption.Id, adoption);
    }

    public Adoption UpdateAdoption(Adoption adoption)
    {
        return _adoptionRepository.Update(adoption.Id, adoption);
    }
}
