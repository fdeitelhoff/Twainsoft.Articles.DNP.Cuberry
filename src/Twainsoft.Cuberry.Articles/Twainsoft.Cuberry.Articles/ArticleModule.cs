using System;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using P2.Cuberry.Framework.Helper;
using Twainsoft.Cuberry.Articles.Properties;

namespace Twainsoft.Cuberry.Articles
{
    public class ArticleModule : IModule, IShowableModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Hide()
        {
            throw new NotImplementedException();
        }

        public string ModuleName
        {
            get
            {
                return Settings.Default.ModuleName;
            }
        }

        public ArticleModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
            ModuleRepository.Modules.Add(ModuleName, this);
        }

        public void Initialize()
        {
            RegisterViewsAndServices();
        }

        protected void RegisterViewsAndServices()
        {
            //this.container.RegisterType<IEmptyListView, EmptyListView>();
        }
    }
}
