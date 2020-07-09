using Investec.OpenBanking.RestClient.ResponseModels.Accounts;

namespace Investec.OpenBanking.RestClient.ResponseModels
{
    public class NotificationModel
    {
        public NotificationModel()
        {
        }

        public NotificationModel(AccountTransactionsResponseModel.TransactionResponse transaction)
        {
            accountId = transaction.accountId;
            type = transaction.type;
            status = transaction.status;
            description = transaction.description;
            cardNumber = transaction.cardNumber;
            postingDate = transaction.postingDate;
            valueDate = transaction.valueDate;
            amount = transaction.amount;
        }

        public string accountId { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string cardNumber { get; set; }
        public string postingDate { get; set; }
        public string valueDate { get; set; }
        public decimal amount { get; set; }
    }
}