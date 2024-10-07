using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaptics.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class UserSettingAttribute : Attribute
    {
        public UserSettingAttribute(string category, string name = "", string description = "")
        {
            Category = category;
            Name = name;
            Description = description;
        }

        public string Category { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
