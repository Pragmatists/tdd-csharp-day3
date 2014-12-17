using NUnit.Framework;

namespace ATM
{
    internal class AtmSupport
    {
        private Account account;

        public void AssertAccountHas(int expectedLeft)
        {
            Assert.That(account.Amount, Is.EqualTo(expectedLeft));
        }

        public void AccountHas(int initialAmount)
        {
            account = new Account() {Amount = initialAmount};
        }

        public void Withdraw(int toWidthdraw)
        {
        }

        public void AssertDisposed(int expectedDisposed)
        {
            
        }
    }

    internal class Account
    {
        public int Amount { get; set; }
    }
}