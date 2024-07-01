
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Application.Services.AdoptionCentre
{
    public class AdoptionCentreService : IAdoptionCentreService
    {
        private readonly IAdoptionCentreRepository _adoptionCentreRepository;

        public AdoptionCentreService(IAdoptionCentreRepository adoptionCentreRepository)
        {
            _adoptionCentreRepository = adoptionCentreRepository;
        }
        public Domain.Model.AdoptionCentre Get()
        {
            var adoptionCentres = _adoptionCentreRepository.GetAll();
            if (adoptionCentres.Count > 0)
            {
                return adoptionCentres[0];
            }
            var adoptionCentre = new Domain.Model.AdoptionCentre();
            _adoptionCentreRepository.Add(adoptionCentre);
            return adoptionCentre;
        }

        Domain.Model.AdoptionCentre IAdoptionCentreService.Update(Domain.Model.AdoptionCentre adoptionCentre)
        {
            string id = Get().Id;
            return _adoptionCentreRepository.Update(id, adoptionCentre);
        }
    }
}
