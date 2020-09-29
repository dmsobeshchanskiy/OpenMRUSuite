using OpenMRU.Core.Common.Interfaces;
using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.Core.View.Localization;
using OpenMRU.Core.View.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OpenMRU.WinForm
{
    public abstract class MRUItemsBase : IMRUItemsView
    {
        public event Action ClearMRUItemsRequested;

        public List<IMRUItemView> ItemViews { get; protected set; }

        
        public virtual void Initialize(IMRUManager manager, MRUGuiLocalization localization)
        {
            this.localization = localization;
            logic = new MRUGuiLogic(this, manager, localization);
        }

        public virtual bool IsActionAllowed(string actionDescription)
        {
            return MessageBox.Show(actionDescription, localization.ConfirmActionDialogCaption, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        public virtual void ShowMRUItems(List<MRUItemsContainer> containers)
        {
            throw new NotImplementedException();
        }

        protected MRUGuiLocalization localization;
        protected MRUGuiLogic logic;
    }
}
