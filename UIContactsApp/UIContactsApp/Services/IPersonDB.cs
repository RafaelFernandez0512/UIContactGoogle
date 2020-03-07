
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UIContactsApp.Helpers;

namespace UIContactsApp.AppServices
{
    public interface IPersonDB
    {
        Task<List<Person>> GetItemsAsync();
        Task<int> SaveItemAsync(Person person);
        Task<int> DeleteItemAsync(Person person);
        Task<List<Person>> FindItemsAsync(string name);
        Task<List<Person>> GetGroupsItems(string startWith);
        Task<List<Person>> FavoritePersonAsync();
    }
}
