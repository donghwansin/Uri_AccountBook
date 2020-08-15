using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class.Controller.MVCController;
using System.IO;
using Class.Model.MVCModel;

namespace View.Details
{
    public partial class Details : Form, InterfaceView
    {
        Controller _controller;

        public Details(Controller controller)
        {
            InitializeComponent();

            _controller = controller;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            textBoxDetail.Multiline = true;
            textBoxDetail.MaxLength = 255;

            _controller.FileTextBoxOutput(FilePath, textBoxDetail);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        #region Interface
        public void ClearList()
        {
            return;
        }

        public string Date
        {
            get { return textBoxDate.Text; }
            set { textBoxDate.Text = value; }
        }
        
        public string UseCash
        {
            get { return textBoxUseCash.Text; }
            set { textBoxUseCash.Text = value; }
        }
        
        public string SaveCash
        {
            get { return textBoxSaveCash.Text; }
            set { textBoxSaveCash.Text = value; }
        }

        private string _filepath;
        public string FilePath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }

        private string _directorypath;
        public string DirectoryPath
        {
            get { return _directorypath; }
            set { _directorypath = value; }
        }

        private DataGridView _ngrid;
        public DataGridView nGrid
        {
            get { return _ngrid; }
            set { _ngrid = value; }
        }
        #endregion

        #region Button Event
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("저장하시겠습니까 ?", "Save Button Click", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            _controller.DirectoryCreate(DirectoryPath);

            _controller.FileClear(FilePath);
            _controller.FileWrite(FilePath, textBoxDetail.Text);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
