namespace Inventory.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public int CategoryId { get; set; }
  }
}