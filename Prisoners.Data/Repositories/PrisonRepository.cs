using Microsoft.EntityFrameworkCore;
using Prisoners.Data.Models;

namespace Prisoners.Data.Repositories
{
    public class PrisonRepository : IPrisonRepository
    {
        private readonly PrisonContext _ctx;
        public PrisonRepository(PrisonContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Prisoner>> GetPrisoners()
        {
            var prisoners = await _ctx.Prisoners.ToListAsync();
            return prisoners;
        }

        public async Task<Prisoner> GetPrisoner(int id)
        {
            return await _ctx.Prisoners.FindAsync(id);
        }

        public async Task<Prisoner> AddPrisoner(Prisoner prisoner)
        {
            _ctx.Prisoners.Add(prisoner);
            await _ctx.SaveChangesAsync();

            return prisoner;
        }


        public async Task UpdatePrisoner(Prisoner prisoner)
        {
            _ctx.Prisoners.Update(prisoner);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeletePrisoner(Prisoner prisoner)
        {
            _ctx.Prisoners.Remove(prisoner);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Inventory> GetInventory(int id)
        {
            var inventory = await _ctx.Inventories.FindAsync(id);

            return inventory;
        }

        public async Task AddInventory(Inventory inventory)
        {
            _ctx.Inventories.Add(inventory);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateInventory(Inventory inventory)
        {
            _ctx.Inventories.Update(inventory);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteInventory(Inventory inventory)
        {
            _ctx.Inventories.Remove(inventory);
            await _ctx.SaveChangesAsync();
        }

        /*
        public async Task<Inventory> GetInventories(int id)
        {
            return await _ctx.Inventories.Where(inv => inv.PrisonerID == id).ToListAsync();
        }
        */
    }
}
