using System;
using System.Windows;
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
                this.View = view;
                this.listPresenter = listPresenter;
                //this.listPresenter.SCProductSelected += new EventHandler<DataEventArgs<BusinessEntities.SCProduct>>(this.OnSCProductSelected);
                //this.listPresenter.SCProductOpened += new EventHandler<DataEventArgs<BusinessEntities.SCProduct>>(this.OnSCProductOpened);
                
                View.SetHeader(listPresenter.View);
            }
            catch (Exception ex) //AM:TC
            {
                P2ExceptionHandler.LogException(ex, string.Format("{0}.{1}", this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name));
            }
        }


        public IArticlesView View { get; set; }


        public void OnSCProductSelected(object sender, DataEventArgs<Article> e)
        {            
        }


        public void OnSCProductOpened(object sender, DataEventArgs<Article> e)
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
            // TODO: Fabian - Echt jetzt? Was hat es hiermit auf sich?
            GC.Collect();
            }
            catch (Exception ex) //AM:TC
            {
                P2ExceptionHandler.LogException(ex, string.Format("{0}.{1}", this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name));
            }
        }


        public void OnSCProductFind(object sender, DataEventArgs<Article> e) //needed???
        {
            if (listPresenter != null)
            {
                //listPresenter.FindSCProduct(e.Value);
            }
        }

    }
}
