using System;
using System.Windows.Forms;
using MRUGuiCore.ViewInterfaces;
using MRUCore.Interfaces;
using System.IO;

namespace MRUGuiWin
{
    public partial class MRUItemControl : UserControl, IMRUItemView
    {
        public event Action<string> PinItemRequested;
        public event Action<string> DeleteItemRequested;
        public event Action<string> ItemSelected;

        

        public void Initialize(IMRUItem item)
        {
            this.item = item;
            FileInfo fileInfo = new FileInfo(item.FilePath);
            labelFileName.Text = fileInfo.Name;
            labelPath.Text = fileInfo.DirectoryName;
        }

        public MRUItemControl()
        {
            InitializeComponent();
        }

        private IMRUItem item;

        private void MRUItemControl_Click(object sender, EventArgs e)
        {
            ItemSelected?.Invoke(item.FilePath);
        }
    }
}
