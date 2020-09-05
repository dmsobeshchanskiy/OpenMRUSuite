using System;


namespace OpenMRU.Core.Common.Models
{
    /// <summary>
    /// Represents MRU item
    /// </summary>
    public class MRUItem
    {
        /// <summary>
        /// Full path to file (also used as id of MRU item)
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// How menu times file was selected from manager / menu
        /// </summary>
        public int SelectedCount { get; set; }

        /// <summary>
        /// Is MRU item pinned or not
        /// </summary>
        public bool Pinned { get; set; }

        /// <summary>
        /// Date of last access to the MRU
        /// </summary>
        public DateTime LastAccessedDate { get; set; }
    }
}
