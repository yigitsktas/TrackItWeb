using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItWeb.Entities
{
    public class MemberWorkoutLog
    {
        public int MemberWorkoutID { get; set; }
		public Guid GUID { get; set; }
		public int MemberID { get; set; }
        public string? MemberWorkoutName { get; set; }
        public string? Notes { get; set; }
        public bool isDone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
