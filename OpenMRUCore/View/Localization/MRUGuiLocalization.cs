
namespace OpenMRU.Core.View.Localization
{
    public class MRUGuiLocalization
    {
        /// <summary>
        /// Label for control caption
        /// Default value is [Recent files]
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// Label for clear list button
        /// Default value is [Clear list]
        /// </summary>
        public string ClearAllLabel { get; set; }
        /// <summary>
        /// Label before pinned items list
        /// Default value is [Pinned items]
        /// </summary>
        public string PinnedItemsLabel { get; set; }
        /// <summary>
        /// Label before other items list
        /// Default value is [Other items]
        /// </summary>
        public string OtherItemsLabel { get; set; }
        /// <summary>
        /// Label to show if there are no MRU items
        /// Default value is [No recent items]
        /// </summary>
        public string NoRecentItemsLabel { get; set; }
        /// <summary>
        /// Caption for action confirmation dialog
        /// Default value is [Confirm action]
        /// </summary>
        public string ConfirmActionDialogCaption { get; set; }
        /// <summary>
        /// Localization for MRU item control
        /// </summary>
        public MRUGuiItemLocalization ItemLocalization { get; set; }
        /// <summary>
        /// Localization for MRU messages
        /// </summary>
        public MRUMessages Messages { get; set; }

        public MRUGuiLocalization()
        {
            Caption = "Recent files";
            ClearAllLabel = "Clear list";
            PinnedItemsLabel = "Pinned items";
            OtherItemsLabel = "Other items";
            NoRecentItemsLabel = "No recent items";
            ConfirmActionDialogCaption = "Confirm action";
            ItemLocalization = new MRUGuiItemLocalization();
            Messages = new MRUMessages();
        }
    }
}
