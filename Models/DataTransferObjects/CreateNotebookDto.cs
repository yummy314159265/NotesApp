using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CreateNotebookDto
    {
        public CreateNotebookDto(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}