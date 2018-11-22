using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Prism.Modularity;
using Prism.Regions;

namespace WpfGUI
{
    [Export]
    [Export("MainWindow", typeof(Window))]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
