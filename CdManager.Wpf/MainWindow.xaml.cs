
using CdManager.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CdManager.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Cd> _cds { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Repository repository = Repository.GetInstance();
            _cds = repository.GetAllCds();
            lbxCds.ItemsSource = _cds;

            btnNew.Click += BtnNew_Click;
            btnDelete.Click += BtnDelete_Click;
            btnEdit.Click += BtnEdit_Click;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Cd selectedCd = lbxCds.SelectedItem as Cd;
            if (selectedCd == null)
            {
                MessageBox.Show("Sie müssen eine Cd auswählen!");
            }
            else
            {
                AddCdWindow addCdWindow = new AddCdWindow(selectedCd);
                addCdWindow.ShowDialog();
            }

            _cds = Repository.GetInstance().GetAllCds();
            lbxCds.ItemsSource = _cds;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Cd selectedCd = lbxCds.SelectedItem as Cd;
            if (selectedCd == null)
            {
                MessageBox.Show("Sie müssen eine Cd auswählen!");
            }

            Repository.GetInstance().RemoveCd(selectedCd);

            _cds = Repository.GetInstance().GetAllCds();
            lbxCds.ItemsSource = _cds;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            AddCdWindow addCdWindow = new AddCdWindow();
            addCdWindow.ShowDialog();

            _cds = Repository.GetInstance().GetAllCds();
            lbxCds.ItemsSource = _cds;
        }
    }
}