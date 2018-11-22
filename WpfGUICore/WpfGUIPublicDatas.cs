using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Prism.Events;

namespace WpfGUICore
{
    public class WpfGUIPublicDatas : DependencyObject
    {
        #region MainData

        public static readonly DependencyProperty MainDataProperty = DependencyProperty.Register("MainData",
            typeof(JObject), typeof(WpfGUIPublicDatas), new PropertyMetadata((sender, e) => { }));

        public JObject MainData
        {
            get { return GetValue(MainDataProperty) as JObject; }
            set { SetValue(MainDataProperty, value); }
        }

        #endregion


        public static WpfGUIPublicDatas Instance { get; } = new WpfGUIPublicDatas();

        private WpfGUIPublicDatas()
        {
            MainData = new JObject();
        }

        #region EventAggregator

        private IEventAggregator _EventAggregator;

        public IEventAggregator EventAggregator
        {
            get
            {
                if (_EventAggregator == null)
                    _EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                return _EventAggregator;
            }
        }

        #endregion
    }
}
