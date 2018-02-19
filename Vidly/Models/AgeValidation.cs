using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class AgeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeID == MembershipType.Unknown || customer.MembershipTypeID == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.DateOfBirth == null)
                return new ValidationResult("Date of Birth required");

            var age = DateTime.Now.Year - customer.DateOfBirth.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be atleast 18 years of age to avail membership");
        }
    }
}