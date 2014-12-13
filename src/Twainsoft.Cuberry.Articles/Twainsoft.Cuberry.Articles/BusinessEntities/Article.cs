using System.ComponentModel;
using System.Runtime.CompilerServices;
using P2.Cuberry.Framework.BOLBase;
using P2.Cuberry.Framework.Helper;
using Twainsoft.Cuberry.Articles.Properties;

namespace Twainsoft.Cuberry.Articles.BusinessEntities
{
    public class Article : BizObject, INotifyPropertyChanged
    {
        public int ArticleId { get; protected set; }

        public Article()
        {
            Modified = false;
        }

        public override P2Validator Validator
        {
            get
            {
                // TODO: EmptyID ist hier wohl falsch...
                if (_validator == null)
                    _validator = new P2Validator(Settings.Default.ModuleName, EntityName, "ArticleID", this);
                return _validator;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
