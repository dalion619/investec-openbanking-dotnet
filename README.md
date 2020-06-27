# Investec.OpenBanking.NetStd
.NET Standard 2.1 REST client for [Investec's Open Banking aligned APIs](https://developer.investec.com/programmable-banking/#open-api).

## Documentation
This client is built with [Refit](https://github.com/reactiveui/refit). The interfaces match the OpenAPI docs.

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
var accounts = await investecOpenBankingClient.GetAccounts();
```
