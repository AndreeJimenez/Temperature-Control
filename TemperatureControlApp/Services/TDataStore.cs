using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemperatureControlApp.Services
{
    public interface TDataStore<T>
    {
        Task<bool> AddTemperatureAsync(T temperature);
        Task<bool> UpdateTemperatureAsync(T temperature);
        Task<bool> DeleteTemperatureAsync(int id);
        Task<T> GetTemperatureAsync(int id);
        Task<IEnumerable<T>> GetTemperaturesAsync(bool forceRefresh = false);
    }
}
