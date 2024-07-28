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

        public Burger(int id,string name,int price,bool isVegetarian,bool isVegan,bool hasFries) 
        {
            Id = id;
            Name = name;
            Price = price;
            IsVegan = isVegan;
            IsVegetarian = isVegetarian;
            HasFries = hasFries;
        }
        public Burger() { }
    }
}
