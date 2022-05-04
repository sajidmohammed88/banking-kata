using System;
using TechTalk.SpecFlow;

namespace Banking.Tests.Acceptance.Steps
{

    [Binding]
    public sealed class BankingAccountOperationsStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private Account _account;
        public BankingAccountOperationsStepDefinitions()
        {
            _account = new Account();
        }

        [Given(@"a client makes a deposit of (.*) on (.*)")]
        [Given(@"a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(int amount, DateTime date)
        {
            _account.Deposit(amount, date);
        }

        [When(@"she prints her bank statement")]
        public void WhenShePrintsHerBankStatement()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"she would see")]
        public void ThenSheWouldSee(string multilineText)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"a withdrawal of (.*) on (.*)")]
        public void GivenAWithdrawalOfOn(int amount, DateTime date)
        {
            _account.Withdraw(amount, date); 
        }
    }
}
