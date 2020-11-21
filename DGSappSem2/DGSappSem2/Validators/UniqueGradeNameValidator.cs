using DGSappSem2.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;


namespace DGSappSem2.Validators
{
    public class UniqueGradeNameValidator : ValidationAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string name = value.ToString();

                if (!db.Grades.Any(x => x.GradeName.Equals(name)))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Please Enter a Valid Grade Name. Grade Name must be unique");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }
    }
}