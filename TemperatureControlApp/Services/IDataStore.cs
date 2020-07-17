using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemperatureControlApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddVisitorAsync(T visitor);
        Task<bool> UpdateVisitorAsync(T visitor);
        Task<bool> DeleteVisitorAsync(int id);
        Task<T> GetVisitorAsync(int id);
        Task<IEnumerable<T>> GetVisitorsAsync(bool forceRefresh = false);
    }
}

