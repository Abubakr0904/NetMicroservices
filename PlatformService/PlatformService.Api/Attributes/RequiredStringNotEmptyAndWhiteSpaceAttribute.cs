using System.ComponentModel.DataAnnotations;

namespace PlatformService.Api.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class RequiredStringNotEmptyAndWhiteSpaceAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is string stringValue)
        {
            return !string.IsNullOrWhiteSpace(stringValue);
        }

        return false;
    }
}