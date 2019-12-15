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
using System.Xml;
using System.Xml.Linq;
using XMLConversion.Command;
using XMLConversion.Windows;

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
        public Window Owner;
        #endregion

        public Worker()
        {
            InitializeComponent();
            SetDataContext();

            

            #region Event
            this.Loaded += OnWorkerLoaded;
            this.beforeTextBox.TextChanged += OnTextChanged;
            this.afterTextBox.TextChanged += OnTextChanged;
            this.fontMenu.KeyDown += OnfontMenuKeyDown;
            this.newMenu.KeyDown += OnNewMenuKeyDown;
            #endregion

            #region command
            // 편집 명령
            CommandBinding cbEdit = new CommandBinding(EditCommand.editCommand);
            cbEdit.Executed += EditCommandHandler;
            cbEdit.CanExecute += CheckEditCommandHandler;
            this.CommandBindings.Add(cbEdit);

            // 서식 명령
            CommandBinding cbFormat = new CommandBinding(FormatCommand.formatCommand);
            cbFormat.Executed += FormatCommandHandler;
            cbFormat.CanExecute += CheckFormatCommandHandler;
            this.CommandBindings.Add(cbFormat);

            // 찾기 명령
            CommandBinding cbFind = new CommandBinding(ApplicationCommands.Find);
            cbFind.Executed += FindCommandHandler;
            cbFind.CanExecute += CheckFindCommandHandler;
            this.CommandBindings.Add(cbFind);

            // 새 창 생성 명령
            CommandBinding cbNew = new CommandBinding(ApplicationCommands.New);
            cbNew.Executed += NewCommandHandler;
            cbNew.CanExecute += CheckNewCommandHandler;
            this.CommandBindings.Add(cbNew);


            #endregion

            #region InputBinding
            // 호용 : 정의되어 있는 커맨드를 사용할 경우 필요 없다.
            // 찾기 명령
            //InputBinding ibFind = new InputBinding(ApplicationCommands.Find, new KeyGesture(Key.F, ModifierKeys.Control));
            //this.InputBindings.Add(ibFind);

            // 새창 생성 명령
            //InputBinding ibNew = new InputBinding(ApplicationCommands.New, new KeyGesture(Key.N, ModifierKeys.Control|ModifierKeys.Shift));
            //this.InputBindings.Add(ibNew);
            #endregion



        }

        void OnNewMenuKeyDown(object sender,KeyEventArgs e)
        {
            if(e.Key==Key.U)
            {

            }
        }
        void OnfontMenuKeyDown(object sender,KeyEventArgs e)
        {
            if(e.Key==Key.F)
            {
                //MessageBox.Show("font");
                FontControl fontControl = new FontControl();
                NoSizeFixedWindow sfw = new NoSizeFixedWindow(fontControl);
                sfw.Title = "글꼴";
                sfw.ShowDialog();
            }
        }
        void EditCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if(this.editMenu.IsCheckable)
                this.editMenu.IsChecked = true;
        }
        void FormatCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if(this.formatMenu.IsCheckable)
                this.formatMenu.IsChecked = true;
        }
        void CheckFormatCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        void CheckEditCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        void CheckNewCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        void CheckFindCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        void NewCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("New");
        }
        void FindCommandHandler(object sender,ExecutedRoutedEventArgs e)
        {   
            popUpWindow popUp = new popUpWindow();
            popUp.Owner= Owner;
            popUp.Title = "찾기";
            popUp.Show();
        }
        void SetDataContext()
        {
            this.beforeTextBox.DataContext = textBeforeTransfer;
        }
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
        }
        void TrasnferXMLText()
        {
           /*xDocument객체로 처리하기*/
            afterTextBox.Text = textBeforeTransfer.Text;
            string str = afterTextBox.Text;
            
            try
            {
                XDocument xdoc = XDocument.Parse(str);
                afterTextBox.Text = xdoc.ToString();
            }
            catch(Exception e)
            {
                if (MessageBox.Show("올바른 XML 형식이 아닙니다.", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    afterTextBox.Text = string.Empty;
                    return;
                }
            }
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
