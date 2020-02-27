using System;
using System.Collections.Generic;
using System.Text;

namespace UIContactsApp.Helpers
{
    public class MenuMasterItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
