﻿using System;
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

namespace XMLConversion.Windows
{
    /// <summary>
    /// FontWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FontWindow : Window
    {
        public FontWindow()
        {
            InitializeComponent();


            #region Event
            this.Loaded += OnLoaded;
            this.KeyDown += OnPopUpWindowKeyDown;
            #endregion
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
