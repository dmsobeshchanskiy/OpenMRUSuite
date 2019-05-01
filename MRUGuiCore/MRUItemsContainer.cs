using MRUCore.Interfaces;
using System.Collections.Generic;

namespace MRUGuiCore
{
    public class MRUItemsContainer
    {
        public string ContainerCaption { get; set; }
        public IEnumerable<IMRUItem> Items { get; set; }
    }
}
