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
        // 아래의 생성자는 사용하지 않음
        public popUpWindow()
        {
            InitializeComponent();

            #region Event
            this.KeyDown += OnPopUpWindowKeyDown;
            #endregion
        }

    
        public popUpWindow(Control obj)
        {
            InitializeComponent();

            #region Event
            this.KeyDown += OnPopUpWindowKeyDown;
            #endregion
            
            this.MainGrid.Children.Add(obj);
        }
        void OnPopUpWindowKeyDown(object sender,KeyEventArgs e)
        {
            if(e.Key==Key.Escape)
                this.Close();
        }


    }
}
