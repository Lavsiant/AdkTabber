using Model.TabModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.SongModel
{
    public class Song
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Band { get; set; }

        public int Tempo { get; set; }

        public DifficultyType Difficulty { get; set; }

        public List<Tab> Tabs { get; set; }
    }
}
