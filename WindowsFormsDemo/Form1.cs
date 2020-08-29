using MRUCore.Manager;
using MRUCore.Storage;
using MRUGuiCore;
using System;
using System.Windows.Forms;

namespace WindowsFormsDemo
{
    public partial class Form1 : Form
    {
        private readonly MRUManager manager;
        public Form1()
        {
            InitializeComponent();
            MRUItemFileStorage storage = new MRUItemFileStorage("demo_mru_storage.xml");
            manager = new MRUManager();
            manager.Initialize(storage);
            manager.MRUItemSelected += Manager_MRUItemSelected;
            mruItemsControl1.Initialize(manager, new MRUGuiLocalization());
        }

        private void Manager_MRUItemSelected(string path)
        {
            MessageBox.Show("Select file from MRU: " + path);
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                manager.AddFile(path);
            }

        }
    }
}
