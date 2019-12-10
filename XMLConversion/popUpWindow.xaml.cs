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
using XMLConversion;


namespace XMLConversion
{
    /// <summary>
    /// FindWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class popUpWindow : Window
    {
        public popUpWindow()
        {
            InitializeComponent();

            #region
            this.Loaded += OnLoaded;
            #endregion
        }

        void OnLoaded(object sender,RoutedEventArgs e)
        {
            FindControl findControl = new FindControl();
            this.MainGrid.Children.Add(findControl);
        }
    }
}
