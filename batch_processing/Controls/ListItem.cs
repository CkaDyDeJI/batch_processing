using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batch_processing
{
    public class ListItem
    {
        public string Dir { get; private set; }
        public string Name { get; private set; }
        public string FullName { get; private set; }

        public ListItem(string d, string n)
        {
            Dir = d;
            Name = n;
            FullName = d + "\\" + n;
        }
    }
}
