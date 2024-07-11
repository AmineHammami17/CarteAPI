using CarteAPI.Data;
using CarteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarteAPI.Services.EquipeService
{
    public class EquipeService : IEquipeService
    {
        private readonly DataContext _context;

        public EquipeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Equipe>> GetAllEquipes()
        {
            return await _context.Equipes.ToListAsync();
        }

        public async Task<Equipe> GetSingleEquipe(int id)
        {
            return await _context.Equipes.FindAsync(id);
        }

        public async Task<Equipe> AddEquipe(Equipe equipe)
        {
            _context.Equipes.Add(equipe);
            await _context.SaveChangesAsync();
            return equipe;
        }

        public async Task<Equipe> UpdateEquipe(int id, Equipe equipe)
        {
            var existingEquipe = await _context.Equipes.FindAsync(id);
            if (existingEquipe == null)
            {
                return null;
            }

            existingEquipe.Numero = equipe.Numero; 
            await _context.SaveChangesAsync();
            return existingEquipe;
        }

        public async Task<Equipe> DeleteEquipe(int id)
        {
            var equipe = await _context.Equipes.FindAsync(id);
            if (equipe == null)
            {
                return null;
            }

            _context.Equipes.Remove(equipe);
            await _context.SaveChangesAsync();
            return equipe;
        }
    }
}