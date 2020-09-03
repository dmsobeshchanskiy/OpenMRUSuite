using OpenMRUSuiteCore.Common.Models;
using System.Collections.Generic;


namespace OpenMRUSuiteCore.Common.Interfaces
{
    /// <summary>
    /// MRU items storage interface
    /// </summary>
    public interface IMRUItemStorage
    {
        /// <summary>
        /// Reads and returns MRU items from storage
        /// </summary>
        /// <returns>MRU items from storage</returns>
        IEnumerable<MRUItem> ReadMRUItems();

        /// <summary>
        /// Save MRU items to storage
        /// </summary>
        /// <param name="items">MRU items to store</param>
        void SaveMRUItems(IEnumerable<MRUItem> items);
    }
}
