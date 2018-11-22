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
using WpfGUIBLib.ViewModels;
using WpfGUICore;

namespace WpfGUIBLib.Views
{
    [Export]
    [Export("WpfGUIBView", typeof(WpfGUIBView))]
    public partial class WpfGUIBView : WpfGUIViewBase
    {
        public WpfGUIBView()
        {
            InitializeComponent();
        }

        [Import]
        private WpfGUIBVM ImportVM
        {
            set { this.VM = value; }
        }
    }
}
