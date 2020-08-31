using OpenMRUSuiteCore.Common.Interfaces;
using System;


namespace OpenMRUSuiteCore.Common.Models
{
    public class MRUItem : IMRUItem
    {
        public string FilePath { get; set; }
        public int SelectedCount { get; set; }
        public bool Pinned { get; set; }
        public DateTime LastAccessedDate { get; set; }
    }
}
