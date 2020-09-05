

namespace OpenMRU.Core.View.Localization
{
    public class MRUGuiItemLocalization
    {
        /// <summary>
        /// Label for 'pin' functionality
        /// Default value is [Pin item]
        /// </summary>
        public string PinItemLabel { get; set; }
        /// <summary>
        /// Label for 'unpin' functionality
        /// Default value is [Unpin item]
        /// </summary>
        public string UnpinItemLabel { get; set; }
        /// <summary>
        /// Label for 'delete item' functionality
        /// Default value is [Delete item from list]
        /// </summary>
        public string DeleteItemLabel { get; set; }

        public MRUGuiItemLocalization()
        {
            PinItemLabel = "Pin item";
            UnpinItemLabel = "Unpin item";
            DeleteItemLabel = "Delete item from list";
        }
    }
}
