using System.Collections.ObjectModel;
using Twainsoft.Cuberry.Articles.BusinessEntities;

namespace Twainsoft.Cuberry.Articles.Services
{
    public interface IArticleService
    {
        ObservableCollection<Article> All();
        ObservableCollection<Article> All(Article templateArticle);
    }
}
