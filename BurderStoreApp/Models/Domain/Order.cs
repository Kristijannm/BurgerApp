namespace BurgerApp.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public bool IsDelivered { get; set; }

        public int BurgerId { get; set; }

        public Burger Burger { get; set; }

        public Order() { }

        public Order(string fullName, int burgerId, string address, string location, bool isDelivered)
        {
            FullName = fullName;
            BurgerId = burgerId;
            Address = address;
            Location = location;
            IsDelivered = isDelivered;
        }
    }
}