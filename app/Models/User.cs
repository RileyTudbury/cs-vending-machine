namespace cs_vending_machine.Models
{
  class User
  {
    public string Name { get; set; }
    public float Cash { get; set; }
    public void AddQuarter()
    {
      Cash += .25f;
    }
    public void RenameSelf(string newName)
    {
      Name = newName;
    }

    public User(string name, float cash)
    {
      Name = name;
      Cash = cash;
    }
  }
}