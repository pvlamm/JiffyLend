namespace JiffyLend.Core.Infrastructure.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

using JiffyLend.Core.Infrastructure.Interfaces;
using JiffyLend.Core.Infrastructure.Models;

public class CoreHttpClient : ICoreHttpClient
{
    private readonly HttpClient _httpClient;
    public CoreHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AccountInfo> GetAccountInfo(Guid accountId, CancellationToken token)
    {
        var responseMessage = await _httpClient.GetAsync($"/account/{accountId}", token);

        if (!responseMessage.IsSuccessStatusCode)
            return null;


        return await responseMessage.Content.ReadFromJsonAsync<AccountInfo>(token);
    }

    public async Task<CustomerInfo> GetCustomerInfo(Guid customerId, CancellationToken token)
    {
        var responseMessage = await _httpClient.GetAsync($"/account/{customerId}", token);

        if (!responseMessage.IsSuccessStatusCode)
            return null;

        return await responseMessage.Content.ReadFromJsonAsync<CustomerInfo>(token);
    }
}
