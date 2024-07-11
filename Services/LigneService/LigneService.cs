using CarteAPI.Data;
using CarteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarteAPI.Services.LigneService
{
    public class LigneService : ILigneService
    {
        private readonly DataContext _context;

        public LigneService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Ligne>> GetAllLignes()
        {
            return await _context.Lignes.ToListAsync();
        }

        public async Task<Ligne> GetSingleLigne(int id)
        {
            return await _context.Lignes.FindAsync(id);
        }

        public async Task<Ligne> AddLigne(Ligne ligne)
        {
            _context.Lignes.Add(ligne);
            await _context.SaveChangesAsync();
            return ligne;
        }

        public async Task<Ligne> UpdateLigne(int id, Ligne ligne)
        {
            var existingLigne = await _context.Lignes.FindAsync(id);
            if (existingLigne == null)
            {
                return null;
            }

            existingLigne.Numero = ligne.Numero; 
            await _context.SaveChangesAsync();
            return existingLigne;
        }

        public async Task<Ligne> DeleteLigne(int id)
        {
            var ligne = await _context.Lignes.FindAsync(id);
            if (ligne == null)
            {
                return null;
            }

            _context.Lignes.Remove(ligne);
            await _context.SaveChangesAsync();
            return ligne;
        }
    }
}
