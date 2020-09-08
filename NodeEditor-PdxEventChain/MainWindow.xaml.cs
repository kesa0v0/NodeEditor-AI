using System;
using System.Windows.Threading;
using System.Xml;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using NodeEditor_PdxEventChain_Main.HighlightSyntax;
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

            CodeEditor.SyntaxHighlighting =
                ResourceLoader.LoadHighlightingDefinition("PdxSyntax.xshd");
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