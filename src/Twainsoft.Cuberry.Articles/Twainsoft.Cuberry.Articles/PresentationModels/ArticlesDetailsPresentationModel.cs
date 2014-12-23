using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using P2.Cuberry.Framework.Helper;
using P2.Cuberry.Framework.Security;
using Twainsoft.Cuberry.Articles.BusinessEntities;
using Twainsoft.Cuberry.Articles.Properties;
using Twainsoft.Cuberry.Articles.Services;
using Twainsoft.Cuberry.Articles.Views.ArticlesDetailsView;

namespace Twainsoft.Cuberry.Articles.PresentationModels
{
    // TODO: Add those missing attributes I'll add later to the articles class!
    // TODO: Add missing methods - I still think there are some missing...
    public class ArticlesDetailsPresentationModel : INotifyPropertyChanged, IDisposable, IDataErrorInfo
    {
        private IUnityContainer container;
        private IRegionManager regionManager;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Error { get; private set; }
        public bool IsReadOnly { get; set; }
        public bool ModelIsModified { get; set; }

        public IArticlesDetailsView View { get; set; }

        public Article Model { get; set; }
        public Dictionary<string, User.ControlRight> ControlRights;
        public IArticleService Service;

        public DelegateCommand<object> ArticleSaveCommand { get; set; }
        public DelegateCommand<object> ArticleCloseCommand { get; set; }
        public DelegateCommand<object> FiTransactionPrintCommand { get; set; }

        protected P2MessageStack _myMessageStack = new P2MessageStack();
        public P2MessageStack MessageStack
        {
            get
            {
                return _myMessageStack;
            }
            set
            {
                _myMessageStack = value;
                OnPropertyChanged("MessageStack");
            }
        }

        public int ArticleId
        {
            get { return Model.ArticleId; }
        }

        public string Name
        {
            get { return Model.Name; }
            set
            {
                if (value != Model.Name)
                {
                    Model.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get { return Model.Description; }
            set
            {
                if (value != Model.Description)
                {
                    Model.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public double? Pages
        {
            get { return Model.Pages; }
            set
            {
                if (value != Model.Pages)
                {
                    Model.Pages = value;
                    OnPropertyChanged("Pages");
                }
            }
        }

        public ArticlesDetailsPresentationModel(IArticlesDetailsView view, Article model, ArticleService service, 
            IUnityContainer container, IRegionManager regionManager)
        {
            try
            {
                View = view;
                Model = model;
                Service = service;
                this.container = container;
                this.regionManager = regionManager;

                ControlRights = Model.GetControls(Settings.Default.ModuleName, "ArticlesDetailsView");

                ArticleSaveCommand = new DelegateCommand<object>(OnArticleSaveExecute, OnArticleSaveCanExecute);
                ArticleCloseCommand = new DelegateCommand<object>(OnArticleCloseExecute, OnArticleCloseCanExecute);

                MessageStack = new P2MessageStack();

                View.Model = this;
                RefreshView();
            }
            catch (Exception ex)
            {
                P2ExceptionHandler.LogException(ex, string.Format("{0}.{1}", GetType().Name, MethodBase.GetCurrentMethod().Name));
            }
        }

        void OnArticleSaveExecute(object sourceAccount)
        {
            View.UpdateFocusedControl();
            Save();
            RefreshView();
        }

        bool OnArticleSaveCanExecute(object sourceAccount)
        {
            User.ControlRight controlRight;
            if (ControlRights.TryGetValue("ArticleSaveBtn", out controlRight))
                return controlRight.IsActive;

            return false;
        }

        void OnArticleCloseExecute(object sourceAccount)
        {
            View.UpdateFocusedControl();
            if (Save())
            {
                View.Close();
            }
        }

        bool OnArticleCloseCanExecute(object sourceAccount)
        {
            User.ControlRight controlRight;
            if (ControlRights.TryGetValue("ArticleSaveBtn", out controlRight))
                return controlRight.IsActive;
            return false;
        }

        public void Dispose()
        {
            if (View != null)
                View.Model = this;
            View = null;
            Model = null;
            Service = null;
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;

                var propertyMessageStack = Model.Validator.ValidateProperty(Model, columnName);
                if (propertyMessageStack != null && propertyMessageStack.Count > 0)
                {
                    foreach (var message in propertyMessageStack)
                    {
                        if (message.TransactionStatus != "green")
                        {
                            if (result == null)
                                result = message.MessageText;
                            else
                                result += "\n" + message.MessageText;
                        }
                    }
                }
                return result;
            }
        }

        public bool Save()
        {
            bool isNewItem = (ArticleId <= 0);
            MessageStack.Clear();
            Model.InsertAndUpdate(MessageStack, true);

            if (MessageStack.StatusMessage.MessageStatus != P2ValidationStatus.red && !Model.Modified)
            {
                return true;
            }
            return false;
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshView()
        {
            try
            {
                ControlRights = Model.GetControls(Settings.Default.ModuleName, "ArticlesDetailsView");
                // TODO: Notify the correct attributes.
                //OnPropertyChanged("ProductID");

                ArticleCloseCommand.RaiseCanExecuteChanged();
                ArticleSaveCommand.RaiseCanExecuteChanged();
            }
            catch (Exception ex)
            {
                P2ExceptionHandler.LogException(ex, string.Format("{0}.{1}", GetType().Name, MethodBase.GetCurrentMethod().Name));
            }

        }
    }
}
