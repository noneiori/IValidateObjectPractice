using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IValidateObjectPractice
{
    /// <summary>
    /// 驗證測試物件，驗證方式置於測試專案
    /// </summary>
    public class ValidateSampleObject : IValidatableObject
    {
        [Required]
        public string Name { get; set; }

        public bool Enable { get; set; }
        [Range(1,10)]
        public int Numbers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(this.Name,
                new ValidationContext(this, null, null) { MemberName = "Name" }, results);
            Validator.TryValidateProperty(this.Numbers,
                new ValidationContext(this, null, null) { MemberName = "Numbers" }, results);
            if (Name.Length > 3 && !Enable)
                results.Add(new ValidationResult("Name的字元長度大於3的情況下必需讓Enable為True"));
            if(Name.Length<=3 && Enable)
                results.Add(new ValidationResult("Name的字元長度小於等於3的情況下必需讓Enable為False"));
            return results;
        }
    }
}
