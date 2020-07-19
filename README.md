# Investec .NET Standard 2.1 REST Client

This client library enables client applications to connect to Investec's Open Banking aligned OpenAPIs. For more information, refer to https://developer.investec.com/programmable-banking/#open-api/. 




## Usage
Register and configure the service with the `AddInvestecOpenBankingClientService` extension method.
```c#
.AddInvestecOpenBankingClientService(options =>
                {
                    options.ClientId = "YourClientId";
                    options.ClientSecret = "YourClientSecret";
                })
```

Inject or resolve the client service.
```c#
var investecOpenBankingClient = serviceProvider.GetService<IInvestecOpenBankingClient>();
```

Interact with the required endpoints.
```c#
// Get all accounts from Investec API
var accounts = await _investecOpenBankingClient.GetAccounts();
// Get the accountId for the first account that is a Private Bank Account
var accountId = accounts.data.accounts.FirstOrDefault(f =>
                f.product == AccountsResponseModel.AccountProducts.PrivateBankAccount)?.accountId;
// Get all transactions for the last 180 days from Investec API
var latestTransactions = await _investecOpenBankingClient.GetAccountTransactions(accountId);
```

## Install via [Nuget.org](https://www.nuget.org/packages/Lionelcc.Investec.OpenBanking/)

`Install-Package Lionelcc.Investec.OpenBanking`

| NuGet Stable | NuGet Pre-release | Downloads |
| ------------ | ----------------- | --------- |
| [![Lionelcc.Investec.OpenBanking](https://img.shields.io/nuget/v/Lionelcc.Investec.OpenBanking.svg)](https://www.nuget.org/packages/Lionelcc.Investec.OpenBanking/) | [![Lionelcc.Investec.OpenBanking](https://img.shields.io/nuget/vpre/Lionelcc.Investec.OpenBanking.svg)](https://www.nuget.org/packages/Lionelcc.Investec.OpenBanking/) | [![Lionelcc.Investec.OpenBanking](https://img.shields.io/nuget/dt/Lionelcc.Investec.OpenBanking.svg)](https://www.nuget.org/packages/Lionelcc.Investec.OpenBanking/) |


## Useful links

* Documentation
  * [Community Projects](https://gitlab.com/offerzen-beta-community/investec-programmable-banking/command-center)
* Samples
  * [Polling Function App](https://github.com/dalion619/investec-openbanking-dotnet/tree/master/examples/Polling.Example.Func)
  * [Transaction Matching Function App](https://github.com/dalion619/investec-openbanking-dotnet/tree/master/examples/Matching.Example.Func)

