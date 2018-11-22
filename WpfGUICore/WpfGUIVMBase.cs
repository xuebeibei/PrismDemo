using Newtonsoft.Json.Linq;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Events;

namespace WpfGUICore
{
    public class WpfGUIVMBase : DependencyObject
    {
        [Import]
        public IRegionManager RegionManager { get; private set; }

        [Import]
        public IEventAggregator EventAggregator { get; private set; }

       
        #region MainData

        public static readonly DependencyProperty MainDataProperty = DependencyProperty.Register("MainData",
            typeof(JObject), typeof(WpfGUIVMBase),
            new PropertyMetadata(WpfGUIPublicDatas.Instance.MainData, (sender, e) => { }));

        public JObject MainData
        {
            get { return GetValue(MainDataProperty) as JObject; }
            set { SetValue(MainDataProperty, value); }
        }

        #endregion

        public WpfGUIVMBase()
        {
            RegisterCommands();
        }


        public virtual void RegisterEvents()
        {

        }

        public virtual void UnRegisterEvents()
        {

        }

        public virtual void RegisterCommands()
        {

        }


        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegisterEvents();
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.UnRegisterEvents();
        }
    }
}
