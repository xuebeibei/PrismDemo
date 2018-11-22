using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mef.Modularity;
using Prism.Modularity;
using WpfGUICore;
using WpfGUIWorkstationLib.Views;

namespace WpfGUIWorkstationLib
{
    [ModuleExport(typeof(WpfGUIWorkstationModule))]
    public class WpfGUIWorkstationModule : WpfGUIMoudleBase
    {
        public override void RegisterViews()
        {
            base.RegisterViews();
            this.RegionManger.RegisterViewWithRegion("MainRegion", typeof(WpfGUIWorkstationView));
        }
    }
}
