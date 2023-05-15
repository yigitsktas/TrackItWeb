using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItWeb.Entities
{
    public class Member
    {
        public int MemberID { get; set; }
        public string? EMail { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }
        public int Gender { get; set; }
        public DateTime BirthYear { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
