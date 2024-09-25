using WebAtrioEmployeManagement.DTOS;

namespace WebAtrioEmployeManagement.Services
{
    public interface IPersonneService
    {
        Task<IEnumerable<PersonneDTO>> GetAllPersonnesAsync();
        Task<PersonneDTO> CreatePersonneAsync(PersonneDTO personneDto);
        Task<EmploiDTO> AddEmploiAsync(int personneId, EmploiDTO emploiDto);
        Task<IEnumerable<PersonneDTO>> GetPersonnesParEntrepriseAsync(string nomEntreprise);
        Task<IEnumerable<EmploiDTO>> GetEmploisParDatesAsync(int personneId, DateTime dateDebut, DateTime dateFin);
    }
}
