using System;
using System.Windows.Threading;
using ICSharpCode.AvalonEdit.Folding;
using NodeNetwork.ViewModels;

namespace NodeEditor_PdxEventChain_Main
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Console.Write(@"test!");

            var network = new NetworkViewModel();
            NetworkView.ViewModel = network;

            DispatcherTimer foldingUpdateTimer = new DispatcherTimer();
            foldingUpdateTimer.Interval = TimeSpan.FromSeconds(foldingDuration);
            foldingUpdateTimer.Tick += delegate { UpdateFoldings(); };
            foldingUpdateTimer.Start();

            foldingManager = FoldingManager.Install(CodeEditor.TextArea);
            foldingStrategy = new XmlFoldingStrategy();
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
    }
}