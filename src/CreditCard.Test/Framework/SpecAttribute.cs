using System.Runtime.CompilerServices;
using Xbehave;

namespace CreditCard.Test.Framework
{
    public class SpecAttribute : ScenarioAttribute
    {

        public SpecAttribute([CallerMemberName] string memberName = "")
        {
            base.DisplayName = memberName.Replace("_", " ").ToLowerInvariant();
        }
    }
}