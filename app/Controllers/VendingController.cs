using System;
using cs_vending_machine.Models;
using cs_vending_machine.Services;

namespace cs_vending_machine.Controllers
{
  class VendingController
  {
    private bool _running { get; set; } = true;
    private VendingService _vs { get; set; } = new VendingService();
    public void Run()
    {
      while (_running)
      {
        GetUserInput();
        Print();
      }
    }

    private void GetUserInput()
    {
      System.Console.WriteLine("What would you like to do? (view (F)ood, view (D)rinks, purchase, quit)");
      string input = Console.ReadLine().ToLower();
      string indexString = "";
      switch (input)
      {
        case "quit":
        case "exit":
        case "q":
          _running = false;
          break;
        case "view food":
        case "food":
        case "f":
          _vs.AddFoodMenuToMessages();
          break;
        case "view drinks":
        case "drinks":
        case "d":
          _vs.AddDrinkMenuToMessages();
          break;
        case "purchase":
        case "p":
          System.Console.Write("(F)ood or a (D)rink?: ");
          input = Console.ReadLine().ToLower();
          switch (input)
          {
            case "food":
            case "f":
              System.Console.Write("Enter the food item number to buy: ");
              indexString = Console.ReadLine();
              _vs.PurchaseFood(indexString);
              break;
            case "drinks":
            case "drink":
            case "d":
              System.Console.Write("Enter the drink item number to buy: ");
              indexString = Console.ReadLine();
              _vs.PurchaseDrink(indexString);
              break;
            default:
              System.Console.WriteLine("Invalid selection.");
              break;

          }
          break;
        default:
          System.Console.WriteLine("Invalid selection.");
          break;
      }
    }

    private void Print()
    {
      foreach (Message message in _vs.Messages)
      {
        Console.ForegroundColor = message.Color;
        Console.WriteLine(message.Body);
      }
      Console.ForegroundColor = ConsoleColor.White;
      _vs.Messages.Clear();
    }

  }
}