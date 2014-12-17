using System;
using Microsoft.Practices.Prism.Events;
using Twainsoft.Cuberry.Articles.BusinessEntities;

namespace Twainsoft.Cuberry.Articles.Views.ArticleListView
{   
    public interface IArticlesListPresenter
    {
        event EventHandler<DataEventArgs<Article>> ArticleSelected;
        event EventHandler<DataEventArgs<Article>> ArticleOpened;

        IArticlesListView View { get; set; }

        void FindArticle(Article article);
    }
}
