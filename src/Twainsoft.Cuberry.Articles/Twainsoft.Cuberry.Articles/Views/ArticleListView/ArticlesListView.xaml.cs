namespace Twainsoft.Cuberry.Articles.Views.ArticleListView
{
    public partial class ArticlesListView : IArticlesListView
    {
        public ArticlesListView()
        {
            InitializeComponent();
        }

        public IArticlesListPresenter Model
        {
            get { return DataContext as IArticlesListPresenter; }
            set { DataContext = value; }
        }
        
    }
}
