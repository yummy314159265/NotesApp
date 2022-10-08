using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class UserIdNotFoundDto
    {
        public string ErrorMessage { get; set; }

        public UserIdNotFoundDto(string errorMessage)
        {
            ErrorMessage = $"UserID {errorMessage} not found";
        }
    }
}