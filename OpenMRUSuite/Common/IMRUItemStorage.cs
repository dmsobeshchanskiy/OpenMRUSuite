using System.Collections.Generic;

namespace OpenMRUSuite.Common
{
    public interface IMRUItemStorage
    {
        List<MRUItem> ReadMRUItems();
        void SaveMRUItems(List<MRUItem> items);
    }
}
