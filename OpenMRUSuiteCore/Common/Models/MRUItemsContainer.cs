using OpenMRUSuiteCore.Common.Interfaces;
using System.Collections.Generic;

namespace OpenMRUSuiteCore.Common.Models
{
    public class MRUItemsContainer
    {
        public string ContainerCaption { get; set; }
        public IEnumerable<IMRUItem> Items { get; set; }
    }
}
