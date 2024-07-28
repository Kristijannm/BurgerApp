using BurgerApp.Models.Domain;

namespace BurgerStoreApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int BurgerId { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public bool IsDelivered { get; set; }

        public OrderViewModel() { }
        public OrderViewModel(int id, string fullName,int burgerId, string address, string location, bool isDelivered)
        {
            Id = id;
            FullName = fullName;
            BurgerId = burgerId;
            Address = address;
            Location = location;
            IsDelivered = isDelivered;
        }
    }
}
