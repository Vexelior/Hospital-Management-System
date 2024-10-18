﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models.ViewModels
{
    public class AccountRequestViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        public List<SelectListItem> ListOfStates { get; set; }
        
        [Required]
        [Display(Name = "State")]
        public string SelectedState { get; set; }

        [Required]
        [Display(Name = "Medical License Number")]
        public string MedicalLicenseNumber { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        [Display(Name = "Years of Experience")]
        public int YearsOfExperience { get; set; }

        [Required]
        [Display(Name = "Medical License Document")]
        public IFormFile MedicalLicenseDocument { get; set; }

        [Required]
        [Display(Name = "Certification Document")]
        public IFormFile CertificationDocument { get; set; }

        [Required]
        [Display(Name = "CV")]
        public IFormFile CVDocument { get; set; }
    }
}
