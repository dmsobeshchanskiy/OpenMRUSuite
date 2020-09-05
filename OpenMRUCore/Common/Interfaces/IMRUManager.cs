using OpenMRU.Core.Common.Models;
using System;
using System.Collections.Generic;

namespace OpenMRU.Core.Common.Interfaces
{
    /// <summary>
    /// MRU items manager
    /// </summary>
    public interface IMRUManager
    {
        /// <summary>
        /// This event fires each time when MRU items are changed 
        /// (i.e. added, removed, cleared, modified (pinned/unpinned), etc)
        /// </summary>
        event Action MRUItemsListChanged;

        /// <summary>
        /// This event fires each time when MRU item is selected
        /// </summary>
        event Action<string> MRUItemSelected;

        /// <summary>
        /// Currently available MRU items (readed from storage)
        /// </summary>
        List<MRUItem> MRUItems { get; }

        /// <summary>
        /// Initializes manager with given MRU storage
        /// </summary>
        /// <param name="storage">MRU items storage implementation</param>
        void Initialize(IMRUItemStorage storage);

        /// <summary>
        /// Add file to tracking as MRU item
        /// </summary>
        /// <param name="path">File full path</param>
        void AddFile(string path);

        /// <summary>
        /// Remove given file from MRU items 
        /// </summary>
        /// <param name="path">File full path</param>
        void RemoveFile(string path);

        /// <summary>
        /// Clear MRU storage (remove all items)
        /// </summary>
        void ClearMRUItems();

        /// <summary>
        /// Change state of pinned property for given file
        /// </summary>
        /// <param name="path">File full path</param>
        void ChangePinStateForFile(string path);

        /// <summary>
        /// Select given file (MRU item)
        /// </summary>
        /// <param name="path">File full path</param>
        void SelectFile(string path);

    }
}
