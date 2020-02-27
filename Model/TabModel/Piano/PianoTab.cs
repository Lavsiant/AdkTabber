using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.TabModel
{
    public class PianoTab : Tab, ITab<PianoIteration>
    {
        public PianoTab()
        {
            Type = TabType.Piano;
        }

        public List<PianoIteration> Iterations { get; set; }

    }
}
