using System;
using cs_vending_machine.Controllers;

namespace cs_vending_machine
{
  class Program
  {
    static void Main(string[] args)
    {
      VendingController vm = new VendingController();
      vm.Run();
    }
  }
}
