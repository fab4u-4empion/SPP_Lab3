using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Analyzer.Core;
using Analyzer.Info;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private TreeViewItem CreateTreeViewItem(string imagePath, string text)
        {
            StackPanel stackPanel = new() { Orientation = Orientation.Horizontal };

            stackPanel.Children.Add(new Image()
            {
                Width = 16,
                Height = 16,
                Margin = new Thickness(0, 0, 5, 0),
                Source = new BitmapImage(new Uri(imagePath))
            });

            stackPanel.Children.Add(new TextBlock() { Text = text });

            return new TreeViewItem()
            {
                Header = stackPanel,
                Margin = new Thickness(0, 5, 0, 0),
                Focusable = false
            };
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            /*AssemblyAnalyzer analyzer = new();
            AnalyzeResult result = analyzer.Analyze("D:\\БГУИР\\5 семестр\\СПП\\Лаба2\\Lab1\\Faker\\bin\\Release\\net6.0\\Faker.dll");

            TreeViewItem root = CreateTreeViewItem("D:\\БГУИР\\5 семестр\\СПП\\Лаба3\\gear.png", result.AssemblyName);

            foreach (NamespaceInfo nsp in result.Namespaces)
            {
                TreeViewItem namespaceItem = CreateTreeViewItem("D:\\БГУИР\\5 семестр\\СПП\\Лаба3\\archive.png", nsp.Name);

                foreach (TypeInfo type in nsp.Types)
                {
                    namespaceItem.Items.Add(CreateTreeViewItem("D:\\БГУИР\\5 семестр\\СПП\\Лаба3\\font.png", type.Name));
                }

                root.Items.Add(namespaceItem);
            }

            _treeView.Items.Add(root);*/
        }
    }
}
