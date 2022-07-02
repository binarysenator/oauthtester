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
using OAuthTester.ViewModels.Dialogue;

namespace OAuthTester.Dialogues
{
    /// <summary>
    /// Interaction logic for AuthenticationServerEditorWindow.xaml
    /// </summary>
    public partial class AuthenticationServerEditorWindow : Window
    {
        private AuthenticationServerEditorWindowViewModel? _model;

        public AuthenticationServerEditorWindow(AuthenticationServerEditorWindowViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            InitializeComponent();
            Model = viewModel;
            DataContext = viewModel;
        }

        public AuthenticationServerEditorWindowViewModel Model
        {
            get => _model;
            set
            {
                _model = value;
                DataContext = value;
            }
        }
    }
}
