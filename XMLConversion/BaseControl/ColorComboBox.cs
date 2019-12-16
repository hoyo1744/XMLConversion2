using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using XMLConversion;

namespace XMLConversion.BaseControl
{
    // ColorComboBox는 ColorPicker에서의 데이터 원본
    class ColorComboBox : INotifyPropertyChanged
    {
        private ReadOnlyCollection<FontColor> fontColorList;
        private FontColor selectedFontColor;
        public ColorComboBox()
        {
            this.selectedFontColor = AvailableColors.GetFontColor(Colors.Black);
            this.fontColorList = new ReadOnlyCollection<FontColor>(new AvailableColors());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string PropName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }

  

    

        public ReadOnlyCollection<FontColor> FontColorList
        {
            get { return this.fontColorList; }
        }
        public FontColor SelectedFontColor
        {
            get
            {
                return this.selectedFontColor;
            }
            set
            {
                if (this.selectedFontColor == value)
                    return;
                this.selectedFontColor = value;
                Notify("SelectedFontColor");
            }
        }

    }
}
