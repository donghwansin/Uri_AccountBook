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
using System.Threading;

namespace View.AccoutBook
{
    public partial class AccountBook : Form, InterfaceView
    {
        Controller _controller;
        Thread _thread = null;

        public AccountBook()
        {
            InitializeComponent();
            
            Controller controller = new Controller(this);

            _controller = controller;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _thread.Abort();
        }

        #region Interface
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

        private string _usecash;
        public string UseCash
        {
            get { return _usecash; }
            set { _usecash = value; }
        }

        private string _savecash;
        public string SaveCash
        {
            get { return _savecash; }
            set { _savecash = value; }
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
            if (_controller.SaveFileSelect())
            {
                fThreadStart();
            }
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

        public void fThreadStart()
        {
            try
            {
                _thread = new Thread(ThreadProc);
                _thread.Start();
            }
            catch (System.Threading.ThreadStateException)
            {
                _thread.Join();
            }
        }

        public void ThreadProc()
        {
            _controller.ThreadFileCheck(this);
        }
    }
}
