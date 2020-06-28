using System.Linq;
using System.Threading.Tasks;
using Investec.OpenBanking.RestClient.Options;
using Investec.OpenBanking.RestClient.ResponseModels.Accounts;
using Investec.OpenBanking.RestClient.Services;
using Xunit;

namespace IntegrationTests
{
    public class AccountTests
    {
        public AccountTests() =>
            _investecOpenBankingClient = new InvestecOpenBankingClient(
                new InvestecOpenBankingClientOptions
                {
                    ClientId = Constants.ClientId,
                    ClientSecret = Constants.ClientSecret,
                },new ClassificationService());

        private readonly InvestecOpenBankingClient _investecOpenBankingClient;

        [Fact]
        public async Task ValidGetAccountBalance()
        {
            var accounts = await _investecOpenBankingClient.GetAccounts();
            var bankAccount = accounts.data.accounts.FirstOrDefault(f =>
                f.product == AccountsResponseModel.AccountProducts.PrivateBankAccount);
            Assert.NotNull(bankAccount);

            var response = await _investecOpenBankingClient.GetAccountBalance(bankAccount.accountId);
            Assert.NotNull(response);
            Assert.NotNull(response.data);
        }

        [Fact]
        public async Task ValidGetAccounts()
        {
            var response = await _investecOpenBankingClient.GetAccounts();
            Assert.NotNull(response);
            Assert.NotNull(response.data);
            Assert.NotNull(response.data.accounts);
            Assert.NotEmpty(response.data.accounts);
            Assert.All(response.data.accounts, account => Assert.NotNull(account));
            Assert.All(response.data.accounts,
                account => Assert.NotEqual(AccountsResponseModel.AccountProducts.Unknown, account.product));
        }

        [Fact]
        public async Task ValidGetAccountTransactions()
        {
            var accounts = await _investecOpenBankingClient.GetAccounts();
            var bankAccount = accounts.data.accounts.FirstOrDefault(f =>
                f.product == AccountsResponseModel.AccountProducts.PrivateBankAccount);
            Assert.NotNull(bankAccount);

            var response = await _investecOpenBankingClient.GetAccountTransactions(bankAccount.accountId);
            Assert.NotNull(response);
            Assert.NotNull(response.data);
            Assert.NotNull(response.data.transactions);
            Assert.NotEmpty(response.data.transactions);
            Assert.All(response.data.transactions, transaction => Assert.NotNull(transaction));
            Assert.All(response.data.transactions,
                transaction => Assert.NotEqual(AccountTransactionsResponseModel.TransactionTypes.Unknown,
                    transaction.transactionType));
            Assert.All(response.data.transactions,
                transaction => Assert.NotEqual(AccountTransactionsResponseModel.TransactionStatuses.Unknown,
                    transaction.transactionStatus));
        }
    }
}