
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UIContactsApp.AppServices;
using UIContactsApp.Models;

namespace ContactUIAndroid.App.Services
{
    public class PersonDB : IPersonDB
    {
        readonly SQLiteAsyncConnection database;
        public PersonDB(string path)
        {
            this.database = new SQLiteAsyncConnection(path);
            this.database.CreateTableAsync<Person>().Wait();
        }
        public Task<int> DeleteItemAsync(Person person)
        {
            return database.DeleteAsync(person);
        }

        public Task<List<Person>> GetItemsAsync()
        {
            return database.Table<Person>().ToListAsync();
        }
        public Task<List<Person>> GetGroupsItems(string startWith)
        {
            return database.Table<Person>().Where(e=>e.NamePerson.StartsWith(startWith)).ToListAsync();
        }
        public Task<List<Person>> FindItemsAsync(string name)
        {
            return database.Table<Person>().Where(e=> e.NamePerson.Contains(name)||e.NickName.Contains(name)).ToListAsync();
        }
        public Task<List<Person>> FavoritePersonAsync()
        {
            return database.Table<Person>().Where(e => e.IsFavorite==true).ToListAsync();
        }

        public Task<int> SaveItemAsync(Person person)
        {
            try
            {
                if (person.ID_Person != 0)
                {
                    return database.UpdateAsync(person);
                }
                else
                {
                    return database.InsertAsync(person);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
