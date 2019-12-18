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
using XMLConversion;

namespace XMLConversion.AdvanceControl
{
    /// <summary>
    /// ColorPicker.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        private ColorComboBox source;

        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent(
            "ColorChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ColorPicker));

        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register(
            "SelectedColor", typeof(FontColor), typeof(ColorPicker), new UIPropertyMetadata(null));

        public FontColor SelectedColor
        {
            get 
            {
                FontColor fc = (FontColor)this.GetValue(SelectedColorProperty);
                if (fc == null)
                {
                    fc = AvailableColors.GetFontColor("Black");
                }
                return fc;
            }
        
            set 
            {
                this.source.SelectedFontColor = value;
                SetValue(SelectedColorProperty, value);
            }
        }

        public event RoutedEventHandler ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }
        private void RaiseColorChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ColorPicker.ColorChangedEvent);
            RaiseEvent(newEventArgs);
        }
        public ColorPicker()
        {
            InitializeComponent();

            Init();
            SetContextData();
            this.source= new ColorComboBox();
            this.DataContext = this.source;


            #region Event
            this.colorComboBox.DropDownClosed += OnDropDownClosed;
            this.colorComboBox.Loaded += OnColorComboBoxLoaded;
            #endregion

        }

        private void OnColorComboBoxLoaded(object sender, RoutedEventArgs e)
        {
            this.SetValue(SelectedColorProperty, this.source.SelectedFontColor);
        }

        private void OnDropDownClosed(object sender, EventArgs e)
        {
            this.SetValue(SelectedColorProperty, this.source.SelectedFontColor);
            this.RaiseColorChangedEvent();
        }

        public void Init()
        {
            source = new ColorComboBox();
        }
        public void SetContextData()
        {
            this.DataContext = this.source;
        }
       
    }
}
