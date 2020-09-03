using System;


namespace OpenMRUSuiteCore.Common.Interfaces
{
    /// <summary>
    /// Represents MRU item
    /// </summary>
    public interface IMRUItem
    {
        /// <summary>
        /// Full path to file (also used as id of MRU item)
        /// </summary>
        string FilePath { get; }
        
        /// <summary>
        /// How menu times file was selected from manager / menu
        /// </summary>
        int SelectedCount { get; }
        
        /// <summary>
        /// Is MRU item pinned or not
        /// </summary>
        bool Pinned { get; }
       
        /// <summary>
        /// Date of last access to the MRU
        /// </summary>
        DateTime LastAccessedDate { get; }
    }
}
