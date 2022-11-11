using Analyzer.Info;
using System.Collections.Generic;
using System.ComponentModel;
using Analyzer.Core;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows.Documents;

namespace WPF
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
    
    public class AssemblyViewModel : ViewModelBase
    {
        private AnalyzeResult _result;

        public AnalyzeResult Result
        {
            get { return _result; }
            set { _result = value; OnPropertyChanged("Result"); }
        }

        public AssemblyViewModel(AnalyzeResult result)
        {
            _result = result;
        }
    }

    public class MainWindowViewModel : ViewModelBase
    {
        private List<AssemblyViewModel> _assemblyList;

        public List<AssemblyViewModel> AssemblyList
        {
            get { return _assemblyList; }
            set { _assemblyList = value; OnPropertyChanged("AssemblyList"); }
        }

        public ICommand ButtonClickCommand => new OnClickCommand(OpenFile);

        public MainWindowViewModel()
        {
            _assemblyList = new List<AssemblyViewModel>();
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Assemblies|*.dll;*.exe",
                Title = "Select assembly",
                Multiselect = false
            };
            var isOpen = openFileDialog.ShowDialog();
            if (isOpen != null && isOpen.Value)
            {
                AssemblyList = new List<AssemblyViewModel>(AssemblyList)
                {
                    new AssemblyViewModel(AssemblyAnalyzer.Analyze(openFileDialog.FileName))
                };
            }
            else
            {
                System.Windows.MessageBox.Show("Error while processing selected assembly");
            }
        }
    }
}
