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
            this.KeyDown += OnKeyDown;
            #endregion


        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (this.cancelButton.IsFocused == true)
                {
                    this.Owner.Close();
                }
                else
                {
                    Find();
                }
            }
            else if (e.Key == Key.Escape)
            {
                this.Owner.Close();
            }
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
            string sourceStr= Source.Text.ToString();// 검색하고자 하는 단어
            string targetStr = ((MainWindow)ParentOwner).worker.afterTextBox.Text; //전체 텍스트


            if(sourceStr.Length==0)
            {
                if (MessageBox.Show("단어를 입력해주세요.", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                    return;
            }

            int idx = Source.Index; //상대위치
            int findIdx = 0;    //절대위치
            int sourceStrLen = sourceStr.Length;

            //대소문자 구문
            if (Source.CheckSmallAndBig == false)
            {
                targetStr = targetStr.ToUpper();
                sourceStr = sourceStr.ToUpper();
            }

            //아래로 검색
            if(Source.CheckDown==true)
            {
                findIdx = targetStr.IndexOf(sourceStr, idx);
                if(findIdx==-1)
                {
                    if (MessageBox.Show("더 이상 단어를 찾을 수 없습니다.", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                        return;
                }
                idx = findIdx+1;
                Source.Index = idx;
            }
            //위로 검색
            else if(Source.CheckUp==true)
            {
                findIdx = targetStr.LastIndexOf(sourceStr, idx);
                if(findIdx==-1)
                {
                    if (MessageBox.Show("더 이상 단어를 찾을 수 없습니다.", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                        return;
                }
                idx = findIdx+1;
                Source.Index = idx;
            }

            //검색된 부분 하이라이트
            ((MainWindow)ParentOwner).worker.afterTextBox.Select(findIdx, sourceStr.Length);
            ((MainWindow)ParentOwner).worker.afterTextBox.SelectionBrush = Brushes.Red;

            //검색된 부분으로 스크롤 이동
            


            //포커스 넘겨주기
            ((MainWindow)ParentOwner).worker.afterTextBox.Focus();

        }
        void Init()
        {
            Source.Text = string.Empty;
            Source.CheckDown = true;
            Source.CheckUp = false;
            Source.CheckSmallAndBig = false;
            Source.Index = 0;
            this.findTextBox.Focus();
        }

        void SetDataContext()
        {
            this.MainGrid.DataContext = Source;
        }
        
    }
}
