using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.Net.Core.Beans.BeanReader
{
   public class PropertyValue
    {
       public PropertyValue(string name,object value) 
       {
           this.Name = name;
           this.Value = value;
       }

       public string Name { get; set; }

       public object Value { get; set; }
    }
}
