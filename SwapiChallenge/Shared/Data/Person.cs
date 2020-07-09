using SwapiChallenge.Shared.Interfaces;
using SwapiChallenge.Shared.Swapi;
using System;
using System.Collections.Generic;

namespace SwapiChallenge.Shared.Data
{
    public class Person : IPerson
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string url { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public Planet homeworld { get; set; }
        public List<string> films { get; set; }
        public List<Species> species { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> starships { get; set; }
        public Person() { }
        public Person(
            IPerson personInfo,
            Planet homeworld,
            List<Species> species,
            List<string> films,
            List<string> vehicles,
            List<string> starships
        )
        {
            name = personInfo.name;
            height = personInfo.height;
            mass = personInfo.mass;
            hair_color = personInfo.hair_color;
            skin_color = personInfo.skin_color;
            eye_color = personInfo.eye_color;
            birth_year = personInfo.birth_year;
            gender = personInfo.gender;
            created = personInfo.created;
            edited = personInfo.edited;
            url = personInfo.url;

            this.films = films;
            this.species = species;
            this.vehicles = vehicles;
            this.starships = starships;
            this.homeworld = homeworld;

        }

    }

}
