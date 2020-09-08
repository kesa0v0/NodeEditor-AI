namespace PdxModdingTools_Main
{
    public partial class MainWindow
    {
        NodeEditor_PdxEventChain_Main.MainWindow _stellarisEventManagerForm;
        
        public MainWindow()
        {
            InitializeComponent();
            
            _stellarisEventManagerForm= new NodeEditor_PdxEventChain_Main.MainWindow();
            _stellarisEventManagerForm.Show();
            Close();
        }
    }
}