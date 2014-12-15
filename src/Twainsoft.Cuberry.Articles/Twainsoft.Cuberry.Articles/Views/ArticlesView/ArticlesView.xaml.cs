using System.Windows.Controls;
using Twainsoft.Cuberry.Articles.Views.ArticleListView;

namespace Twainsoft.Cuberry.Articles.Views.ArticlesView
{
    /// <summary>
    /// Interaction logic for SCProductsView.xaml
    /// </summary>
    public partial class ArticlesView : UserControl, IArticlesView
    {
        public ArticlesView()
        {
            InitializeComponent();
        }

        public void SetHeader(IArticlesListView scProductsListView)
        {
            HeaderPanel.Content = scProductsListView;
        }
    }
}
