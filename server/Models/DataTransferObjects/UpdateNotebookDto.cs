using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class UpdateNotebookDto
    {
        public UpdateNotebookDto(string name, Guid notebookID)
        {
            Name = name;
            NotebookID = notebookID;
        }

        public string Name { get; set; }
        public Guid NotebookID { get; set; }

        
    }
}