namespace MRUGuiCore
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

        public MRUGuiLocalization ()
        {
            Caption = "Recent files";
            ClearAllLabel = "Clear list";
            PinnedItemsLabel = "Pinned items";
            OtherItemsLabel = "Other items";
            ConfirmActionDialogCaption = "Confirm action";
            ItemLocalization = new MRUGuiItemLocalization();
            Messages = new MRUMessages();
        }
    }

    public class MRUGuiItemLocalization
    {
        /// <summary>
        /// Label for 'pin' functionality
        /// Default value is [Pin item]
        /// </summary>
        public string PinItemLabel { get; set; }
        /// <summary>
        /// Label for 'delete item' functionality
        /// Default value is [Delete item from list]
        /// </summary>
        public string DeleteItemLabel { get; set; }

        public MRUGuiItemLocalization ()
        {
            PinItemLabel = "Pin item";
            DeleteItemLabel = "Delete item from list";
        }
    }

    public class MRUMessages
    {
        /// <summary>
        /// Confirmation message for item deleting
        /// Default value is [This action will delete item from list. Continue?]
        /// </summary>
        public string AllowDeleteItem { get; set; }
        /// <summary>
        /// Confirmation message for items clearing
        /// Default value is [This action will delete all items from list. Continue?]
        /// </summary>
        public string AllowClearList { get; set; }

        public MRUMessages ()
        {
            AllowDeleteItem = "This action will delete item from list. Continue?";
            AllowClearList = "This action will delete all items from list. Continue?";
        }
    }
}
