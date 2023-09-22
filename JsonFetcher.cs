using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuNet
{
    public class JsonFetcher
    {
        public async Task<string> FetchJsonArrayFromUrlAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        return json;
                    }
                    else
                    {
                        // Handle HTTP error (e.g., 404, 500)
                        Console.WriteLine($"HTTP Error: {response.StatusCode}");
                        return null;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle network-related exceptions
                Console.WriteLine($"HttpRequestException: {ex.Message}");
                return null;
            }
        }
    }
}
