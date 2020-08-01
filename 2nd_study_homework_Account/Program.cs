using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Class.Controller.MVCController;
using Class.Model.MVCModel;
using View.AccoutBook;

namespace _2nd_study_homework_Account
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AccountBook());
            
            //Models model = new Models();
            //AccountBook view = new AccountBook();
            //Controller controller = new Controller(view, model);
            //Application.Run(view);
        }
    }
}
