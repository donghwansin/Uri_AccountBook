using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Class.Model.MVCModel;
using View.AccoutBook;
using View.Details;

/// <summary>
/// 컨트롤러에서는 뷰에 직접적으로 접근하지 않고, View interface에 접근합니다.
/// 물론, interface 없이 직접 접근해도 상관은 없지만 공통점이 많은 뷰를 직접 접근하기 보다는
/// interface에 접근하게 구현하는 것이 코드가 더 간결해집니다.
/// 뷰 인터페이스에는 텍스트 박스에 보여지거나 목록을 지우거나,
/// 버튼이 클릭됐을 때 수행되는 동작들이 기본으로 정의되어 있고,
/// 그 외 몇 가지 기능이 정의되어 있습니다.
/// 
/// 컨트롤러에는 정의한 뷰 인터페이스와 모델을 갖고 있습니다.
/// Model 정보가 View에 넘기거나 View의 정보가 Model로 넘기거나,
/// Model 목록을 업데이트하거나,
/// Model를 추가/삭제하거나 등 모든 기능이 컨트롤러에 구현되어 있습니다.
/// </summary>
namespace Class.Controller.MVCController
{
    public class Controller
    {
        InterfaceView _view = null;
        Models _model = null;

        private string strRowValue = "";

        public Controller(InterfaceView v, Models m)
        {
            _view = v;
            _model = m;
            _view.SetController(this);
            _view.SetModel(_model);
        }
        
        public void SaveFileSelect()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.DefaultExt = "txt";
            dialog.Filter = "텍스트 문서 (*.txt) | *.txt";
            dialog.ShowDialog();
            _model.FilePath = dialog.FileName;

            _view.FilePath = _model.FilePath;
            _view.ClearList();
            FileGridOutput(_view.FilePath, _view.nGrid);
        }

        public void SaveModel()
        {
            if (_view.nGrid.Rows.Count - 1 == 0)
            {
                MessageBox.Show("가계부에 입력된 내용이 없습니다.");
                return;
            }
            
            FileClear(_view.FilePath);

            for (int i = 0; i < _view.nGrid.Rows.Count - 1; i++)
            {
                for (int j = 0; j < _view.nGrid.Columns.Count - 1; j++)
                {
                    strRowValue += _view.nGrid.Rows[i].Cells[j].Value + ",";
                }
                FileWrite(_view.FilePath, strRowValue);
            }
        }

        public void DetailCellClick(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3)
            {
                return;
            }

            if (_view.nGrid.Rows.Count - 1 == 0)
            {
                MessageBox.Show("가계부에 입력된 내용이 없습니다.");
                return;
            }

            int nCount = 0;
            string sp = ".txt";
            string strDetailsDate = "";
            string strDetailsFilePath = "";
            string strDetailsDirectoryPath = "";
            string strFileName = "";
            string strDate = "";

            strDetailsDate += _view.nGrid.Rows[e.RowIndex].Cells[0].Value;

            string[] strTargetDate = strDetailsDate.Split('/');
            foreach (string s in strTargetDate)
            {
                strDate += s;
            }

            string[] nstrDetailsPath = _view.FilePath.Split('\\');
            foreach (string s in nstrDetailsPath)
            {
                nCount++;
            }

            for (int i = 0; i < nCount - 1; i++)
            {
                strDetailsFilePath += nstrDetailsPath[i] + "\\";
            }


            strFileName = nstrDetailsPath[nCount - 1].Substring(0, nstrDetailsPath[nCount - 1].IndexOf(sp));

            strDetailsDirectoryPath += strDetailsFilePath + strFileName;
            strDetailsFilePath = strDetailsDirectoryPath + "\\" + strDate + sp;

            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "Details")
                {
                    openForm.Activate();
                    return;
                }
            }

            Details newForm = new Details();

            _model.Date = strDetailsDate;
            _model.DirectoryPath = strDetailsDirectoryPath;
            _model.FilePath = strDetailsFilePath;

            Controller controller = new Controller(newForm, _model);

            //newForm.StartPosition = FormStartPosition.Manual;
            //newForm.Location = new Point(this.Location.X, this.Location.Y);
            newForm.Show();
        }

        #region 파일 관련 함수
        public void FileWrite(string nFile, string ndata)
        {
            StreamWriter nFileWrite = new StreamWriter(nFile, true);
            nFileWrite.WriteLine(ndata);
            nFileWrite.Close();
        }

        public void FileGridOutput(string nFile, DataGridView nGrid)
        {
            if (File.Exists(nFile))
            {
                StreamReader nFileRead = new StreamReader(nFile);

                while (!nFileRead.EndOfStream)
                {
                    string nLine = nFileRead.ReadLine();
                    string[] nOutData = nLine.Split(',');

                    nGrid.Rows.Add(nOutData[0], nOutData[1], nOutData[2]);
                }
                nFileRead.Close();
            }
            else
            {
                MessageBox.Show("파일을 선택해주세요.");
            }
        }

        public void FileTextBoxOutput(string nFile, TextBox nTextBox)
        {
            if (File.Exists(nFile))
            {
                StreamReader nFileRead = new StreamReader(nFile);
                StringBuilder sb = new StringBuilder();

                while (!nFileRead.EndOfStream)
                {
                    string nLine = nFileRead.ReadLine();
                    sb.AppendLine(nLine);

                    nTextBox.Text = sb.ToString();
                }

                nFileRead.Close();
            }
        }

        public void FileClear(string nFile)
        {
            if (File.Exists(nFile))
            {
                File.Delete(nFile);
            }
        }
        #endregion

        #region 폴더 관련 함수
        public void DirectoryCreate(string nDirectory)
        {
            DirectoryInfo di = new DirectoryInfo(nDirectory);

            if (di.Exists == false)
            {
                di.Create();
            }
        }
        #endregion
    }
}
