using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoLib
{
    public enum FilterType
    {
        TagFilter         = 1,
        NameFilter        = 2,
        DescriptionFilter = 3,
        LastItemFilter    = 4,
        All               = 5
    }

    public enum ItemAction
    {
        Add    = 1,
        Search = 2
    }

    public enum Status
    {
        OK    = 0,
        Error = 1
    }
}
