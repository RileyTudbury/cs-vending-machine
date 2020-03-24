using System;
using System.Collections.Generic;
using cs_vending_machine.Models;

namespace cs_vending_machine.Services
{
  class VendingService
  {
    private Store _store { get; set; } = new Store();
    public List<Message> Messages { get; set; } = new List<Message>();

    public void AddFoodMenuToMessages()
    {
      for (int i = 0; i < _store.Foods.Count; i++)
      {
        var food = _store.Foods[i];
        if (food.Quantity > 0)
        {
          Messages.Add(new Message($"{i + 1}. {food.Name} ({food.Flavor}) - Price: ${food.Price}"));
        }
      }
    }

    public void AddDrinkMenuToMessages()
    {
      for (int i = 0; i < _store.Drinks.Count; i++)
      {
        var drink = _store.Drinks[i];
        if (drink.Quantity > 0)
        {
          Messages.Add(new Message($"{i + 1}. {drink.Name} ({drink.Flavor}) - Price: ${drink.Price}"));
        }
      }
    }

    public void PurchaseFood(string indexString)
    {
      if (int.TryParse(indexString, out int index) && index - 1 > -1 && index - 1 < _store.Foods.Count)
      {
        Food foodSelected = _store.Foods[index - 1];
        if (foodSelected.Quantity > 0)
        {
          foodSelected.Quantity -= 1;
          Messages.Add(new Message($"Successfully purchased {foodSelected.Name}", ConsoleColor.DarkGreen));
          return;
        }
      }
      Messages.Add(new Message("Invalid selection", ConsoleColor.Red));
    }

    public void PurchaseDrink(string indexString)
    {
      if (int.TryParse(indexString, out int index) && index - 1 > -1 && index - 1 < _store.Drinks.Count)
      {
        Drink drinkSelected = _store.Drinks[index - 1];
        if (drinkSelected.Quantity > 0)
        {
          drinkSelected.Quantity -= 1;
          Messages.Add(new Message($"Successfully purchased {drinkSelected.Name}", ConsoleColor.DarkGreen));
          return;
        }
      }
      Messages.Add(new Message("Invalid selection", ConsoleColor.Red));
    }

  }
}