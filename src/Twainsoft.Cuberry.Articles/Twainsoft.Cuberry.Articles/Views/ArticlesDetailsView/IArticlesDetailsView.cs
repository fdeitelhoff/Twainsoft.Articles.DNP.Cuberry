using System;
using System.Windows;

namespace Twainsoft.Cuberry.Articles.Views.ArticlesDetailsView
{
    interface IArticlesDetailsView
    {
        // TODO: Correct model needs to be implemented.
        //SCProductsDetailsPresentationModel Model { get; set; }
        bool? ShowDialog();
        FlowDirection FlowDirection { get; set; }
        void UpdateFocusedControl();
        bool AskSave();
        void Close();
        bool YellowStatusWarning(string messageText, string captionText);
    }
}
