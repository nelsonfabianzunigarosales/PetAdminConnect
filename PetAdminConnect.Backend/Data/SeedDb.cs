﻿using Microsoft.EntityFrameworkCore;
using PetAdminConnect.Backend.Services;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IApiService _apiService;

        public SeedDb(DataContext context, IApiService apiService)
        {
            _context = context;
            _apiService = apiService;
        }


        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckSpeciesAsync();
            await CheckCountriesAsync();
        }

        private async Task CheckSpeciesAsync()
        {
            if (!_context.Species.Any())
            {
                _context.Species.Add(new Specie
                {
                    Name = "Mamíferos",
                    Description = "Los mamíferos pertenecen al grupo de los vertebrados. Se caracterizan por tener el cuerpo cubierto de pelaje, por nacer del vientre materno (vivíparos) y por alimentar a las crias con leche por medio de glándulas mamarias.",
                    Breeds = new List<Breed>
                    {
                        new Breed { Name = "Ballena"},
                        new Breed { Name = "Gato"},
                        new Breed { Name = "Caballo"},
                        new Breed { Name = "Nutria"},
                        new Breed { Name = "Perro"},
                        new Breed { Name = "Ornitorrinco"},
                        new Breed { Name = "Hámster"},
                        new Breed { Name = "Gorila"},
                        new Breed { Name = "Jirafa"},
                        new Breed { Name = "León"}
                    }
                });
                _context.Species.Add(new Specie
                {
                    Name = "Aves",
                    Description = "Las aves son una clase de animales vertebrados, que regulan su temperatura, que caminan, saltan o se mantienen solo sobre las extremidades posteriores,3​ mientras que las extremidades anteriores han evolucionado hasta convertirse en alas que, junto con otras características anatómicas únicas, les permiten, a la mayor parte de ellas, volar, si bien no todas vuelan.",
                    Breeds = new List<Breed>
                    {
                        new Breed { Name = "Búho"},
                        new Breed { Name = "Águila"},
                        new Breed { Name = "Cuervo"},
                        new Breed { Name = "Avestruz"},
                        new Breed { Name = "Grulla"},
                        new Breed { Name = "Cigüeña"},
                        new Breed { Name = "Garza"},
                        new Breed { Name = "Gallina"},
                        new Breed { Name = "Codorniz"},
                        new Breed { Name = "Pato"}
                    }
                });
                _context.Species.Add(new Specie
                {
                    Name = "Reptiles",
                    Description = "Son un grupo de animales vertebrados amniotas provistos de escamas epidérmicas de queratina.",
                    Breeds = new List<Breed>
                    {
                        new Breed { Name = "Camaleón"},
                        new Breed { Name = "Águila"},
                        new Breed { Name = "Dragón de Komodo"},
                        new Breed { Name = "Caimán"},
                        new Breed { Name = "Pitón"},
                        new Breed { Name = "Tortuga"},
                        new Breed { Name = "Lagarto cornudo"},
                        new Breed { Name = "Iguana"},
                        new Breed { Name = "Cobra"},
                        new Breed { Name = "Salamanquesa"}
                    }
                });
                _context.Species.Add(new Specie
                {
                    Name = "Ranas y sapos",
                    Description = "Son un grupo de anfibios, con rango taxonómico de orden, conocidos coloquialmente como ranas y sapos.",
                    Breeds = new List<Breed>
                    {
                        new Breed { Name = "Rana verde"},
                        new Breed { Name = "Rana de cristal"},
                        new Breed { Name = "Rana azul"},
                        new Breed { Name = "Rana dorada"},
                        new Breed { Name = "Sapo de arabia"},
                        new Breed { Name = "Sapo de caña"},
                        new Breed { Name = "Sapo de agua"},
                        new Breed { Name = "Sapo americano"},
                        new Breed { Name = "Rana nodriza"},
                        new Breed { Name = "Rana cohete"}
                    }
                });
                _context.Species.Add(new Specie
                {
                    Name = "Peces",
                    Description = "Son animales vertebrados primariamente acuáticos, generalmente ectotérmicos (regulan su temperatura a partir del medio ambiente) y con respiración por branquias.",
                    Breeds = new List<Breed>
                    {
                        new Breed { Name = "Pez león"},
                        new Breed { Name = "Pez espada"},
                        new Breed { Name = "Pez tigre"},
                        new Breed { Name = "Salmón"},
                        new Breed { Name = "Trucha"},
                        new Breed { Name = "Carpa"},
                        new Breed { Name = "Pez dorado"},
                        new Breed { Name = "Pez arcoíris"},
                        new Breed { Name = "Pez betta"},
                        new Breed { Name = "Pez cebra"}
                    }
                });
                _context.Species.Add(new Specie
                {
                    Name = "Ciempiés y milpiés",
                    Description = "Los ciempiés y milpiés pertenecen al subfilo Myriapoda, el cual contiene 13,000 especies. Todos ellos viven en tierra.",
                    Breeds = new List<Breed>
                    {
                        new Breed { Name = "Ciempiés del suelo"},
                        new Breed { Name = "Ciempiés de piedra"},
                        new Breed { Name = "Ciempiés tropicales"},
                        new Breed { Name = "Ciempiés doméstico"},
                        new Breed { Name = "Paurópodos"},
                        new Breed { Name = "Sínfilos"},
                        new Breed { Name = "Chilopoda"},
                        new Breed { Name = "Notostigmophora"},
                        new Breed { Name = "Scutigeromorpha"},
                        new Breed { Name = "Lithobiomorpha"}
                    }
                });
                _context.Species.Add(new Specie
                {
                    Name = "Arañas y alacranes",
                    Description = "Son una clase de artrópodos quelicerados de la que han sido descritas más de 102.000 especies.",
                    Breeds = new List<Breed>
                    {
                        new Breed { Name = "Tarántula"},
                        new Breed { Name = "Viuda negra"},
                        new Breed { Name = "Araña de tierra"},
                        new Breed { Name = "Araña cangrejo"},
                        new Breed { Name = "Escorpión amarillo"},
                        new Breed { Name = "Escorpión emperador"},
                        new Breed { Name = "Escorpión de cola negra"},
                        new Breed { Name = "Alacrán de morelos"},
                        new Breed { Name = "Araña tigre"},
                        new Breed { Name = "Araña violinista"}
                    }
                });
                _context.Species.Add(new Specie
                {
                    Name = "Insectos",
                    Description = "Son una clase de animales invertebrados del filo de los artrópodos, caracterizados por presentar un par de antenas, tres pares de patas y dos pares de alas (que, no obstante, pueden reducirse o faltar).",
                    Breeds = new List<Breed>
                    {
                        new Breed { Name = "Abeja"},
                        new Breed { Name = "Avispa"},
                        new Breed { Name = "Escarabajo"},
                        new Breed { Name = "Cucaracha"},
                        new Breed { Name = "Mariposa"},
                        new Breed { Name = "Mosquito"},
                        new Breed { Name = "Hormiga"},
                        new Breed { Name = "Grillo"},
                        new Breed { Name = "Pulga"},
                        new Breed { Name = "Mantis"}
                    }
                });
                _context.Species.Add(new Specie
                {
                    Name = "Cangrejos y camarones",
                    Description = "Son un extenso subfilo de artrópodos parafilético, con más de 67 000 especies (probablemente, faltan por descubrir hasta cinco o diez veces este número).",
                    Breeds = new List<Breed>
                    {
                        new Breed { Name = "Camarón rojo"},
                        new Breed { Name = "Gamba"},
                        new Breed { Name = "Cangrejo de río"},
                        new Breed { Name = "Cangrejo hermitaño"},
                        new Breed { Name = "Cangrejo cocoteto"},
                        new Breed { Name = "Camarón quisquilla"},
                        new Breed { Name = "Camarón carabinero"},
                        new Breed { Name = "Cangrejo guisante"},
                        new Breed { Name = "Cangrejo azul"},
                        new Breed { Name = "Camarón báltico"}
                    }
                });
                _context.Species.Add(new Specie
                {
                    Name = "Estrellas y erizos",
                    Description = "Pertenecen al grupo de invertebrados marinos, por lo que estos animales comparten características que son representativas del grupo.",
                    Breeds = new List<Breed>
                    {
                        new Breed { Name = "Estrella de espinas"},
                        new Breed { Name = "Estrella de capitán"},
                        new Breed { Name = "Estrella roja"},
                        new Breed { Name = "Erizo diadema"},
                        new Breed { Name = "Erizo flor"},
                        new Breed { Name = "Erizo acorazonado"},
                        new Breed { Name = "Erizo melón"},
                        new Breed { Name = "Estrella de hondura"},
                        new Breed { Name = "Estrella de mar común"},
                        new Breed { Name = "Erizo blanco"}
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                var responseCountries = await _apiService.GetAsync<List<CountryResponse>>("/v1", "/countries");
                if (responseCountries.WasSuccess)
                {
                    var countries = responseCountries.Result!;
                    foreach (var countryResponse in countries)
                    {
                        var country = await _context.Countries.FirstOrDefaultAsync(c => c.Name == countryResponse.Name!)!;
                        if (country == null)
                        {
                            country = new() { Name = countryResponse.Name!, States = new List<State>() };
                            var responseStates = await _apiService.GetAsync<List<StateResponse>>("/v1", $"/countries/{countryResponse.Iso2}/states");
                            if (responseStates.WasSuccess)
                            {
                                var states = responseStates.Result!;
                                foreach (var stateResponse in states!)
                                {
                                    var state = country.States!.FirstOrDefault(s => s.Name == stateResponse.Name!)!;
                                    if (state == null)
                                    {
                                        state = new() { Name = stateResponse.Name!, Cities = new List<City>() };
                                        var responseCities = await _apiService.GetAsync<List<CityResponse>>("/v1", $"/countries/{countryResponse.Iso2}/states/{stateResponse.Iso2}/cities");
                                        if (responseCities.WasSuccess)
                                        {
                                            var cities = responseCities.Result!;
                                            foreach (var cityResponse in cities)
                                            {
                                                if (cityResponse.Name == "Mosfellsbær" || cityResponse.Name == "Șăulița")
                                                {
                                                    continue;
                                                }
                                                var city = state.Cities!.FirstOrDefault(c => c.Name == cityResponse.Name!)!;
                                                if (city == null)
                                                {
                                                    state.Cities.Add(new City() { Name = cityResponse.Name! });
                                                }
                                            }
                                        }
                                        if (state.CitiesNumber > 0)
                                        {
                                            country.States.Add(state);
                                        }
                                    }
                                }
                            }
                            if (country.StatesNumber > 0)
                            {
                                _context.Countries.Add(country);
                                await _context.SaveChangesAsync();
                            }
                        }

                    }
                }
            }
        }
    }
}