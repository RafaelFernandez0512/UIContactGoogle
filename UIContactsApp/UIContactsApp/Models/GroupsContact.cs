using System;
using System.Collections.Generic;
using System.Text;

namespace UIContactsApp.Models
{
    public class GroupsContact:List<Person>
    {
        public string NameLetter { get; private set; }

        public GroupsContact(string nameLetters,List<Person> people):base(people)
        {
            NameLetter = nameLetters;
        }
    }
}
