using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace UIContactsApp.Helpers
{
    public class GroupsContact:ObservableCollection<Person>
    {
        public string NameLetter { get; private set; }
        public GroupsContact(string nameLetters, List<Person> people) : base(people)
        {
            NameLetter = nameLetters;
        }
    }
}
