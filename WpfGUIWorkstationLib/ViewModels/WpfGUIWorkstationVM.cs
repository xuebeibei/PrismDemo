using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGUICore;

namespace WpfGUIWorkstationLib.ViewModels
{
    
    [Export]
    [Export("WpfGUIWorkstationVM", typeof(WpfGUIVMBase))]
    public class WpfGUIWorkstationVM : WpfGUIVMBase
    {

        public void SetView()
        {
            this.RegionManager.RequestNavigate("RightRegion", "WpfGUIBView");
            this.RegionManager.RequestNavigate("LeftRegion", "WpfGUIAView");
        }
    }
}
