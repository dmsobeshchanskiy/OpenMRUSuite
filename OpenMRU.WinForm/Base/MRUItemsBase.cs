using OpenMRU.Core.Common.Interfaces;
using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.Core.View.Localization;
using OpenMRU.Core.View.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OpenMRU.WinForm.Base
{
    /// <summary>
    /// Base class for MRU items controls
    /// </summary>
    public abstract class MRUItemsBase: UserControl, IMRUItemsView
    {
        /// <summary>
        /// This event is fired each time when clear MRU items requested
        /// </summary>
        public event Action ClearMRUItemsRequested;

        /// <summary>
        /// List of MRU item 'views'.
        /// </summary>
        public List<IMRUItemView> ItemViews { get; protected set; }

        /// <summary>
        /// Init control: reads MRU items and shows them on 'view'
        /// </summary>
        /// <param name="manager">IMRUManager implementation instance</param>
        /// <param name="localization">localization instance</param>
        public virtual void Initialize(IMRUManager manager, MRUGuiLocalization localization)
        {
            this.localization = localization;
            logic = new MRUGuiLogic(this, manager, localization);
        }

        /// <summary>
        /// Asks user is certain action allowed or not
        /// </summary>
        /// <param name="actionDescription"></param>
        /// <returns></returns>
        public virtual bool IsActionAllowed(string actionDescription)
        {
            return MessageBox.Show(actionDescription, localization.ConfirmActionDialogCaption, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        /// <summary>
        /// Show MRU item containers on view
        /// </summary>
        /// <param name="containers"></param>
        public virtual void ShowMRUItems(List<MRUItemsContainer> containers)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Invoke 'Clear MRU items' event
        /// </summary>
        protected void InvokeMRUItemsClearing()
        {
            ClearMRUItemsRequested?.Invoke();
        }

        /// <summary>
        /// localization
        /// </summary>
        protected MRUGuiLocalization localization;

        /// <summary>
        /// logic
        /// </summary>
        protected MRUGuiLogic logic;
    }
}
