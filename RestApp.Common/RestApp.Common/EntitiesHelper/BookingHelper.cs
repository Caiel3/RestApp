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

        public UserHelper User { get; set; }

        public PointSaleHelper pointSale { get; set; }

        [Display(Name = "Date Sent")]
        public DateTime? DateSent { get; set; }

        [Display(Name = "Date Confirmed")]
        public DateTime? DateConfirmed { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

    }

}
