
namespace OpenMRU.Core.View.Localization
{
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

        public MRUMessages()
        {
            AllowDeleteItem = "This action will delete item from list. Continue?";
            AllowClearList = "This action will delete all items from list. Continue?";
        }
    }
}
