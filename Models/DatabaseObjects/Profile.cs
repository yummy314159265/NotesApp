using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual User FkUser { get; set; } = null!;
    }
}
