using NodeNetwork.ViewModels;

namespace NodeEditor_PdxEventChain_Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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