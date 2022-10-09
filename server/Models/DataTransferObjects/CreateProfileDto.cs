using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CreateProfileDto
    {
        public CreateProfileDto(string name, string email, string picture, string nickname)
        {
            Name = name;
            Email = email;
            Picture = picture;
            Nickname = nickname;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string Nickname { get; set; }
    }
}