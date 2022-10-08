using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class UserIdDto
    {
        public UserIdDto(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}