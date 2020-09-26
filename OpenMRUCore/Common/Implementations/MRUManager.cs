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

        /// <summary>
        /// Set max amount of MRU items to track. Min value is 3
        /// </summary>
        /// <param name="itemsCount">amount of MRU items to track (default value is 10)</param>
        public void SetItemsCountToTrack (int itemsCount)
        {
            itemsMaxCount = itemsCount;
            if (itemsMaxCount < 3)
            {
                itemsMaxCount = 3;
            }
            UpdateMRUItems();
        }

        private IMRUItemStorage storage;
        private int itemsMaxCount = 10;

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
            if (itemsMaxCount < MRUItems.Count())
            {
                MRUItems.Sort((MRUItem i1, MRUItem i2) => 
                {
                    if (i2.Pinned && !i1.Pinned)
                    { 
                        return 1;
                    }
                    else if (!i2.Pinned && i1.Pinned)
                    { 
                        return -1; 
                    }
                    else
                    {
                        return i2.LastAccessedDate.CompareTo(i1.LastAccessedDate);
                    }
                });
            }
            MRUItems = MRUItems.Take(itemsMaxCount).ToList();
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
