using System;
using System.Reactive;
using System.Windows;
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
            if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Pressed)
            {
                var position = e.GetPosition(sender as Window);
                MessageBox.Show(x.ToString());
                
                // Todo: 검색 기능 있는 새 노드 만드는 창
                // ex>
                var addNode = new NodeViewModel {Name = "TestNode"};
                network.Nodes.Add(addNode);

                var addNodeInput = new NodeInputViewModel {Name = "Node 1 input"};
                addNode.Inputs.Add(addNodeInput);

                var addNodeOutput = new NodeOutputViewModel {Name = "Node 2 output"};
                addNode.Outputs.Add(addNodeOutput);

            }
        }
    }
}