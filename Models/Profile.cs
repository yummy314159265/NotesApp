using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Profile
    {
        public Guid ProfileId { get; set; }
        public string FkUserId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Picture { get; set; }
        public string? Nickname { get; set; }

        public virtual User FkUser { get; set; } = null!;
    }
}
