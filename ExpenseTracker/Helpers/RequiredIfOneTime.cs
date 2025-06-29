using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.PL.Helpers
{
    public class RequiredIfOneTime : ValidationAttribute
    {


       
        private readonly string _otherProperty;

        public RequiredIfOneTime(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyValue = validationContext.ObjectType.GetProperty(_otherProperty).GetValue(validationContext.ObjectInstance);

            if (otherPropertyValue == "OneTime") { 

                if (!value.Equals(typeof(DateTime)))
                {
                    return new ValidationResult($"Enter a valid date");
                }

                else return ValidationResult.Success;
            }

            return ValidationResult.Success;
        }


    }
}
