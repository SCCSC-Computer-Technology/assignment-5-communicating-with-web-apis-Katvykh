using Microsoft.EntityFrameworkCore;
using KVykhovanets_Lab5.Models.TableModels;

namespace KVykhovanets_Lab5.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly StatesDBContext _context;

        public StateRepository(StatesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<States>> RetrieveAllAsync()
        {
            return await _context.States.ToListAsync();
        }

        public async Task<States?> RetrieveAsync(int id)
        {
            return await _context.States.FindAsync(id);
        }

        public async Task<States?> CreateAsync(States state)
        {
            var added = await _context.States.AddAsync(state);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<States?> UpdateAsync(int id, States state)
        {
            var existing = await _context.States.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(state);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null) return false;

            _context.States.Remove(state);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
