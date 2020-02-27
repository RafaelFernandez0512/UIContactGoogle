
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
    }
}
