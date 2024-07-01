namespace AnimalHelp.Application.Services.AdoptionCentre
{
    public interface IAdoptionCentreService
    {
        public Domain.Model.AdoptionCentre Get();
        public Domain.Model.AdoptionCentre Update(Domain.Model.AdoptionCentre adoptionCentre);
    }
}
