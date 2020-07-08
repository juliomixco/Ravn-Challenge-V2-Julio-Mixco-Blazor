using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SwapiChallenge.Shared;
using SwapiChallenge.Shared.Interfaces;

namespace SwapiChallenge.Infrastructure.Services
{
    public class SwapiRestService : ISwapiService
    {
        public async Task<IEnumerable<Person>> GetPeopleAsync(int page)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://swapi.dev/api/people/?page={page}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var peoplePage = JsonConvert.DeserializeObject<PagedApiResponse< Person>>(apiResponse);
                    return peoplePage.results;
                }
            }
        }
    }
}
