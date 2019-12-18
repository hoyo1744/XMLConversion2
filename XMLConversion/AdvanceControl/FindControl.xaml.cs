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
using XMLConversion.BaseControl;
namespace XMLConversion
{
    /// <summary>
    /// FindControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindControl : UserControl
    {
        #region 전역변수
        FindString Source = new FindString();
        public Window Owner;
        #endregion

        public FindControl()
        {
            InitializeComponent();
            SetDataContext();
            Init();


            #region Event
            this.cancelButton.Click += OnCancelButtonClick;
            #endregion
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();
        }

        void Init()
        {
            Source.Text = string.Empty;
            Source.CheckDown = true;
            Source.CheckUp = false;
            Source.CheckSmallAndBig = false;
        }

        void SetDataContext()
        {
            this.MainGrid.DataContext = Source;
        }
        
    }
}
