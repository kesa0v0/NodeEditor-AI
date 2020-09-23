using System;
using System.Windows.Input;
using System.Windows.Threading;
using DynamicData;
using ICSharpCode.AvalonEdit.Folding;
using NodeEditor_PdxEventChain_Main.HighlightSyntax;
using NodeNetwork.ViewModels;

namespace NodeEditor_PdxEventChain_Main
{
    public partial class MainWindow
    {
        private NetworkViewModel network;
        
        public MainWindow()
        {
            InitializeComponent();
            
            // NodeEditor
            
            network = new NetworkViewModel();
            NetworkView.ViewModel = network;

            
            
            // CodeEditor
            DispatcherTimer foldingUpdateTimer = new DispatcherTimer();
            foldingUpdateTimer.Interval = TimeSpan.FromSeconds(foldingDuration);
            foldingUpdateTimer.Tick += delegate { UpdateFoldings(); };
            foldingUpdateTimer.Start();

            foldingManager = FoldingManager.Install(CodeEditor.TextArea);
            foldingStrategy = new XmlFoldingStrategy();

            CodeEditor.SyntaxHighlighting =
                ResourceLoader.LoadHighlightingDefinition("PdxSyntax.xshd");
            
            
        }

        public void AddSomething()
        {
            var node1 = new NodeViewModel();
            node1.Name = "Test";
            
            network.Nodes.Add(node1);
        }

        #region Folding

        private FoldingManager foldingManager;
        private XmlFoldingStrategy foldingStrategy;
        private double foldingDuration = 0.5;
        
        void UpdateFoldings()
        {
            foldingStrategy.UpdateFoldings(foldingManager, CodeEditor.Document);
        }
        #endregion

        private void NetworkViewMouseWheelDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}