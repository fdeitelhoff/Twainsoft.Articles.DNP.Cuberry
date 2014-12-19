using System.Windows;
using Twainsoft.Cuberry.Articles.PresentationModels;

namespace Twainsoft.Cuberry.Articles.Views.ArticlesDetailsView
{
    interface IArticlesDetailsView
    {
        ArticlesDetailsPresentationModel Model { get; set; }
        bool? ShowDialog();
        FlowDirection FlowDirection { get; set; }
        void UpdateFocusedControl();
        bool AskSave();
        void Close();
        bool YellowStatusWarning(string messageText, string captionText);
    }
}
