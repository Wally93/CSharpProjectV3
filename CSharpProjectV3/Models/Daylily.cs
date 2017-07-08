using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpProjectV3.Models
{

    //Model for Daylily, with 4 fields to be viewed and an ID.  Later, update the color field to be chosen from a dropdown list of preselected colors type enum. This could reduce confusion and duplication.

    public class Daylily
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int BloomSize { get; set; }

    //Later, specify size in .25 increments as dropdown enum list of choices type double from 8.00 to 42.00

    }
}