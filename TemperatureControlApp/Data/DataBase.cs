using TemperatureControlApp.Extensions;
using TemperatureControlApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureControlApp.Data
{
    public class DataBase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() => {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;

        static bool initialized = false;

        public DataBase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(VisitorModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(VisitorModel)).ConfigureAwait(false);
                    initialized = true;
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(TemperatureModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(TemperatureModel)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<VisitorModel>> GetAllVisitorsAsync()
        {
            return Database.Table<VisitorModel>().ToListAsync();
        }

        public Task<List<TemperatureModel>> GetAllTemperaturesAsync()
        {
            return Database.Table<TemperatureModel>().ToListAsync();
        }

        public Task<VisitorModel> GetVisitorAsync(int id)
        {
            return Database.Table<VisitorModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<TemperatureModel> GetTemperatureAsync(int id)
        {
            return Database.Table<TemperatureModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveVisitorAsync(VisitorModel item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> SaveTemperatureAsync(TemperatureModel temperature)
        {
            if (temperature.ID != 0)
            {
                return Database.UpdateAsync(temperature);
            }
            else
            {
                return Database.InsertAsync(temperature);
            }
        }

        public Task<int> DeleteVisitorAsync(VisitorModel item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<int> DeleteTemperatureAsync(TemperatureModel temperature)
        {
            return Database.DeleteAsync(temperature);
        }
    }
}
