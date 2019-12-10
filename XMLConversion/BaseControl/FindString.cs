using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLConversion.BaseControl
{
    class FindString : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        string text;
        public string Text
        {
            get { return text; }
            set
            {
                if (text == value)
                    return;
                Notify("Text");
                text = value;
            }
        }

     


    }
}
