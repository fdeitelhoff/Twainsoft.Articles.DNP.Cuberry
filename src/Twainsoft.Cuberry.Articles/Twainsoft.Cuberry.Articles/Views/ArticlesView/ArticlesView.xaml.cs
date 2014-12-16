using Twainsoft.Cuberry.Articles.Views.ArticleListView;

namespace Twainsoft.Cuberry.Articles.Views.ArticlesView
{
    public partial class ArticlesView : IArticlesView
    {
        public ArticlesView()
        {
            InitializeComponent();
        }

        public void SetHeader(IArticlesListView articlesListView)
        {
            HeaderPanel.Content = articlesListView;
        }
    }
}
