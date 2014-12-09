using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using P2.Cuberry.Framework.Helper;

namespace Twainsoft.Cuberry.Articles
{
    public class ArticleModule : IModule, IShowableModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public void Show()
        {
            throw new System.NotImplementedException();
        }

        public void Hide()
        {
            throw new System.NotImplementedException();
        }

        public string ModuleName
        {
            get
            {
                return Properties.Settings.Default.ModuleName;
            }
        }

        public ArticleModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
            ModuleRepository.Modules.Add(this.ModuleName, this);
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
