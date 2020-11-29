using System;

namespace ReatApp.Web.Data.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public User User { get; set; }

        public PointSale pointSale { get; set; }


    }

}
