using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
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
using Microsoft.Practices.ServiceLocation;
using Prism.Regions;
using WpfGUICore;
using WpfGUIWorkstationLib.ViewModels;

namespace WpfGUIWorkstationLib.Views
{

    [Export]
    [Export("WpfGUIWorkstationView", typeof(WpfGUIWorkstationView))]
    public partial class WpfGUIWorkstationView : WpfGUIViewBase
    {
        public WpfGUIWorkstationView()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var vm = VM as WpfGUIWorkstationVM;
            vm.SetView();
        }

        [Import]
        private WpfGUIWorkstationVM ImportVM
        {
            set { this.VM = value; }
        }
    }
}
