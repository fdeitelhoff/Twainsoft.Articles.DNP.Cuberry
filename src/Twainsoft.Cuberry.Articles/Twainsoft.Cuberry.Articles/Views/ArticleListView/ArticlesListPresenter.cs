using System;
using Microsoft.Practices.Prism.Events;
using Twainsoft.Cuberry.Articles.BusinessEntities;
using Twainsoft.Cuberry.Articles.Services;

namespace Twainsoft.Cuberry.Articles.Views.ArticleListView
{
    public class ArticlesListPresenter : IArticlesListPresenter
    {
        private IArticleService ArticleService { get; set; }

        public IArticlesListView View { get; set; }

        public event EventHandler<DataEventArgs<Article>> ArticleSelected = delegate { };
        public event EventHandler<DataEventArgs<Article>> ArticleOpened = delegate { };

        public ArticlesListPresenter(IArticlesListView view, IArticleService articleService)
        {
            View = view;

            View.ArticleSelected += (sender, e) => ArticleSelected(sender, e);
            View.ArticleOpened += (sender, e) => ArticleOpened(sender, e);

            ArticleService = articleService;
        }

        public void FindArticle(Article article)
        {
            View.Model = ArticleService.All(article);
        }
    }
}
