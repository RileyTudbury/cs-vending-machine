using System;

namespace cs_vending_machine.Controllers
{
  class VendingController
  {
    private bool _running { get; set; } = true;


    private void Run()
    {
      while (_running)
      {

      }
    }

    private void GetUserInput()
    {
      System.Console.WriteLine("What would you like to do? (view, purchase, quit)");
      string input = Console.ReadLine().ToLower();
      switch (input)
      {
        case "quit":
        case "exit":
        case "q":
          _running = false;
          break;
        case "view":
        case "v":
          break;
        case "purchase":
        case "p":
          break;
        default:
          break;
      }
    }

    private void Print()
    {

    }

  }
}