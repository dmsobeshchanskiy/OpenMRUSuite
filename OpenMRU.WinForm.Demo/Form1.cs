using OpenMRU.Core.Common.Implementations;
using OpenMRU.Core.View.Localization;
using System;
using System.Windows.Forms;

namespace OpenMRU.WinForm.Demo
{
    public partial class Form1 : Form
    {
        // link to manager.
        private readonly MRUManager manager;

        public Form1()
        {
            InitializeComponent();
            // create IMRUItemStorage implementation using default xml-based storage from OpenMRU.Core
            MRUItemFileStorage storage = new MRUItemFileStorage("demo_mru_storage.xml");
            // create default manager from OpenMRU.Core
            manager = new MRUManager();
            // init manager with storage
            manager.Initialize(storage);
            // subscribe to 'item selected' event
            manager.MRUItemSelected += Manager_MRUItemSelected;
            // init GUI control with created manager and default (eng) localization
            mruItemsControl1.Initialize(manager, new MRUGuiLocalization());
        }

        private void Manager_MRUItemSelected(string path)
        {
            MessageBox.Show("Select file from MRU: " + path);
        }

        // handle open file event
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                // add file that was selected by user to manager (begin track it and display on GUI)
                manager.AddFile(path);
            }

        }
    }
}
