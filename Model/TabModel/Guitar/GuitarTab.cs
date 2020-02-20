using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.TabModel
{
    public class GuitarTab : Tab, ITab<GuitarIteration>
    {
        public GuitarTab()
        {
            Type = TabType.Guitar;
        }

        public List<GuitarIteration> Iterations { get; set; }

    }
}
