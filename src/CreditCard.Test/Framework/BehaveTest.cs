using System;
using Xbehave;

namespace CreditCard.Test.Framework
{
    public abstract class BehaveTest
    {
        protected void Given(string stepName, Action action)
        {
            $"Given {stepName}".x(action);
        }

        protected void When(string stepName, Action action)
        {
            $"When {stepName}".x(action);
        }

        protected void And(string stepName, Action action)
        {
            $"And {stepName}".x(action);
        }

        protected void Then(string stepName, Action action)
        {
            $"Then {stepName}".x(action);
        }
    }
}
