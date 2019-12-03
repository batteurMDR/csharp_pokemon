using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonMVVM.Models;
using PokemonMVVM.DAL;

namespace PokemonMVVM.ViewModels
{
    class PokedexViewModel : INotifyPropertyChanged
    {

        private List<Pokemon> pokemons;

        public List<Pokemon> Pokemons {
            get
            {
                return pokemons;
            }
            set
            {
                pokemons = value;
                OnPropertyChange("Pokemons");
            }
        }

        private Pokemon selectedPokemon;

        public Pokemon SelectedPokemon
        {
            get
            {
                return selectedPokemon;
            }
            set
            {
                LoadPokemon(value);
                OnPropertyChange("SelectedPokemon");
            }
        }

        public async void LoadPokemon(Pokemon pokemon)
        {
            selectedPokemon = await PokemonAPIDAL.LoadPokemon(pokemon);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public PokedexViewModel()
        {
            LoadPokemons();
        }

        public async void LoadPokemons()
        {
            Pokemons = await PokemonAPIDAL.LoadPokemons();
        }

    }
}
