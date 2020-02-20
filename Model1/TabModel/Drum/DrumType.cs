using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Model.TabModel
{
    public enum DrumType
    {
        [Description("Crash Cymbal 2")]
        CC2 = 0,
        [Description("Bass Drum")]
        BD = 1,
        [Description("Closed Hi Hat")]
        xH = 2,
        [Description("Snare")]
        S = 3,
        [Description("Mid Tom")]
        MT = 4,
        [Description("Low Tom")]
        LT = 5,
        [Description("Crash Cymbal 1")]
        CC1 = 6,
        [Description("Open Hi Hat")]
        oH = 7,
        [Description("High Floor Tom")]
        HFT = 8,
        [Description("Side Stick")]
        SS = 9,
        [Description("Low Floor Tom")]
        LFT = 10
    }
}
