using System.ComponentModel;
using System.Runtime.CompilerServices;
using P2.Cuberry.Framework.BOLBase;
using P2.Cuberry.Framework.Helper;
using Twainsoft.Cuberry.Articles.Properties;

namespace Twainsoft.Cuberry.Articles.BusinessEntities
{
    // TODO: Implement missing methods - especially for the data access!
    public class Article : BizObject, INotifyPropertyChanged
    {
        public int ArticleId { get; protected set; }

        string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    Modified = true;
                }
            }
        }

        string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    Modified = true;
                }
            }
        }

        double? pages = 0;
        public double? Pages
        {
            get { return pages; }
            set
            {
                if (pages != value)
                {
                    pages = value;
                    Modified = true;
                }
            }
        }

        public Article()
        {
            name = string.Empty;
            description = string.Empty;

            Modified = false;
        }

        public override P2Validator Validator
        {
            get
            {
                if (_validator == null)
                    _validator = new P2Validator(Settings.Default.ModuleName, EntityName, "ArticleId", this);
                return _validator;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertAndUpdate(P2MessageStack messageStack, bool checkDoublicate)
        {
            throw new System.NotImplementedException();
        }
    }
}
