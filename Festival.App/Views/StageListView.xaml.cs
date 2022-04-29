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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Festival.App.ViewModels;

namespace Festival.App.Views
{
    /// <summary>
    /// Interaction logic for StageListView.xaml
    /// </summary>
    public partial class StageListView : UserControl
    {
        public StageListView(StageViewModel stageViewModel)
        {
            InitializeComponent();
            DataContext = stageViewModel;
        }
    }

}
