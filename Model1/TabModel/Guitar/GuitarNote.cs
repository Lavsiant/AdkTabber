using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.TabModel
{
    public class GuitarNote
    {
        [Key]
        public int ID { get; set; }

        public int Fret { get; set; }

        public int String { get; set; }
    }
}
