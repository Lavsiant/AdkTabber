using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.TabModel
{
    public class Tab
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public int Tempo { get; set; }

        [NotMapped]
        public TabType Type { get; set; }
    }
}
    