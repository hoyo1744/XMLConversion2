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


namespace XMLConversion
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 전역변수
        Worker worker;
        #endregion


        public MainWindow()
        {
            InitializeComponent();
            CreateWorker();

            
        }

        public void CreateWorker()
        {
            worker = new Worker();
            this.MainGrid.Children.Add(worker);
        }

    }
}
