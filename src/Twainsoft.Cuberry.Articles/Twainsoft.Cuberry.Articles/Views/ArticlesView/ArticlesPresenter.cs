using System;
using System.Reflection;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using P2.Cuberry.Framework.Helper;
using Twainsoft.Cuberry.Articles.BusinessEntities;
using Twainsoft.Cuberry.Articles.Views.ArticleListView;

namespace Twainsoft.Cuberry.Articles.Views.ArticlesView
{  
    public class ArticlesPresenter
    {
        private IUnityContainer container;
        private IRegionManager regionManager;
        private IArticlesListPresenter listPresenter;        

        public ArticlesPresenter(IArticlesView view, IArticlesListPresenter listPresenter, IUnityContainer container, 
            IRegionManager regionManager)
        {
            try
            {
                this.container = container;
                this.regionManager = regionManager;
                View = view;
                this.listPresenter = listPresenter;
                this.listPresenter.ArticleSelected += OnArticleSelected;
                this.listPresenter.ArticleOpened += OnArticleOpened;
                
                View.SetHeader(listPresenter.View);
            }
            catch (Exception ex)
            {
                P2ExceptionHandler.LogException(ex, string.Format("{0}.{1}", GetType().Name, MethodBase.GetCurrentMethod().Name));
            }
        }


        public IArticlesView View { get; set; }


        public void OnArticleSelected(object sender, DataEventArgs<Article> e)
        {            
        }


        public void OnArticleOpened(object sender, DataEventArgs<Article> e)
        {   
            try
            {
            /*ISCProductsDetailsView dv = this.container.Resolve<ISCProductsDetailsView>();         
            Services.ISCProductService service = this.container.Resolve<Services.ISCProductService>();
            SCProductsDetailsPresentationModel pm = new SCProductsDetailsPresentationModel(dv, new BusinessEntities.SCProduct(e.Value.ProductID), service, container, regionManager);
            dv.FlowDirection = (P2Translator.Culture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
            dv.ShowDialog();
            pm.Dispose();
            pm = null;
            dv = null;*/
            GC.Collect();
            }
            catch (Exception ex)
            {
                P2ExceptionHandler.LogException(ex, string.Format("{0}.{1}", GetType().Name, MethodBase.GetCurrentMethod().Name));
            }
        }


        public void OnArticlesFind(object sender, DataEventArgs<Article> e)
        {
            if (listPresenter != null)
            {
                listPresenter.FindArticle(e.Value);
            }
        }

    }
}
