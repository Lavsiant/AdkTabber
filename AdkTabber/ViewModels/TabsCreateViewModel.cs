using Model.TabModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdkTabber.ViewModels
{
    public class TabsCreateViewModel
    {        
        public int SongId { get; set; }

        public List<GuitarTab> GuitarTabs { get; set; }

        public List<DrumTab> DrumTabs { get; set; }
    }
}
