using OpenMRU.Core.Common.Interfaces;
using OpenMRU.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenMRU.Core.Common.Implementations
{
    /// <summary>
    /// Default MRU items manager implementation
    /// </summary>
    public class MRUManager : IMRUManager
    {
        /// <summary>
        /// Currently available MRU items (readed from storage)
        /// </summary>
        public List<MRUItem> MRUItems { get; private set; }

        /// <summary>
        /// This event fires each time when MRU items are changed 
        /// (i.e. added, removed, cleared, modified (pinned/unpinned), etc)
        /// </summary>
        public event Action MRUItemsListChanged;

        /// <summary>
        /// This event fires each time when MRU item is selected
        /// </summary>
        public event Action<string> MRUItemSelected;

        /// <summary>
        /// Add file to tracking as MRU item
        /// </summary>
        /// <param name="path">File full path</param>
        public void AddFile(string path)
        {
            MRUItem existedItem = MRUItems.FirstOrDefault(item => item.FilePath == path);
            if (existedItem == null)
            {
                MRUItem item = new MRUItem()
                {
                    FilePath = path,
                    LastAccessedDate = DateTime.Now,
                    Pinned = false,
                    SelectedCount = 1
                };
                MRUItems.Add(item);
                UpdateMRUItems();
            }
            else
            {
                PerformSelectItem(path);
            }
        }

        /// <summary>
        /// Select given file (MRU item)
        /// </summary>
        /// <param name="path">File full path</param>
        public void SelectFile(string path)
        {
            if (PerformSelectItem(path))
            {
                MRUItemSelected?.Invoke(path);
            }
        }

        /// <summary>
        /// Change state of pinned property for given file
        /// </summary>
        /// <param name="path">File full path</param>
        public void ChangePinStateForFile(string path)
        {
            MRUItem existedItem = MRUItems.FirstOrDefault(item => item.FilePath == path);
            if (existedItem != null)
            {
                existedItem.Pinned = !existedItem.Pinned;
                UpdateMRUItems();
            }
        }

        /// <summary>
        /// Remove given file from MRU items 
        /// </summary>
        /// <param name="path">File full path</param>
        public void RemoveFile(string path)
        {
            MRUItem existedItem = MRUItems.FirstOrDefault(item => item.FilePath == path);
            if (existedItem != null)
            {
                MRUItems = MRUItems.Where(item => item.FilePath != path).ToList();
                UpdateMRUItems();
            }
        }

        /// <summary>
        /// Clear MRU storage (remove all items)
        /// </summary>
        public void ClearMRUItems()
        {
            MRUItems = new List<MRUItem>();
            UpdateMRUItems();
        }

        /// <summary>
        /// Initializes manager with given MRU storage
        /// </summary>
        /// <param name="storage">MRU items storage implementation</param>
        public void Initialize(IMRUItemStorage storage)
        {
            this.storage = storage;
            ReadMRUItem();
        }

        private IMRUItemStorage storage;

        private bool PerformSelectItem(string path)
        {
            bool response = false;
            MRUItem existedItem = MRUItems.FirstOrDefault(item => item.FilePath == path);
            if (existedItem != null)
            {
                existedItem.SelectedCount++;
                existedItem.LastAccessedDate = DateTime.Now;
                UpdateMRUItems();
                response = true;
            }
            return response;
        }

        private void UpdateMRUItems()
        {
            storage.SaveMRUItems(MRUItems);
            ReadMRUItem();
        }

        private void ReadMRUItem()
        {
            MRUItems = storage.ReadMRUItems() as List<MRUItem>;
            MRUItemsListChanged?.Invoke();
        }
    }
}
