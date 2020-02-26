using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Interfaces
{
    public interface ITab<TIteration>
    {
        List<TIteration> Iterations { get; set; }

        int ID { get; set; }

        string Name { get; set; }        
    }
}
