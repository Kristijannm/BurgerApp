using BurgerApp.Models.Domain;

namespace BurgerStoreApp
{
    public static class StaticDb
    {
        public static List<Burger> Burgers = new List<Burger>
        {
            new Burger("Classic Beef Burger", 599, false, false, true),
            new Burger("Cheese Burger", 649, false, false, true),
            new Burger("Veggie Burger", 499, true, false, false),
            new Burger("Vegan Delight", 699, true, true, true),
            new Burger("Chicken Burger", 599, false, false, false),
            new Burger("Fish Burger", 649, false, false, true),
            new Burger("Double Beef Burger", 799, false, false, true),
            new Burger("Spicy Black Bean Burger", 529, true, true, false),
            new Burger("Turkey Burger", 559, false, false, true),
            new Burger("Mushroom Swiss Burger", 679, true, false, false)

    };
        public static List<Order> Orders = new List<Order>
         {
            new Order("John Doe", 1, "123 Main St", "New York", false),
            new Order("Jane Smith", 2, "456 Elm St", "Los Angeles", true),
            new Order("Alice Johnson", 3, "789 Oak St", "Chicago", false),
            new Order("Bob Brown", 4, "101 Pine St", "Houston", true),
            new Order("Charlie Davis", 5, "202 Maple St", "Phoenix", false),
            new Order("Diana Evans", 6, "303 Cedar St", "Philadelphia", true),
            new Order("Eve Foster", 7, "404 Birch St", "San Antonio", false),
            new Order("Frank Green", 8, "505 Walnut St", "San Diego", true),
            new Order("Grace Harris", 9, "606 Ash St", "Dallas", false),
            new Order("Hank Irving", 10, "707 Cherry St", "San Jose", true)
        };
    }
}
