using System.Collections.Generic;

namespace MRUCore.Interfaces
{
    public interface IMRUItemStorage
    {
        IEnumerable<MRUItem> ReadMRUItems();
        void SaveMRUItems(IEnumerable<MRUItem> items);
    }
}
