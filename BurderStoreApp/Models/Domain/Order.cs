namespace BurgerApp.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Burger Burger { get; set; }
        public int BurgerId { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public bool IsDelivered { get; set; }

        public Order() { }
        public Order(int id, string fullName, Burger burger, int burgerId, string address, string location, bool isDelivered)
        {
            Id = id;
            FullName = fullName;
            BurgerId = burgerId;
            Burger = burger;
            Address = address;
            Location = location;
            IsDelivered = isDelivered;
        }
    }
}
