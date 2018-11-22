using System;
using System.Collections.Generic;
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
using WpfGUIALib.ViewModels;
using WpfGUICore;

namespace WpfGUIALib.Views
{
    [Export]
    [Export("WpfGUIAView", typeof(WpfGUIAView))]
    public partial class WpfGUIAView : WpfGUIViewBase
    {
        public WpfGUIAView()
        {
            InitializeComponent();
        }

        [Import]
        private WpfGUIAVM ImportVM
        {
            set { this.VM = value; }
        }
    }
}
