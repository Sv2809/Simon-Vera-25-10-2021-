using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TodoList.Models;

namespace TodoList.Services
{
    public class Item_B
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<Item_B> Instance = new AsyncLazy<Item_B>(async () =>
        {
            var instance = new Item_B();
            CreateTableResult result = await Database.CreateTableAsync<Item>();
            return instance;
        });

        public Item_B()
        {
            Database = new SQLiteAsyncConnection(DbContext.DatabasePath, DbContext.Flags);
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return Database.Table<Item>().ToListAsync();
        }

        public Task<List<Item>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Item>("SELECT * FROM [Item] WHERE [Done] = 0");
        }

        public Task<Item> GetItemAsync(int id)
        {
            return Database.Table<Item>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            return item.ID != 0 ? Database.UpdateAsync(item) : Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
