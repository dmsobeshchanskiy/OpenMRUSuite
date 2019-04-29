using System;

namespace MRUCore.Interfaces
{
    /// <summary>
    /// Represent MRU item
    /// </summary>
    public interface IMRUItem
    {
        /// <summary>
        /// Full path to file
        /// </summary>
        string FilePath { get;  }
        /// <summary>
        /// How menu times file was selected from manager
        /// </summary>
        int SelectedCount { get; }
        /// <summary>
        /// Is MRU item pinned or not
        /// </summary>
        bool Pinned { get; }
        /// <summary>
        /// Show date of last access to the MRU
        /// </summary>
        DateTime LastAccessedDate { get; }
    }
}
