﻿using System;
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

namespace View.Details
{
    public partial class Details : Form, InterfaceView
    {
        Controller _controller;
        Models _model;

        public Details()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            textBoxDetail.Multiline = true;
            textBoxDetail.MaxLength = 255;

            textBoxDate.Text = _model.Date;

            _controller.FileTextBoxOutput(_model.FilePath, textBoxDetail);
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
            return;
        }

        public string Date
        {
            get { return textBoxDate.Text; }
            set { textBoxDate.Text = value; }
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
            _controller.DirectoryCreate(_model.DirectoryPath);

            _controller.FileClear(_model.FilePath);
            _controller.FileWrite(_model.FilePath, textBoxDetail.Text);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}