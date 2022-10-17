using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IValidateObjectPractice;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValidatableObject1()
        {
            ValidateSampleObject validateSampleObject = new ValidateSampleObject();
            validateSampleObject.Numbers = 100;

            var results = new List<ValidationResult>();
            /*
             * 注意validateAllProperties參數為true的情況下：
             * 欄位中有使用Require的情況下在該欄位沒有通過驗證時會直接結束，不再進行後續的驗證
             * 但是使用false的情況下，只要有一個屬性沒有通過的情況下就會直接結束驗證
            */
            bool validateAllProperties = true;
            bool isValued = Validator.TryValidateObject(validateSampleObject,
                new ValidationContext(validateSampleObject, null, null), results, validateAllProperties);

            print(results);
        }

        [TestMethod]
        public void TestValidatableObject2()
        {
            ValidateSampleObject validateSampleObject = new ValidateSampleObject();
            validateSampleObject.Numbers = 1;
            validateSampleObject.Name = "123";
            validateSampleObject.Enable = true;

            var results = new List<ValidationResult>();

            bool validateAllProperties = true;
            bool isValued = Validator.TryValidateObject(validateSampleObject,
                new ValidationContext(validateSampleObject, null, null), results, validateAllProperties);

            print(results);
        }

        [TestMethod]
        public void TestValidatableObject3()
        {
            ValidateSampleObject validateSampleObject = new ValidateSampleObject();
            validateSampleObject.Numbers = 15;
            validateSampleObject.Name = "12345";
            validateSampleObject.Enable = false;

            var results = new List<ValidationResult>();

            bool validateAllProperties = false;
            bool isValued = Validator.TryValidateObject(validateSampleObject,
                new ValidationContext(validateSampleObject, null, null), results, validateAllProperties);

            print(results);
        }

        private void print(List<ValidationResult> results)
        {
            foreach (var item in results)
            {
                Console.WriteLine(item.ErrorMessage);
            }
        }
    }
}
