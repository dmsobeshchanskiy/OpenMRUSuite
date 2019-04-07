using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMRUSuite.Common
{
    public class MRUItem
    {
        public string FilePath { get; set; }
        public int SelectedCount { get; set; }
        public int Pinned { get; set; }
    }
}
