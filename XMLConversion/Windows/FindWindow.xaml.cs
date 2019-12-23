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

namespace XMLConversion.Windows
{
    /// <summary>
    /// FindWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindWindow : Window
    {

        #region 전역변수
       
        public Window ParentOwner;
        static FindWindow instance = null;

        public static FindWindow Instance
        {
            get
            {
                if (instance == null)
                    instance = new FindWindow();

                return instance;
            }

        }
        #endregion
        public FindWindow()
        {
            InitializeComponent();
            instance = this;
            #region Event
            Instance.KeyDown += OnFindWindowKeyDown;
            Instance.findControl.cancelButton.Click += OnCancelButtonClick;
            Instance.Loaded += OnLoaded;
            Instance.Closed += OnClose;
            #endregion

            
        }

        private void OnClose(object sender, EventArgs e)
        {
            instance = null;
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            Instance.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void Init()
        {
            Instance.findControl.Owner = Instance;
            Instance.findControl.ParentOwner = ParentOwner;
            Instance.findControl.findTextBox.Focus();
        }
        private void OnFindWindowKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Escape)
            {
                Instance.Close();
            }
            else if(e.Key==Key.Enter)
            {
                if(Instance.findControl.cancelButton.IsFocused)
                {
                    Instance.Close();
                }
                else
                {
                    Instance.findControl.Find();
                }
            }
        }
    }
}
