using Model.TabModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdkTabber.ViewModels
{
    public class SongCreateViewModel
    {
        public string Name { get; set; }

        public string Band { get; set; }

        public int Tempo { get; set; }

        public List<GuitarTab> GuitarTabs { get; set; }

        public List<DrumTab> DrumTabs { get; set; }
    }
}
