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
            this.KeyDown += OnPopUpWindowKeyDown;
            this.Loaded += OnLoaded;
            this.FontControl.confirmButton.Click += OnConfirmButtonClick;
            this.FontControl.cancelButton.Click += OnCancelButtonClick;
            #endregion
        }

        
        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnConfirmButtonClick(object sender, RoutedEventArgs e)
        { 
            this.Font = this.FontControl.SelectedFont;
            this.DialogResult = true;
        }

        private void OnPopUpWindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.ApplyFontColor();  
            this.ApplyFontName();
            this.ApplyFontSize();
            this.ApplyFontTypeFace();

            
        }

        private void ApplyFontColor()
        {
            int colorIndex = AvailableColors.GetFontColorIndex(this.Font.Color);
            this.FontControl.colorPicker.colorComboBox.SelectedIndex = colorIndex;
            this.FontControl.colorPicker.colorComboBox.BringIntoView();

        }
        private void ApplyFontName()
        {
            string fontFamilyName = this.selectedFont.Family.Source;
            int idx = 0;
            foreach(var item in this.FontControl.fontFamilyList.Items)
            {
                string itemName = item.ToString();
                if(fontFamilyName==itemName)
                {
                    break;
                }
                idx++;
            }
            this.FontControl.fontFamilyList.SelectedIndex = idx;
            //this.FontControl.fontFamilyList.ScrollIntoView(this.FontControl.fontFamilyList.Items[idx]);
        }
        private void ApplyFontSize()
        {
            double fontSize = this.selectedFont.Size;
            this.FontControl.fontSizeSlider.Value = fontSize;
        }
        private void ApplyFontTypeFace()
        {
            string fontTypeFaceName = FontInfo.TypefaceToString(this.selectedFont.TypeFace);
            int idx = 0;
            foreach(var item in this.FontControl.fontTypeList.Items)
            {
                FamilyTypeface face = item as FamilyTypeface;
                if(fontTypeFaceName==FontInfo.TypefaceToString(face))
                {
                    break;
                }
                idx++;
            }
            this.FontControl.fontTypeList.SelectedIndex = idx;
        }
        
    }
}
