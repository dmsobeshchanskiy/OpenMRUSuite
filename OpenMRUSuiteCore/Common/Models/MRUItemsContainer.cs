using OpenMRUSuiteCore.Common.Interfaces;
using System.Collections.Generic;

namespace OpenMRUSuiteCore.Common.Models
{
    /// <summary>
    /// Represents a group of MRU items
    /// </summary>
    public class MRUItemsContainer
    {
        /// <summary>
        /// Caption of this MRU items group
        /// </summary>
        public string ContainerCaption { get; set; }

        /// <summary>
        /// MRU items of this group
        /// </summary>
        public IEnumerable<IMRUItem> Items { get; set; }
    }
}
