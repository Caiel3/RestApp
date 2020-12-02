using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReatApp.Web.Data.Entities
{
    public class BookingHelper
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public UserHelper_temp User { get; set; }

        public PointSaleHelper pointSale { get; set; }

    }

}
