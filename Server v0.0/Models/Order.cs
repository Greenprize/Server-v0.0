namespace Server_v0._0.Models
{
    public class Order
    {
        public int OrderId { get; set;}
        public double Price { get; set;}

        public int ClientID { get; set; }
    }
}
