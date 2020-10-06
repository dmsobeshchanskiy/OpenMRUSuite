# OpenMRUSuite
Kit for adding Most Recently Used (MRU) files functionality into your .Net applications.

![GUI component](/Media/demo.png)


Currently OpenMRUSuite consists from two projects: OpenMRU.Core and OpenMRU.WinForm.

# OpenMRU.Core
OpenMRU.Core serves as a base for "MRU (Most resently used) files" functionality. It contains interfaces and their default implementations for to management of MRU items, interfaces for GUI part and logic that works with this GUI's interface.

## MRU GUI controls

Easiest way to add MRU functionality to you software is to use OpenMRU package corresponding to your GUI Framework (For example, use OpenMRU.WinForm for software, that uses WinForm for GUI part).

## Quick start with Core

If there is no OpenMRU GUI package suitable for you or you want your own GUI/Core part implementation, than next 3 steps should be done:

1. Create 2 GUI controls: 
 - control for single MRU item presentation and implement OpenMRU.Core.View.Interfaces.IMRUItemView by this control and 
 - control for MRU items list presentation and implement OpenMRU.Core.View.Interfaces.IMRUItemsView by this control.

2. (Optionally) Provide own implementations for interfaces from OpenMRU.Core.Common.Interfaces namespace: IMRUItemStorage and IMRUManager. 

OpenMRU.Core provides default implementations for these interfaces that are located in OpenMRU.Core.Common.Implementations namespace: MRUItemFileStorage and MRUManager. 
MRUManager is responsible for management of MRU items and uses IMRUItemStorage implementation for to write / read MRU items.  MRUItemFileStorage is responsible for saving MRU items and uses XML file for it.
So, if you want to use another way of storing MRU items (for exmaple, in DB), or provide own logic for MRU items management - you can provide own implementation (s) of corresponding interfaces and use them with OpenMRUSuite.


3. Add control (IMRUItemsView implementation from step 1) to your application GUI and bind it to OpenMRU.Core.View.LogicMRUGuiLogic. For doing this you should create LogicMRUGuiLogic instance passing next parameters to its constructor: 
- IMRUItemsView implementation (control that was just added); 
- IMRUManger implementation (default or your own)
- MRUGuiLocalization class instance from OpenMRU.Core.View.Localization namespace. You can just create instance of this class by calling constructor without parameters for default english localization. Or create instance of localization class and assign localized values to corresponding properties of this class.

For to react on MRU item selection by user in your code, subscribe to  'MRUItemSelected' event of the same instance of MRUManager that was used while GUI creation. That is, in your logic you do not have to have a link to GUI control, just link to manager, which allows you to react on MRU selection from all GUI controls, that initialized with the same manager. (Please see example in 'Quick start with OpenMRU.WinForm' section)


# OpenMRU.WinForm

OpenMRU.WinForm contains WinForm GUI controls for "MRU (Most resently used) files" functionality. (Both menu-like control and control similar to one on VisualStudio start window)


## Quick start with OpenMRU.WinForm

For to use controls from package, add them to your Toolbox palette by reference this package, then drag-and-drop MRUItemsControl to your form and initialize it with manager and localization.

For to use menu-like control, create ToolStripMenuItem item using visual editor, create MRUItemsMenu instance and initialize it with manager and localization. After that, attach MRUItemsMenu instance to certain ToolStripMenuItem item.

See code below for details (consider you have a form 'Form1', MRUItemsControl 'mruItemsControl1', Button 'ButtonOpen' and two ToolStripMenuItems 'recentFilesToolStripMenuItem' and 'recentcustomToolStripMenuItem' on it):

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

            // init menu items
            MRUItemsMenu itemsMenu = new MRUItemsMenu();
            itemsMenu.Initialize(manager, new MRUGuiLocalization());
            itemsMenu.AttachToMenu(recentFilesToolStripMenuItem);


            // init menu items - custom appearance
            MRUItemsMenu itemsMenu2 = new MRUItemsMenu();
            itemsMenu2.Initialize(manager, new MRUGuiLocalization());
            itemsMenu2.AttachToMenu(recentcustomToolStripMenuItem, "%FileName% - [%Path%] - [%AccessDate%]");
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



# Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

# License
MIT
