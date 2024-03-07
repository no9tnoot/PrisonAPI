
namespace Prisoners.Data.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string? ItemName { get; set; }
        public int Quantity { get; set; }
        public int PrisonerId { get; set; }
    }
}
