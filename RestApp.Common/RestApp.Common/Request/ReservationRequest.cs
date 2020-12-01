using ReatApp.Web.Data.Entities;
using RestApp.Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Common.Request
{
     public class ReservationRequest
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public UserResponse User { get; set; }

        public PointSaleHelper pointSale { get; set; }
    }
}
