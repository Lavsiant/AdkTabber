using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.TabModel
{
    public class PianoIteration
    {
        [Key]
        public int ID { get; set; }

        public List<ConcreteNote> Notes { get; set; }
    }
}
