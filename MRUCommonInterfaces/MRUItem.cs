using MRUCore.Interfaces;
using System;


namespace MRUCore
{
    public class MRUItem: IMRUItem
    {
        public string FilePath { get; set; }
        public int SelectedCount { get; set; }
        public bool Pinned { get; set; }
        public DateTime LastAccessedTime { get; set; }
    }
}
