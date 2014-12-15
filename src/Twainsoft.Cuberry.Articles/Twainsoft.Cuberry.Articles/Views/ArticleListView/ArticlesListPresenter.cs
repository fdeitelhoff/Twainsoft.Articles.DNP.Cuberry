using System;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Twainsoft.Cuberry.Articles.BusinessEntities;
using Twainsoft.Cuberry.Articles.Events;

namespace Twainsoft.Cuberry.Articles.Views.ArticleListView
{
    public class ArticlesListPresenter : IArticlesListPresenter, INotifyPropertyChanged
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer container;
        private IRegionManager regionManager;

        public event EventHandler<DataEventArgs<Article>> ArticleSelected;
        public event EventHandler<DataEventArgs<Article>> ArticleOpened;
        public IArticlesListView View { get; set; }
        public void FindArticle(Article article)
        {
            throw new System.NotImplementedException();
        }

        public ArticlesListPresenter(IArticlesListView view, IEventAggregator eventAggregator,
            IUnityContainer container, IRegionManager regionManager)//!!Ex02.3
        {
            View = view;
            FillCommand = new DelegateCommand<object>(OnFillExecute, OnFillCanExecute);
            View.Model = this;

            _eventAggregator = eventAggregator; //!!Ex02.3
            this.container = container; //!!Ex02.3
            this.regionManager = regionManager; //!!Ex02.3
            var findEvent = 
                _eventAggregator.GetEvent<FindArticleEvent>(); //!!Ex02.3
            findEvent.Subscribe(FillEmpty); //!!Ex02.3
        }


        string _labelValue = "";
        public string LabelValue
        {
            get
            {
                return _labelValue;
            }
            set
            {
                _labelValue = value;
                OnPropertyChanged("LabelValue");
            }
        }

        public DelegateCommand<object> FillCommand { get; set; }

        void OnFillExecute(object sourceAccount)
        {
            LabelValue = "Filled";
        }

        bool OnFillCanExecute(object sourceAccount)
        {
            return true;
        }


        public void FillEmpty(Article article) //!!Ex02.3
        {
            LabelValue = "Filled";
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string propertyName)
        {
            var Handler = PropertyChanged;
            if (Handler != null) Handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
