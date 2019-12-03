using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokemonMVVM.Models;

namespace PokemonMVVM.DAL
{
    class PokemonAPIDAL
    {
        const string LOADALL_URL = "https://pokeapi.co/api/v2/pokemon/";
        //Chercher la donnée
        public static async Task<List<Pokemon>> LoadPokemons()
        {
            WebClient wc = new WebClient();
            byte[] data = await wc.DownloadDataTaskAsync(new Uri(LOADALL_URL));
            string json = Encoding.UTF8.GetString(data);
            PokemonAPIResult result = JsonConvert.DeserializeObject<PokemonAPIResult>(json);

            return result.Results;
        }
        public static async Task<Pokemon> LoadPokemon(Pokemon pokemon)
        {
            WebClient wc = new WebClient();
            byte[] data = await wc.DownloadDataTaskAsync(new Uri(pokemon.Url));
            string json = Encoding.UTF8.GetString(data);
            Pokemon result = JsonConvert.DeserializeObject<Pokemon>(json);

            return result;
        }
    }
}
