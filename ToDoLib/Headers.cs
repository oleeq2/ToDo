using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoLib
{
    public enum FilterType
    {
        TagFilter         = 3,
        NameFilter        = 1,
        DescriptionFilter = 2,
        LastItemFilter    = 4,
        All               = 5
    }

    public enum ItemAction
    {
        EmptyAction = 0,
        Add    = 1,
        Search = 2
    }

    public enum Status
    {
        OK    = 0,
        Error = 1
    }
}
