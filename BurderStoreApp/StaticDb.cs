using BurgerApp.Models.Domain;

namespace BurgerApp
{
    public static class StaticDb
    {
        public static List<Burger> Burgers = new List<Burger>
        {
            new Burger(1, "Classic Beef Burger", 599, false, false, true),
            new Burger(2, "Cheese Burger", 649, false, false, true),
            new Burger(3, "Veggie Burger", 499, true, false, false),
            new Burger(4, "Vegan Delight", 699, true, true, true),
            new Burger(5, "Chicken Burger", 599, false, false, false),
            new Burger(6, "Fish Burger", 649, false, false, true),
            new Burger(7, "Double Beef Burger", 799, false, false, true),
            new Burger(8, "Spicy Black Bean Burger", 529, true, true, false),
            new Burger(9, "Turkey Burger", 559, false, false, true),
            new Burger(10, "Mushroom Swiss Burger", 679, true, false, false)

    };
        public static List<Order> Orders = new List<Order>
         {
            new Order(1, "John Doe", Burgers.FirstOrDefault(x => x.Id == 1), 1, "123 Main St", "New York", false),
            new Order(2, "Jane Smith", Burgers.FirstOrDefault(x => x.Id == 2), 2, "456 Elm St", "Los Angeles", true),
            new Order(3, "Alice Johnson", Burgers.FirstOrDefault(x => x.Id == 3), 3, "789 Oak St", "Chicago", false),
            new Order(4, "Bob Brown", Burgers.FirstOrDefault(x => x.Id == 4), 4, "101 Pine St", "Houston", true),
            new Order(5, "Charlie Davis", Burgers.FirstOrDefault(x => x.Id == 5), 5, "202 Maple St", "Phoenix", false),
            new Order(6, "Diana Evans", Burgers.FirstOrDefault(x => x.Id == 6), 6, "303 Cedar St", "Philadelphia", true),
            new Order(7, "Eve Foster", Burgers.FirstOrDefault(x => x.Id == 7), 7, "404 Birch St", "San Antonio", false),
            new Order(8, "Frank Green", Burgers.FirstOrDefault(x => x.Id == 8), 8, "505 Walnut St", "San Diego", true),
            new Order(9, "Grace Harris", Burgers.FirstOrDefault(x => x.Id == 9), 9, "606 Ash St", "Dallas", false),
            new Order(10, "Hank Irving", Burgers.FirstOrDefault(x => x.Id == 10), 10, "707 Cherry St", "San Jose", true)
        };
    }
}
