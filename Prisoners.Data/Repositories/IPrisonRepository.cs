using Prisoners.Data.Models;

namespace Prisoners.Data.Repositories
{
    public interface IPrisonRepository
    {
        Task AddInventory(Inventory inventory);
        Task<Prisoner> AddPrisoner(Prisoner prisoner);
        Task DeleteInventory(Inventory inventory);
        Task DeletePrisoner(Prisoner prisoner);
        Task<Inventory> GetInventory(int id);
        Task<Prisoner> GetPrisoner(int id);
        Task<IEnumerable<Prisoner>> GetPrisoners();
        Task UpdateInventory(Inventory inventory);
        Task UpdatePrisoner(Prisoner prisoner);
    }
}