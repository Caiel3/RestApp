using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestApp.Common.Request
{
    public class QualificationRequest
    {
        [Required]
        public int PointSaleId { get; set; }

        [Range(0, 5)]
        [Required]
        public float Score { get; set; }

        public string Remarks { get; set; }
    }

}
