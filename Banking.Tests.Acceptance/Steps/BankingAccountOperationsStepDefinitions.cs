using System;
using TechTalk.SpecFlow;

namespace Banking.Tests.Acceptance.Steps
{

    [Binding]
    public sealed class BankingAccountOperationsStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private Account _account;
        private Printer _printer;
        private string _printedResult;

        public BankingAccountOperationsStepDefinitions()
        {
            _account = new Account();
            _printer = new Printer();
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
            Statement statement = _account.Statement;
            _printedResult = _printer.Print(statement);
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
