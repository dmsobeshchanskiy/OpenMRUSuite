using MRUCore.Interfaces;
using System;
using System.Collections.Generic;

namespace MRUCore.Manager
{
    public class MRUManager : IMRUManager
    {
        public List<MRUItem> MRUItems => throw new NotImplementedException();

        public event Action<List<MRUItem>> MRUItemsListChanged;

        public void AddFile(string path)
        {
            throw new NotImplementedException();
        }

        public void ChangePinStateForFile(string path)
        {
            throw new NotImplementedException();
        }

        public void ClearMRUItems()
        {
            throw new NotImplementedException();
        }

        public void Initialize(IMRUItemStorage storage)
        {
            throw new NotImplementedException();
        }

        public void RemoveFile(string path)
        {
            throw new NotImplementedException();
        }

        public void SelectFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}
