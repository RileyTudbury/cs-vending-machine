using System.Collections.Generic;

namespace cs_vending_machine.Models
{
  class Store
  {
    public List<Food> Foods { get; set; }
    public List<Drink> Drinks { get; set; }

    public Store()
    {
      Foods = new List<Food>(){
        new Food("Muddy Buddys", 1.99f, "Classic", 4),
        new Food("Pretzels", 0.75f, "Classic", 6),
        new Food("Poptart", .75f, "Chocolate Chip", 2)
      };

      Drinks = new List<Drink>(){
        new Drink("Water", 1.99f, "Crisp and Cool", 10),
        new Drink("Coke", 1.50f, "Cola", 5),
        new Drink("Iced Tea", .99f, "Green Tea Blast", 3)
      };
    }

  }
}