using System;
using System.Collections.Generic;

namespace Models
{
    public partial class User
    {
        public User()
        {
            Notebooks = new HashSet<Notebook>();
        }

        public string UserId { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Profile? Profile { get; set; }
        public virtual ICollection<Notebook> Notebooks { get; set; }
    }
}
