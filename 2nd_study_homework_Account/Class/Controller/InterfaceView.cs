using System.Windows.Forms;
using Class.Model.MVCModel;
/// <summary> View Interface
/// 뷰에는 View Interface와 버튼 및 리스트 뷰 이벤트가 구현되어 있습니다.
/// </summary>
namespace Class.Controller.MVCController
{
    public interface InterfaceView
    {
        void SetController(Controller controller);
        void SetModel(Models model);

        void ClearList();
        
        string Date { get; set; }
        string FilePath { get; set; }
        string DirectoryPath { get; set; }

        DataGridView nGrid { get; set; }
    }
}
