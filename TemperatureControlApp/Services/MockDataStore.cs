using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureControlApp.Models;

namespace TemperatureControlApp.Services
{
    public class MockDataStore : IDataStore<VisitorModel>
    {
        readonly List<VisitorModel> items;

        public MockDataStore() {}

        public async Task<bool> AddVisitorAsync(VisitorModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateVisitorAsync(VisitorModel item)
        {
            var oldVisitor = items.Where((VisitorModel arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(oldVisitor);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteVisitorAsync(int id)
        {
            var oldVisitor = items.Where((VisitorModel arg) => arg.ID == id).FirstOrDefault();
            items.Remove(oldVisitor);

            return await Task.FromResult(true);
        }

        public async Task<VisitorModel> GetVisitorAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<VisitorModel>> GetVisitorsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}