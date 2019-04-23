using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;
<<<<<<< HEAD
using Polly;
using System.Net;
=======
>>>>>>> 1948cc2fb01ecba111675272d5f13a0034c03987

namespace CurrencyConverterService
{
    public class CurrencyConverter : ICurrencyConverter
    {
        const string ALL_CURRENCIES_URL = "https://free.currencyconverterapi.com/api/v5/currencies";
        HttpClient _httpClient;

        public CurrencyConverter()
        {
            _httpClient = new HttpClient();
            _httpClient.MaxResponseContentBufferSize = 256000;
        }
        
        public async Task<double> ConvertCurrencyAsync(string currencyFromID, string currencyToID, double value)
        {
            var url = $"https://free.currencyconverterapi.com/api/v5/convert?q={currencyFromID}_{currencyToID}&compact=ultra";

            try
            {
<<<<<<< HEAD
                var response = await QueryCurrencyServiceWithRetryPolicy(() => _httpClient.GetAsync(url));
=======
                var response = await _httpClient.GetAsync(url);
>>>>>>> 1948cc2fb01ecba111675272d5f13a0034c03987
                var content = (await response.Content.ReadAsStringAsync());
                var q = JsonConvert.DeserializeObject<Dictionary<string, double>>(content);
                var kv = q.First();

                var total = value * kv.Value;
                //var result = (Math.Ceiling(total * 100) / 100);

                return total;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

<<<<<<< HEAD
        async Task<HttpResponseMessage> QueryCurrencyServiceWithRetryPolicy(Func<Task<HttpResponseMessage>> action)
        {
            int numberOfTimesToRetry = 7;
            int retryMultiple = 2;
            var response = await Policy.Handle<HttpRequestException>(ex =>
            {
                Debug.WriteLine("Request failed due to connectivity issues.");
                return true;
            })
            .WaitAndRetryAsync(numberOfTimesToRetry, retryCount => TimeSpan.FromSeconds(retryCount * retryMultiple))
            .ExecuteAsync(async () =>
            await action());
            return response;
        }

=======
>>>>>>> 1948cc2fb01ecba111675272d5f13a0034c03987
        public async Task<GlobalCurrencies> GetAllCurrenciesAsync()
        {
            GlobalCurrencies globalCurrencies = null;

            try
            {
<<<<<<< HEAD
                var response = await QueryCurrencyServiceWithRetryPolicy(() => 
                _httpClient.GetAsync(ALL_CURRENCIES_URL));
                
=======
                var response = await _httpClient.GetAsync(ALL_CURRENCIES_URL);
>>>>>>> 1948cc2fb01ecba111675272d5f13a0034c03987
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    globalCurrencies = JsonConvert.DeserializeObject<GlobalCurrencies>(content);
                    globalCurrencies.Results.Select(cur =>
                    {
                        if (cur.Value.CurrencyName.Contains("CFA"))
                            cur.Value.CurrencySymbol = "FCFA";

                        return cur;
                    });
                }
                else
                {
<<<<<<< HEAD
                    throw new CurrencyLoadException();
=======
                    throw new Exception("The Service is either un available or I could not connect to internet");
>>>>>>> 1948cc2fb01ecba111675272d5f13a0034c03987
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw e;
            }

            return globalCurrencies;
        }

        public async Task<KeyValuePair<string, double>> GetConvertQuerryAsync(string currencyFromID, string currencyToID)
        {
            var url = $"https://free.currencyconverterapi.com/api/v5/convert?q={currencyFromID}_{currencyToID}&compact=ultra";

            try
            {
                var response = await _httpClient.GetAsync(url);
                var content = (await response.Content.ReadAsStringAsync());
                var q = JsonConvert.DeserializeObject<Dictionary<string, double>>(content);
                var kv = q.First();

                return kv;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
    }
}
