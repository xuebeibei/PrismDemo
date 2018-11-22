using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using WpfGUICore;
using WpfGUICore.EventManager;

namespace WpfGUIALib.ViewModels
{
    [Export]
    [Export("WpfGUIAVM", typeof(WpfGUIVMBase))]
    public class WpfGUIAVM : WpfGUIVMBase
    {
        public ICommand LeftBtnCommand { get; set; }

        public override void RegisterCommands()
        {
            base.RegisterCommands();
            LeftBtnCommand = new DelegateCommand<object>(MySendMsg);
        }

        public override void RegisterEvents()
        {
            base.RegisterEvents();
        }

        private void MySendMsg(object arg0)
        {
            this.EventAggregator.GetEvent<BtnClickEvent>().Publish(arg0);
        }

    }
}
