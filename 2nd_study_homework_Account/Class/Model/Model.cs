using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// 날짜, 사용금액, 저축금액 정보를 get, set 가능해야한다.
/// </summary>
namespace Class.Model.MVCModel
{
    public class Models
    {
        public Models()
        {

        }

        string _date;
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

        string _filepath;
        public string FilePath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }

        string _derectorypath;
        public string DirectoryPath
        {
            get { return _derectorypath; }
            set { _derectorypath = value; }
        }

        DataGridView _ngrid;
        public DataGridView nGrid
        {
            get { return _ngrid; }
            set { _ngrid = value; }
        }
    }
}
