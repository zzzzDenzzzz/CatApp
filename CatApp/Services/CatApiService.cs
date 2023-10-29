namespace CatApp.Services
{
    public class CatApiService
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        HttpClient HttpClient { get; set; }

        public CatApiService()
        {
            BaseUrl = "https://api.thecatapi.com/v1/images/";
            ApiKey = "live_5TjJWZ303DdAFUFMXRcP77wtl9TqXjlT8NfaLde64LgI7U8DEPwRxb2rpLifoLKs";
            HttpClient = new();
        }

        public async Task<string> SearchByBreedAsync(string breed)
        {
            var response = await HttpClient.GetAsync($"{BaseUrl}search?limit=100&breed_ids={breed[..4]}&api_key={ApiKey}");
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
