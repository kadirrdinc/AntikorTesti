using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AT.Data.Entities
{
    public class InsuredUser : BaseEntity
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string PolicyNo { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string IdentityNo { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        public DateTime RezervDate { get; set; }
        public DateTime? ConfirmRezervDate { get; set; }

    }
}
