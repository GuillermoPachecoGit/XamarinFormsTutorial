using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsTutorial.LocalDatabase
{
    public class Repository<T> where T : class, new()
    {
        private readonly ISQLitePlatform _platform;
        public Repository(ISQLitePlatform platform)
        {
            _platform = platform;
            var con = _platform.GetSQLiteConnection();
            con.CreateTable<T>();
            con.Close();
        }
        public Repository()
        {
            _platform = DependencyService.Get<ISQLitePlatform>();
            var con = _platform.GetSQLiteConnection();
            con.CreateTable<T>();
            con.Close();
        }

        public async Task<bool> AddItemAsync(T item)
        {
            return (await _platform.GetSQLiteAsyncConnection().InsertAsync(item)) > 0;
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            return (await _platform.GetSQLiteAsyncConnection().UpdateAsync(item)) > 0;
        }

        public async Task<bool> DeleteItemAsync(T item)
        {
            return (await _platform.GetSQLiteAsyncConnection().DeleteAsync(item)) > 0;
        }

        public async Task<IEnumerable<T>> GetItemsAsync()
        {
            return await _platform.GetSQLiteAsyncConnection().Table<T>().ToListAsync();
        }
    }
}
