using Microsoft.EntityFrameworkCore;
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
            await CheckBreedsAsync();
            await CheckCountriesAsync();
        }

        private async Task CheckSpeciesAsync()
        {
            if (!_context.Species.Any())
            {
                _context.Species.Add(new Specie { Name = "Mamíferos" });
                _context.Species.Add(new Specie { Name = "Aves" });
                _context.Species.Add(new Specie { Name = "Reptiles" });
                _context.Species.Add(new Specie { Name = "Ranas y sapos" });
                _context.Species.Add(new Specie { Name = "Peces" });
                _context.Species.Add(new Specie { Name = "Ciempiés y milpiés" });
                _context.Species.Add(new Specie { Name = "Arañas y alacranes" });
                _context.Species.Add(new Specie { Name = "Insectos" });
                _context.Species.Add(new Specie { Name = "Cangrejos y camarones" });
                _context.Species.Add(new Specie { Name = "Estrellas y erizos" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckBreedsAsync()
        {
            if (!_context.Breeds.Any())
            {
                _context.Breeds.Add(new Breed { Name = "Colombia" });
                _context.Breeds.Add(new Breed { Name = "Peru" });
                _context.Breeds.Add(new Breed { Name = "Ecuador" });
                _context.Breeds.Add(new Breed { Name = "Chile" });
                _context.Breeds.Add(new Breed { Name = "Argentina" });
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