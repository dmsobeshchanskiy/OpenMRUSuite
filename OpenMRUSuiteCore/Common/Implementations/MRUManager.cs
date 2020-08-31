using OpenMRUSuiteCore.Common.Interfaces;
using OpenMRUSuiteCore.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMRUSuiteCore.Common.Implementations
{
    public class MRUManager : IMRUManager
    {
        public List<MRUItem> MRUItems { get; private set; }

        public event Action MRUItemsListChanged;
        public event Action<string> MRUItemSelected;

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

        public void SelectFile(string path)
        {
            if (PerformSelectItem(path))
            {
                MRUItemSelected?.Invoke(path);
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
