using CarteAPI.Models;

namespace CarteAPI.Services.LigneService
{
    public interface ILigneService
    {
        Task<List<Ligne>> GetAllLignes();
        Task<Ligne> GetSingleLigne(int id);
        Task<Ligne> AddLigne(Ligne ligne);
        Task<Ligne> UpdateLigne(int id, Ligne ligne);
        Task<Ligne> DeleteLigne(int id);
    }
}
