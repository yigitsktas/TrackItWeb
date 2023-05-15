﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItWeb.Entities
{
    public class WorkoutType
    {
        public int WorkoutTypeID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
