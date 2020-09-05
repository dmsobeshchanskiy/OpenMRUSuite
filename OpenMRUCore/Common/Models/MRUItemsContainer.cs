using System.Collections.Generic;

namespace OpenMRU.Core.Common.Models
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
        public IEnumerable<MRUItem> Items { get; set; }
    }
}
