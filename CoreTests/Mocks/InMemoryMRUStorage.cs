using OpenMRU.Core.Common.Interfaces;
using OpenMRU.Core.Common.Models;
using System.Collections.Generic;

namespace CoreTests.Mocks
{
    public class InMemoryMRUStorage : IMRUItemStorage
    {
        public IEnumerable<MRUItem> ReadMRUItems()
        {
            return items;
        }

        public void SaveMRUItems(IEnumerable<MRUItem> items)
        {
            this.items = items as List<MRUItem>;
        }

        public InMemoryMRUStorage(List<MRUItem> initialItems)
        {
            items = initialItems;
        }

        private List<MRUItem> items;
    }
}
