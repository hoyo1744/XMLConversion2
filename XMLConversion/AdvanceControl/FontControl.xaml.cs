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
    /// fontControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FontControl : UserControl
    {
        public FontInfo SelectedFont
        {
            get
            {
                return new FontInfo(this.sampleTextBox.FontFamily,
                                    this.sampleTextBox.FontSize,
                                    this.sampleTextBox.FontStyle,
                                    this.sampleTextBox.FontStretch,
                                    this.sampleTextBox.FontWeight,
                                    this.colorPicker.SelectedColor.Brush);
            }

        }
        #region 전역변수
        public Window owner;
        #endregion
        public FontControl()
        {
            InitializeComponent();
            this.sampleTextBox.IsReadOnly = true;
        }

        
    }
}
