using System.ComponentModel.DataAnnotations;

namespace PlatformService.Api.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class RequiredStringNotEmptyAndWhiteSpaceAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is string stringValue)
        {
            var isValid = !string.IsNullOrWhiteSpace(stringValue);
            if (!isValid)
                ErrorMessage = "The value is null or empty or contains only white spaces.";
            return isValid;
        }

        return false;
    }
}