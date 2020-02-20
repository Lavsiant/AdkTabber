using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.TabModel
{
    public class DrumTab : Tab
    {
        public DrumTab()
        {
            Type = TabType.Drums;
        }

        public List<DrumIteration> Iterations { get; set; }
    }
}
