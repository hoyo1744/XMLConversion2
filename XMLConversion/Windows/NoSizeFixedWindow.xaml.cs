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
using XMLConversion;

namespace XMLConversion.Windows
{
    /// <summary>
    /// NoSizeFixedWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NoSizeFixedWindow : Window
    {
        public NoSizeFixedWindow()
        {
            InitializeComponent();
            #region Event
            this.Loaded += OnLoaded;
            this.KeyDown += OnPopUpWindowKeyDown;
            #endregion
        }
        public NoSizeFixedWindow(UserControl obj)
        {
            InitializeComponent();
            this.MainGrid.Children.Add(obj);
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
        }

    
    }
}
