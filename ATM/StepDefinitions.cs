using TechTalk.SpecFlow;

namespace ATM
{
    [Binding]
    public class StepDefinitions
    {

        private readonly AtmSupport atm = new AtmSupport();
        [Given(@"there's (\d+) PLN on user's account")]
        public void GivenThereSMoneyOnUserSAccount(int initialAmount)
        {
            atm.AccountHas(initialAmount);
        }

        [When(@"a user withdraws (\d+) PLN")]
        public void WhenAUserWithdraws(int toWidthdraw)
        {
            atm.Withdraw(toWidthdraw);
        }

        [Then(@"ATM disposes (\d+) PLN")]
        public void ThenATMDisposes(int expectedDisposed)
        {
            atm.AssertDisposed(expectedDisposed);
        }

        [Then(@"there's (\d+) PLN left on user's account")]
        public void ThenThereSMoneyLeftOnUserSAccount(int expectedLeft)
        {
            atm.AssertAccountHas(expectedLeft);
        }


    }
}
