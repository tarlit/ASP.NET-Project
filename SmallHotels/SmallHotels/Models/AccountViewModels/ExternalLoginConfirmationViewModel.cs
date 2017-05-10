using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallHotels.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The {0} must be between 3 and 20 characters long.")]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}