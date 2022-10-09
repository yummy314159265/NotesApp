using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class UpdateProfileDto
    {
        public UpdateProfileDto(string fk_UserID, string name, string picture, string nickname)
        {
            Fk_UserID = fk_UserID;
            Name = name;
            Picture = picture;
            Nickname = nickname;
        }

        public string Fk_UserID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Nickname { get; set; }
    }
}