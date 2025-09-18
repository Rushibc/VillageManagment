using System.ComponentModel.DataAnnotations;

namespace VillageManagement.Common
{
    public class BirthDateInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date < DateTime.UtcNow;
            }
            return false;
        }
    }
}