using System;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using P2.Cuberry.Framework.Helper;

namespace Twainsoft.Cuberry.Articles.PresentationModels
{
    public class ArticlesDetailsPresentationModel : INotifyPropertyChanged, IDisposable, IDataErrorInfo
    {
        private IUnityContainer container;
        private IRegionManager regionManager;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Error { get; private set; }
        public bool IsReadOnly { get; set; }
        public bool ModelIsModified { get; set; }

        /*public ArticlesDetailsPresentationModel(ISCProductsDetailsView view, BusinessEntities.SCProduct model, Services.ISCProductService service,
    IUnityContainer container, IRegionManager regionManager)
        {
            try
            {
                View = view;
                this.Model = model;
                this.Service = service;
                this.container = container;
                this.regionManager = regionManager;

                //DDL++
                this.ProductTypes = BusinessEntities.ProductType.GetList;
                this.ProductCategorys = BusinessEntities.ProductCategory.GetList;

                this.Currencys = BusinessEntities.Currency.GetList;
                this.Countries = BusinessEntities.VATCategory.GetList;
                this.ProductUnits = BusinessEntities.ProductUnit.GetList;

                ControlRights = Model.GetControls(Properties.Settings.Default.ModuleName, "SCProductsDetailsView");

                this.SCProductSaveCommand = new DelegateCommand<object>(OnSCProductSaveExecute, OnSCProductSaveCanExecute);
                this.SCProductCloseCommand = new DelegateCommand<object>(OnSCProductCloseExecute, OnSCProductCloseCanExecute);

                MessageStack = new P2MessageStack();

                View.Model = this;
                this.RefreshView();
            }
            catch (Exception ex) //AM:TC
            {
                P2ExceptionHandler.LogException(ex, string.Format("{0}.{1}", this.GetType().Name, System.Reflection.MethodInfo.GetCurrentMethod().Name));
            }
        }*/

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
