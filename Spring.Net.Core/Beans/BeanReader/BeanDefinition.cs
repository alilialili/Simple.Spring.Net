using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Spring.Net.Core.Beans.BeanReader
{
   public class BeanDefinition
    {

       public BeanDefinition() {
           PropertyValues = new List<PropertyValue>();
       }

       public object Bean { get; set; }

       public List<PropertyValue> PropertyValues { get; set; }

       public string TypeName { get; set; }

       
    }
}
