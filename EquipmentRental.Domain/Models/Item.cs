namespace Domain.Models
{
    public class Item
    {
        public Equipment Equipment { get; }
        public int Days { get; }

        public Item(Equipment equipment, int days)
        {
            Equipment = equipment;
            Days = days;
        }
    }
}