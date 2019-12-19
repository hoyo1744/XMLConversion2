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
        public Window ParentOwner;
        #endregion

        public FindControl()
        {
            InitializeComponent();
            SetDataContext();
            Init();


            #region Event
            this.cancelButton.Click += OnCancelButtonClick;
            this.findButton.Click += OnFindButtonClick;
            #endregion
        }
        private void OnFindButtonClick(object sender,RoutedEventArgs e)
        {
            Find();
        }
        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();
        }

        void Find()
        {
            
            string sourceStr= Source.Text.ToString();
            string targetStr = ((MainWindow)ParentOwner).worker.afterTextBox.ToString();

            int idx = Source.Index; //상대위치
            int findIdx = 0;    //절대위치
            int sourceStrLen = sourceStr.Length;

            if (Source.CheckSmallAndBig == false)
            {
                targetStr = targetStr.ToUpper();
                sourceStr = sourceStr.ToUpper();
            }

            if(Source.CheckDown==true)
            {
                findIdx = sourceStr.IndexOf(targetStr, idx);
                idx = findIdx;
            }
            else if(Source.CheckUp==true)
            {
                findIdx = sourceStr.Reverse().ToString().IndexOf(targetStr, sourceStrLen-idx+1);
                idx = sourceStrLen-findIdx+1;
            }

            //1)검색된 부분 하이라이트

            //2)검색된 부분으로 스크롤 이동
        }
        void Init()
        {
            Source.Text = string.Empty;
            Source.CheckDown = true;
            Source.CheckUp = false;
            Source.CheckSmallAndBig = false;
            Source.Index = 0;
        }

        void SetDataContext()
        {
            this.MainGrid.DataContext = Source;
        }
        
    }
}
