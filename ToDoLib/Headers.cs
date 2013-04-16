using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ToDoLib
{
    [DataContract]
    public enum FilterType
    {
        [EnumMember]
        TagFilter         = 3,
        [EnumMember]
        NameFilter        = 1,
        [EnumMember]
        DescriptionFilter = 2,
        [EnumMember]
        LastItemFilter    = 4,
        [EnumMember]
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
