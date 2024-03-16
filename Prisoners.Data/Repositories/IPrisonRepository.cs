using Prisoners.Data.Models;

namespace Prisoners.Data.Repositories
{
    public interface IPrisonRepository
    {
        Task<Inventory> AddInventory(Inventory inventory);
        Task<Prisoner> AddPrisoner(Prisoner prisoner);
        Task DeleteInventory(Inventory inventory);
        Task DeletePrisoner(Prisoner prisoner);
        Task<Inventory> GetInventory(int id);
        Task<Prisoner> GetPrisoner(int id);
        Task<ICollection<Prisoner>> GetPrisoners();
        Task<ICollection<Inventory>> GetInventories(int id);
        Task UpdateInventory(Inventory inventory);
        Task UpdatePrisoner(Prisoner prisoner);
    }
}