using OpenMRUSuiteCore.Common.Models;
using System.Collections.Generic;


namespace OpenMRUSuiteCore.Common.Interfaces
{
    public interface IMRUItemStorage
    {
        IEnumerable<MRUItem> ReadMRUItems();
        void SaveMRUItems(IEnumerable<MRUItem> items);
    }
}
