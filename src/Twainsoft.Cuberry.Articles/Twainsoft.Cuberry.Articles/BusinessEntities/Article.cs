using P2.Cuberry.Framework.BOLBase;
using P2.Cuberry.Framework.Helper;

namespace Twainsoft.Cuberry.Articles.BusinessEntities
{
    public class Article : BizObject
    {
        public Article()
        {
            
        }

        public override P2Validator Validator
        {
            get
            {
                // TODO: EmptyID ist hier wohl falsch...
                if (_validator == null)
                    _validator = new P2Validator(Properties.Settings.Default.ModuleName, this.EntityName, "EmptyID", this);
                return _validator;
            }
        }
    }
}
