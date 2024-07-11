using CarteAPI.Models;

namespace CarteAPI.Services.EquipeService
{
    public interface IEquipeService
    {
        Task<List<Equipe>> GetAllEquipes();
        Task<Equipe> GetSingleEquipe(int id);
        Task<Equipe> AddEquipe(Equipe equipe);
        Task<Equipe> UpdateEquipe(int id, Equipe equipe);
        Task<Equipe> DeleteEquipe(int id);
    }
}