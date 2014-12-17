using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Practices.Prism.Events;
using Twainsoft.Cuberry.Articles.BusinessEntities;

namespace Twainsoft.Cuberry.Articles.Views.ArticleListView
{
    public partial class ArticlesListView : IArticlesListView
    {
        public event EventHandler<DataEventArgs<Article>> ArticleOpened;
        public event EventHandler<DataEventArgs<Article>> ArticleSelected;

        public ArticlesListView()
        {
            InitializeComponent();
        }

        public ObservableCollection<Article> Model
        {
            get { return DataContext as ObservableCollection<Article>; }
            set { DataContext = value; }
        }

        private void ArticlesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selected = e.AddedItems[0] as Article;
                if (selected != null)
                {
                    ArticleSelected(this, new DataEventArgs<Article>(selected));
                }
            }
        }

        private void ArticlesList_DblClick(object sender, MouseButtonEventArgs e)
        {
            var dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is DataGridRow))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null) return;

            var item = ArticlesList.ItemContainerGenerator.ItemFromContainer(dep) as Article;
            
            // Do something with the item...
            if (item != null)
            {
                ArticleOpened(this, new DataEventArgs<Article>(item));
            }
        }
    }
}
