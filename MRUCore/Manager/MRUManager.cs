using MRUCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MRUCore.Manager
{
    public class MRUManager : IMRUManager
    {
        public List<MRUItem> MRUItems { get; private set; }

        public event Action<List<MRUItem>> MRUItemsListChanged;

        public void AddFile(string path)
        {
            MRUItem existedItem = MRUItems.FirstOrDefault(item => item.FilePath == path);
            if (existedItem == null)
            {
                MRUItem item = new MRUItem()
                {
                    FilePath = path,
                    LastAccessedDate = new DateTime(),
                    Pinned = false,
                    SelectedCount = 1
                };
                MRUItems.Add(item);
                UpdateMRUItems();
            }
            else
            {
                SelectFile(path);
            }
        }

        public void SelectFile(string path)
        {
            MRUItem existedItem = MRUItems.FirstOrDefault(item => item.FilePath == path);
            if (existedItem != null)
            {
                existedItem.SelectedCount++;
                existedItem.LastAccessedDate = new DateTime();
                UpdateMRUItems();
            }
        }

        public void ChangePinStateForFile(string path)
        {
            MRUItem existedItem = MRUItems.FirstOrDefault(item => item.FilePath == path);
            if (existedItem != null)
            {
                existedItem.Pinned = !existedItem.Pinned;
                UpdateMRUItems();
            }
        }

        public void RemoveFile(string path)
        {
            MRUItem existedItem = MRUItems.FirstOrDefault(item => item.FilePath == path);
            if (existedItem != null)
            {
                MRUItems = MRUItems.Where(item => item.FilePath != path).ToList();
                UpdateMRUItems();
            }
        }

        public void ClearMRUItems()
        {
            MRUItems = new List<MRUItem>();
            UpdateMRUItems();
        }

        public void Initialize(IMRUItemStorage storage)
        {
            this.storage = storage;
            ReadMRUItem();
        }

        private IMRUItemStorage storage;

        private void UpdateMRUItems ()
        {
            storage.SaveMRUItems(MRUItems);
            ReadMRUItem();
        }

        private void ReadMRUItem ()
        {
            MRUItems = storage.ReadMRUItems() as List<MRUItem>;
            MRUItemsListChanged?.Invoke(MRUItems);
        }
    }
}
