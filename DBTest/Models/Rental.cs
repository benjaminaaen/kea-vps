using System;

namespace DBTest.Models
{
    public enum Status
    {
        Pending, Confirmed, Denied, Active, Inactive
    }
    public class Rental
    {
        public int RentalId { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationInDays { get; set; }
        public Status Status { get; set; }
        public int UserId { get; set; }
        public int? ConfirmedByUserId { get; set; }
        public String Comments { get; set; }
        public virtual User User { get; set; }
        public virtual ServerSlot ServerSlot { get; set; }
    }
}