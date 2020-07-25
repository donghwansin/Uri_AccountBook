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
using Class.Model.MVCModel;

namespace View.AccoutBook
{
    public partial class AccountBook : Form, InterfaceView
    {
        Controller _controller;
        Models _model;

        public AccountBook()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        #region Interface
        public void SetController(Controller controller)
        {
            _controller = controller;
        }

        public void SetModel(Models model)
        {
            _model = model;
        }

        public void ClearList()
        {
            dataGridView1.Rows.Clear();
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string FilePath
        {
            get { return textBoxFilePath.Text; }
            set { textBoxFilePath.Text = value; }
        }

        private string _directorypath;
        public string DirectoryPath
        {
            get { return _directorypath; }
            set { _directorypath = value; }
        }

        public DataGridView nGrid
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }
        #endregion

        #region Mouse Event
        private void textBoxFilePath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _controller.SaveFileSelect();
        }
        #endregion

        #region button event
        private void buttonSave_Click(object sender, EventArgs e)
        {
            _controller.SaveModel();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region grid event
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _controller.DetailCellClick(e);
        }
        #endregion
    }
}
