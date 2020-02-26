using Model.TabModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class SongDTO
    {
        public string Name { get; set; }

        public string Band { get; set; }

        public int Tempo { get; set; }
    }
}
