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

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для ReGoodsWindow.xaml
    /// </summary>
    public partial class ReGoodsWindow : Window
    {
        GoodsWindow? parent;
        public ReGoodsWindow(GoodsWindow? parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

    }
}
