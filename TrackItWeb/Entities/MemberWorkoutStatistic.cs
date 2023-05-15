﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItWeb.Entities
{
    public class MemberWorkoutLogStat
    {
        public int MemberStatisticsID { get; set; }
        public int MemberWorkoutID { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
        public string? Notes { get; set; }
        public bool isDone { get; set; }
    }
}
