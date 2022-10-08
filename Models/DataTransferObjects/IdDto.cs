using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class IdDto
    {
        public IdDto(Guid guid)
        {
            this.guid = guid;
        }

        public Guid guid { get; set; } 
    }
}