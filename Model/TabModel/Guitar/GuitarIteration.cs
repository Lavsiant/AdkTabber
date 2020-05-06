using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.TabModel
{
    public class GuitarIteration
    {
        [Key]
        public int ID { get; set; }

        public List<GuitarNote> Notes { get; set; }

        public int TimeScale { get; set; }
    }
}
