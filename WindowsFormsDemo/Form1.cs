using MRUCore.Manager;
using MRUCore.Storage;
using MRUGuiCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDemo
{
    public partial class Form1 : Form
    {
        private MRUManager manager;
        public Form1()
        {
            InitializeComponent();
            MRUItemFileStorage storage = new MRUItemFileStorage("demo_mru_storage.xml");
            manager = new MRUManager();
            manager.Initialize(storage);
            mruItemsControl1.Initialize(manager, new MRUGuiLocalization());
        }

        private void buttonOpen_Click(object sender, EventArgs e)
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
