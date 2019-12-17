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
using XMLConversion.BaseControl;

namespace XMLConversion.Windows
{
    /// <summary>
    /// FontWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FontWindow : Window
    {
        private FontInfo selectedFont;

        public FontInfo Font
        {
            get { return this.selectedFont; }
            set
            {
                FontInfo fi = value;
                this.selectedFont = fi;
            }
        }
        public FontWindow()
        {
            InitializeComponent();
            this.selectedFont = null;


            #region Event
            this.Loaded += OnLoaded;
            this.KeyDown += OnPopUpWindowKeyDown;
            this.FontControl.confirmButton.Click += OnConfirmButtonClick;
            this.FontControl.cancelButton.Click += OnCancelButtonClick;
            #endregion
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Font=this.FontControl.
        }

        private void OnConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnPopUpWindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.FontControl.colorPicker.colorComboBox.SelectedIndex = 7;
            
        }
        
    }
}
