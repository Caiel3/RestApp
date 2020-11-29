using System;

namespace RestApp.Common.Responses
{
    public class BookingResponse
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public UserResponse User { get; set; }

        public PointSaleResponse pointSale { get; set; }

    }
}
