using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OAuthTester.Engine;
using OAuthTester.ViewModels.Dialogue;

namespace OAuthTester.Dialogues
{
    /// <summary>
    /// Interaction logic for ClientEditorWindow.xaml
    /// </summary>
    public partial class ClientEditorWindow : Window
    {
        public ClientEditorWindow(ClientEditorWindowViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        public ClientConfiguration? ClientConfiguration { get; set; } = null;

        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
