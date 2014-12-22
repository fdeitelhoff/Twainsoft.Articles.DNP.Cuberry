using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using P2.Cuberry.Framework.Helper;
using Twainsoft.Cuberry.Articles.PresentationModels;

namespace Twainsoft.Cuberry.Articles.Views.ArticlesDetailsView
{
    public partial class ArticlesDetailsView : Window, IArticlesDetailsView
    {
        public ArticlesDetailsView()
        {
            InitializeComponent();
        }

        public ArticlesDetailsPresentationModel Model
        {
            get { return DataContext as ArticlesDetailsPresentationModel; }
            set
            {                
                DataContext = value;
                // TODO: Change the sorting!
                //VATCategoryID.Items.SortDescriptions.Add(new SortDescription("VATCategoryNameCur", ListSortDirection.Ascending));                
            }
        }


        public void UpdateFocusedControl()
        {
            try
            {
                var focusedTextBox = Keyboard.FocusedElement as TextBox;
                if (focusedTextBox == null)
                    return;
                
                var textBindingExpr =
                  focusedTextBox.GetBindingExpression(TextBox.TextProperty);
                if (textBindingExpr == null)
                    return;

                textBindingExpr.UpdateSource();
            }
            catch
            { }
        }
        
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateFocusedControl();      
        }
        
        public bool AskSave()
        {
            UpdateFocusedControl();

            if (!Model.IsReadOnly && Model.ModelIsModified)
            {
                var opt = MessageBoxOptions.None;
                if (FlowDirection == FlowDirection.RightToLeft) opt = MessageBoxOptions.RtlReading;
                var result = MessageBox.Show(P2Translator.GetResource("scProductCodetSaved"), P2Translator.GetResource("SCProductCodetSavedCaption"), MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Cancel, opt);
                switch (result)
                {
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.No:
                        return true;

                    case MessageBoxResult.Yes:
                        Model.Save();
                        if (StatusStrip.Status == "green")
                            return true;
                        break;
                }
                return false;
            }

            return true;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = AskSave();
            if (result) Close();
        }
        
        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        { }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskSave();
        }

        public bool YellowStatusWarning(string messageText, string captionText)
        {
            var opt = MessageBoxOptions.None;
            if (FlowDirection == FlowDirection.RightToLeft) opt = MessageBoxOptions.RtlReading;
            var result = MessageBox.Show(messageText, captionText, MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Cancel, opt);

            switch (result)
            {
                case MessageBoxResult.Cancel:
                    break;

                case MessageBoxResult.No:
                    return false;
                    
                case MessageBoxResult.Yes:
                    return true;
            }

            return false;
        }
    }
}

