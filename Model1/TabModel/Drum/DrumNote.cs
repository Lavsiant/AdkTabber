using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.TabModel
{
    public class DrumNote
    {
        [Key]
        public int ID { get; set; }

        public DrumType Drum { get; set; }
    }
}
