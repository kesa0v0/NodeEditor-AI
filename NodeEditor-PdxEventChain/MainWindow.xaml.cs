using NodeNetwork.ViewModels;

namespace NodeEditor_PdxEventChain_Main
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var network = new NetworkViewModel();
            NetworkView.ViewModel = network;
        }
    }
}