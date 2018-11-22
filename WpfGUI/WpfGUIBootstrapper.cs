﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mef;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.IO;
using System.Windows.Markup;

namespace WpfGUI
{
    public class WpfGUIBootstrapper : MefBootstrapper
    {
        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
        }

        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = this.Shell as MainWindow;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(MainWindow).Assembly));
            this.LoadCatalogs();
            this.LoadStyles("Themes");
        }
        void LoadStyles(string dirPath)
        {
            try
            {
                if (!Directory.Exists(dirPath)) return;
                var files = Directory.GetFiles(dirPath, "*.xaml");
                Application.Current.Resources.MergedDictionaries.Clear();
                foreach (var file in files)
                {
                    try
                    {
                        using (FileStream s = new FileStream(file, FileMode.Open))
                        {
                            ResourceDictionary rd = XamlReader.Load(s) as ResourceDictionary;
                            Application.Current.Resources.MergedDictionaries.Add(rd);
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        void LoadCatalogs()
        {
            var config = ConfigurationManager.AppSettings["ModuleConfigFile"];

            if (string.IsNullOrEmpty(config))
            {
                this.LoadDirTreeCatalogs("Plugins");
            }
            else
            {
                this.LoadCatalogsFromConfigFile(config);
            }
        }

        void LoadCatalogsFromConfigFile(string filePath)
        {

            if (!File.Exists(filePath)) return;
            var dllFiles = File.ReadAllLines(filePath);

            foreach (var dllFile in dllFiles)
            {
                if (dllFile.StartsWith("//")) continue;
                if (!File.Exists(dllFile)) continue;
                this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(dllFile));
            }
        }
        void LoadDirTreeCatalogs(string dirPath)
        {
            if (!Directory.Exists(dirPath)) return;
            foreach (var dllFile in Directory.GetFiles(dirPath, "*.dll"))
            {
                this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(dllFile));
            }
            foreach (var subDir in Directory.GetDirectories(dirPath))
            {
                LoadDirTreeCatalogs(subDir);
            }
        }
    }
}
