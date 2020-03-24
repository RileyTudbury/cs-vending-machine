namespace cs_vending_machine.Models
{
  class Food
  {
    public string Name { get; set; }
    public float Price { get; set; }
    public string Flavor { get; set; }

    public int Quantity { get; set; }

    public Food(string name, float price, string flavor, int quantity)
    {
      Name = name;
      Price = price;
      Flavor = flavor;
      Quantity = quantity;
    }
  }
}