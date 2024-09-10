namespace ForTravellers.Models
{
    public class Payment
    {
    
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public virtual Reservation Reservation{ get; set; }
        public int RegId { get; set; }
    }
}
