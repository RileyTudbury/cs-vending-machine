using System;

namespace cs_vending_machine.Models
{
  class Message
  {
    public string Body { get; set; }
    public ConsoleColor Color { get; set; }
    public Message(string body, ConsoleColor color = ConsoleColor.DarkGreen)
    {
      Body = body;
      Color = color;
    }
  }
}