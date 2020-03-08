
using Xbehave;
using FluentAssertions;
using CreditCard.Test.Framework;
using System;

namespace CreditCard.Test
{
    public class CreditCardTests: BehaveTest
    {
        [Scenario]
        public void Cannot_Assing_Limit_For_The_Second_Time(CreditCard creditCard)
        {
            Given("A card", () => {
                creditCard = new CreditCard(Guid.NewGuid());
            });

            When("I assign limit", () => {
                creditCard.AssignLimit(100);
            });

            Then("Reassign limit is not allowed", () =>{
                Action act = () => creditCard.AssignLimit(150); 

                act.Should().Throw<InvalidOperationException>();
            });
        }

        [Scenario]
        public void Can_Assign_Limit_To_A_Card(CreditCard creditCard)
        {
            Given("A card", () => {
                creditCard = new CreditCard(Guid.NewGuid());
            });

            When("I assign limit of 150", () => {
                creditCard.AssignLimit(150);
            });

            Then("Avaliable limit should by 150", () => {
                creditCard.AvaliableLimit.Should().Be(150);
            });
        }

        [Scenario]
        public void Cannot_Withdraw_When_Not_Enough_Money(CreditCard creditCard, Action withdrawAction)
        {
            Given("A card with a limit of 150", () => {
                creditCard = new CreditCard(Guid.NewGuid());
                creditCard.AssignLimit(150);
            });

            When("I withdraw 200", () => {
                withdrawAction = () => creditCard.WithDraw(200);
            });

            Then("Withdrawing should be forbidden", () => {
                withdrawAction.Should().Throw<InvalidOperationException>();
            });
        }

        [Scenario]
        public void Can_Withdraw_From_A_Card(CreditCard creditCard)
        {
            Given("a credit card with 100 limit", () => {
                creditCard = new CreditCard(Guid.NewGuid());
                creditCard.AssignLimit(100);
            });

            When("I withdraw 60", () => {
                creditCard.WithDraw(60);
            });

            Then("Avaliable limit should be 40", () => {
                creditCard.AvaliableLimit.Should().Be(40);
            });
        }

        [Scenario]
        public void Can_Repay_A_Card(CreditCard creditCard)
        {
            Given("a credit card with 100 limit", () => {
                creditCard = new CreditCard(Guid.NewGuid());
                creditCard.AssignLimit(100);
            });

            When("I withdraw 60", () => {
                creditCard.WithDraw(60);
            });

            And("I repay 40", () => {
                creditCard.Repay(40);
            });

            Then("Avaliable limit should be 80", () => {
                creditCard.AvaliableLimit.Should().Be(80);
            });
        }
    }
}
