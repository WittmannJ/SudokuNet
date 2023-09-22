using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuNet
{
    public class Generator
    {

        public Generator() { }
        public async Task<Grid> GenerateGridAsync(GenerationTypes generationType = GenerationTypes.zeros)
        {
            switch (generationType)
            {
                case GenerationTypes.zeros:
                    return new Grid();

                case GenerationTypes.web:
                    return await GetGridFromWebApi();

                default:
                    return new Grid();


            }
        }

        public async Task<Grid> GetGridFromWebApi()
        {
            string url = "https://sugoku.onrender.com/board?difficulty=hard";
            JsonFetcher jsonFetcher = new JsonFetcher();

            try
            {
                string jsonArray = await jsonFetcher.FetchJsonArrayFromUrlAsync(url);

                if (jsonArray != null)
                {
                    // Process the JSON array as needed
                    GetPreGeneratedGridDto getPreGeneratedGridDto = JsonConvert.DeserializeObject<GetPreGeneratedGridDto>(jsonArray);
                    var preGeneratedGrid = new Grid(getPreGeneratedGridDto);
                    return preGeneratedGrid;
                }
                else
                {
                    Console.WriteLine("Failed to fetch JSON array from the URL.");
                    return new Grid();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return new Grid();
        }
    }
}
