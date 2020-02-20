using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Models
{
    public class ServiceResult
    {
        public ServiceResult(params string[] errors) : this((IEnumerable<string>)errors)
        {
        }

        public ServiceResult(IEnumerable<string> errors)
        {
            if (errors == null || !errors.Any())
            {
                errors = new[] { "An error occured" };
            }
            Succeeded = false;
            Errors = errors;
        }

        public ServiceResult(bool success)
        {
            Succeeded = success;
            Errors = new string[0];
        }

        public bool Succeeded { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public static ServiceResult Success { get; } = new ServiceResult(true);

        public static ServiceResult Failed(params string[] errors)
        {
            return new ServiceResult(errors);
        }
    }
}
