#nullable disable
using System.ComponentModel.DataAnnotations;

namespace nscccoursemap_tillyjay.CustomValidators;

public class DateGreaterThanAttribute : ValidationAttribute
{
    public DateGreaterThanAttribute(string dateToCompareToFieldName)
    {
        DateToCompareToFieldName = dateToCompareToFieldName;
    }

    private string DateToCompareToFieldName { get; set; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime laterDate = (DateTime)value;

        DateTime earlierDate = (DateTime)validationContext.ObjectType.GetProperty(DateToCompareToFieldName).GetValue(validationContext.ObjectInstance, null)!;

        if (laterDate > earlierDate)
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("End date must be later than start date.");
        }
    }
}