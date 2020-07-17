using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureControlApp.Models;

namespace TemperatureControlApp.Services
{
    public class TemperatureDataStore : TDataStore<TemperatureModel>
    {
        readonly List<TemperatureModel> temperatures;

        public TemperatureDataStore() { }

        public async Task<bool> AddTemperatureAsync(TemperatureModel temperature)
        {
            temperatures.Add(temperature);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateTemperatureAsync(TemperatureModel temperature)
        {
            var oldTemperature = temperatures.Where((TemperatureModel arg) => arg.ID == temperature.ID).FirstOrDefault();
            temperatures.Remove(oldTemperature);
            temperatures.Add(temperature);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteTemperatureAsync(int id)
        {
            var oldTemperature = temperatures.Where((TemperatureModel arg) => arg.ID == id).FirstOrDefault();
            temperatures.Remove(oldTemperature);

            return await Task.FromResult(true);
        }

        public async Task<TemperatureModel> GetTemperatureAsync(int id)
        {
            return await Task.FromResult(temperatures.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<TemperatureModel>> GetTemperaturesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(temperatures);
        }
    }
}
