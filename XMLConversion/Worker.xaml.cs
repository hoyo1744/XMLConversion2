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
    /// Worker.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Worker : UserControl
    {
        #region 전역변수
        TextBoxString textBeforeTransfer = new TextBoxString();//변환전 텍스트(바인딩 원본)
        TextBoxString textAfterTransfer = new TextBoxString();//변환후 텍스트(바인딩 원본)
        
        #endregion

        public Worker()
        {
            InitializeComponent();
            SetDataContext();

            
            
            #region Event
            this.Loaded += OnWorkerLoaded;
            this.beforeTextBox.TextChanged += OnTextChanged;
            this.afterTextBox.TextChanged += OnTextChanged;
            #endregion

            #region command
            CommandBinding cbFind = new CommandBinding(ApplicationCommands.Find);
            cbFind.Executed += FindCommandHandler;
            cbFind.CanExecute += CheckFindCommandHandler;
            this.CommandBindings.Add(cbFind);
            #endregion

            #region InputBinding
            InputBinding ibFind = new InputBinding(ApplicationCommands.Find, new KeyGesture(Key.F, ModifierKeys.Control));
            this.InputBindings.Add(ibFind);
            #endregion



        }

        void FindCommandHandler(object sender,ExecutedRoutedEventArgs e)
        {
            popUpWindow popUp = new popUpWindow();
            popUp.Show();
        }
        void CheckFindCommandHandler(object sender,CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        // 호용 : 객체별 DataContext 설정하기
        void SetDataContext()
        {
            this.beforeTextBox.DataContext = textBeforeTransfer;
        }

        // 호용 : 텍스트변경 이벤트
        void OnTextChanged(Object sender,RoutedEventArgs e)
        {
            if(sender==beforeTextBox)
            {
                if (textBeforeTransfer.Text.Length == 0)
                {
                    afterTextBox.Text = string.Empty;
                    return;
                }
                if (!CheckXMLText(textBeforeTransfer.Text))
                {
                    if (MessageBox.Show("올바른 XML 형식이 아닙니다.", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        afterTextBox.Text = string.Empty;
                        return;
                    }
                }
                TrasnferXMLText();
            }
            else if(sender==afterTextBox)
            {
                // 호용 : 수정 불가능해야함.
            }
        }

        void TrasnferXMLText()
        {
            //step1: 개행
            afterTextBox.Text= textBeforeTransfer.Text.Replace(">", ">\n");

            //step2: 들여쓰기

        }
        bool CheckXMLText(string strText)
        {
            bool ret = true;
            Stack<char> pstack = new Stack<char>();

            for(int i=0;i<strText.Length;i++)
            {
                if (strText[i] == '<')
                    pstack.Push(strText[i]);
                else if(strText[i]=='>')
                {
                    if (pstack.Count > 0)
                        pstack.Pop();
                    else
                    {
                        ret = false;
                        break;
                    }

                }
            }
            if (pstack.Count != 0)
                ret = false;
            
            return ret;
        }
        void OnWorkerLoaded(Object sender,RoutedEventArgs e)
        {

        }

      
    }
}
