using System;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Events;
using Twainsoft.Cuberry.Articles.BusinessEntities;

namespace Twainsoft.Cuberry.Articles.Views.ArticleListView
{    
    public interface IArticlesListView
    {
        event EventHandler<DataEventArgs<Article>> ArticleOpened;
        event EventHandler<DataEventArgs<Article>> ArticleSelected;

        ObservableCollection<Article> Model { get; set; }
    }
}
