namespace BurgerApp.Models.Domain
{
    public class Burger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Burger(string name, int price, bool isVegetarian, bool isVegan, bool hasFries)
        {
            Name = name;
            Price = price;
            IsVegan = isVegan;
            IsVegetarian = isVegetarian;
            HasFries = hasFries;
            Orders = new List<Order>();
        }

        public Burger()
        {
            Orders = new List<Order>();
        }
    }
}
