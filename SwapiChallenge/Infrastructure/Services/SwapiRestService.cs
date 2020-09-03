using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SwapiChallenge.Shared;
using SwapiChallenge.Shared.Data;
using SwapiChallenge.Shared.Interfaces;
using SwapiChallenge.Shared.Swapi;

namespace SwapiChallenge.Infrastructure.Services
{
    public class SwapiRestService : ISwapiService
    {
        public async Task<IEnumerable<Person>> GetPeopleAsync(int page)
        {
            var people = await RequestAllPeople(page);
            var enhancedPeople = await Task.WhenAll(people.Select(async p => await EnhancePerson(p)));
            return enhancedPeople;
        }

        private async Task<IEnumerable<SwapiPerson>> RequestAllPeople(int page)
        {
            var peoplePage = await GetRequest<PagedApiResponse<SwapiPerson>>($"https://swapi.dev/api/people/?page={page}");
            return peoplePage.results;
        }

        private async Task<Planet> RequestPlanet(string url) => await GetRequest<Planet>(url);

        private async Task<Species> RequestSpecies(string url) => await GetRequest<Species>(url);
        private async Task<Vehicle> RequestVehicle(string url) => await GetRequest<Vehicle>(url);

        private async Task<Person> EnhancePerson(SwapiPerson person)
        {
            var homeworldRequest = RequestPlanet(person.homeworld);
            var speciesTsks = person.species.Select(s => RequestSpecies(s));
            var vehicleTsks = person.vehicles.Select(s => RequestVehicle(s));

            var homeworld = await homeworldRequest;
            var species = (await Task.WhenAll(speciesTsks)).ToList();
            var vehicles = (await Task.WhenAll(vehicleTsks)).ToList();

            return new Person(
                person,
                homeworld,
                species,
                person.films,
                vehicles,
                person.starships
             );
        }

        private async Task<T> GetRequest<T>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }
        }

    }
}
