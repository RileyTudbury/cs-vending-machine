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
          Messages.Add(new Message($"{i + 1}. {food.Name} ({food.Flavor}) - Price: ${food.Price} Quantity: {food.Quantity}"));
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
          Messages.Add(new Message($"{i + 1}. {drink.Name} ({drink.Flavor}) - Price: ${drink.Price} Quantity: {drink.Quantity}"));
        }
      }
    }

    public void PurchaseFood(string indexString)
    {
      if (int.TryParse(indexString, out int index) && index - 1 > -1 && index - 1 < _store.Foods.Count)
      {
        Food foodSelected = _store.Foods[index - 1];
        if (foodSelected.Quantity > 0 && foodSelected.Price <= _store.User.Cash)
        {
          foodSelected.Quantity -= 1;
          _store.User.Cash -= foodSelected.Price;
          Messages.Add(new Message($"Successfully purchased {foodSelected.Name}", ConsoleColor.DarkGreen));
          return;
        }
        else if (foodSelected.Quantity == 0)
        {
          Messages.Add(new Message($"Sorry, we are out of {foodSelected.Name}. Please make another selection."));
          return;
        }
        Messages.Add(new Message("Insufficient funds."));
        return;
      }
      Messages.Add(new Message("Invalid selection", ConsoleColor.Red));
    }

    public void PurchaseDrink(string indexString)
    {
      if (int.TryParse(indexString, out int index) && index - 1 > -1 && index - 1 < _store.Drinks.Count)
      {
        Drink drinkSelected = _store.Drinks[index - 1];
        if (drinkSelected.Quantity > 0 && drinkSelected.Price <= _store.User.Cash)
        {
          drinkSelected.Quantity -= 1;
          _store.User.Cash -= drinkSelected.Price;
          Messages.Add(new Message($"Successfully purchased {drinkSelected.Name}", ConsoleColor.DarkGreen));
          return;
        }
        else if (drinkSelected.Quantity == 0)
        {
          Messages.Add(new Message($"Sorry, we are out of {drinkSelected.Name}. Please make another selection."));
          return;
        }
        Messages.Add(new Message("Insufficient funds."));
        return;
      }
      Messages.Add(new Message("Invalid selection", ConsoleColor.Red));
    }

    public void AddQuarter()
    {
      _store.User.Cash += .25f;
      Messages.Add(new Message($"Added $0.25, current balance: ${_store.User.Cash.ToString("0.00")}"));
    }

    public void CreateUser(string name, float cash)
    {
      _store.User.Name = name;
      _store.User.Cash = cash;
    }
    internal void CheckBalance()
    {
      float rawCash = _store.User.Cash;
      string displayCash = rawCash.ToString("0.00");
      Messages.Add(new Message($"Your current balance is ${displayCash}"));
    }
  }
}