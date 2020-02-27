using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UIContactsApp.Helpers
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID_Person { get; set; }
        public string ImagePerson { get; set; }
        public string NamePerson { get; set; }
        public string NickName { get; set; }
        public string SecondName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string NameBusiness { get; set; }
        public string Location { get; set; }
        public string WebSite { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Note  { get; set; }
        public string Relationship { get; set; }
        public int FrameColor { get; set; }
        public string Phone { get; set; }
        public bool IsFavorite { get; set; }

        [Ignore]
        public string FullName
        {
            get
            {
                if (!NickName.IsEmptyString())
                    return $"{NamePerson} {Lastname}";
                else
                    return NickName;
            }
        }
        public Person()
        {
            DateOfBirth = DateTime.Now;
            IsFavorite = false;
        }
    }
}
