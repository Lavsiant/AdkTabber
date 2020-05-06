using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.TabModel
{
    public class DrumIteration
    {
        [Key]
        public int ID { get; set; }
        public List<DrumNote> Drums { get; set; }
        public int TimeScale { get; set; }
    }
}
