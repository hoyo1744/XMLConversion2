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
        /// <summary>
        /// 찾을 단어
        /// </summary>
        private string text;
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
        /// <summary>
        /// 위로 찾기
        /// </summary>
        private bool checkUp;
        public bool CheckUp
        {
            get { return checkUp; }
            set
            {
                if (checkUp == value)
                    return;
                Notify("CheckUp");
                checkUp = value;
            }
        }
        /// <summary>
        /// 아래로 찾기
        /// </summary>
        private bool checkDown;
        public bool CheckDown
        {
            get { return checkDown;}
            set
            {
                if (checkDown == value)
                    return;
                Notify("CheckDonw");
                checkDown = value;
            }
        }
        /// <summary>
        /// 대소문자구문
        /// </summary>
        private bool checkSmallAndBig;
        public bool CheckSmallAndBig
        {
            get { return checkSmallAndBig; }
            set
            {
                if (checkSmallAndBig == value)
                    return;
                Notify("CheckSmallAndBig");
                checkSmallAndBig = value;
            }
        }


     


    }
}
