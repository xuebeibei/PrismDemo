using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfGUICore;
using WpfGUICore.EventManager;

namespace WpfGUIBLib.ViewModels
{
    [Export]
    [Export("WpfGUIBVM", typeof(WpfGUIVMBase))]
    public class WpfGUIBVM : WpfGUIVMBase
    {

        public override void RegisterEvents()
        {
            base.RegisterEvents();
            this.EventAggregator.GetEvent<BtnClickEvent>().Subscribe(SetContent);
        }

        public override void UnRegisterEvents()
        {
            base.UnRegisterEvents();
            WpfGUIPublicDatas.Instance.EventAggregator.GetEvent<BtnClickEvent>().Unsubscribe(SetContent);
        }

        #region LabelText

        public static readonly DependencyProperty LabelDataProperty = DependencyProperty.Register(
            "LabelData", typeof(string), typeof(WpfGUIBVM), new PropertyMetadata(default(string)));

        public string LabelData
        {
            get { return (string) GetValue(LabelDataProperty); }
            set { SetValue(LabelDataProperty, value); }
        }

        #endregion

        private void SetContent(object arg0)
        {
            var data = arg0 + "";
            if (string.IsNullOrEmpty(data)) return;
            LabelData = data;
        }
    }
}
