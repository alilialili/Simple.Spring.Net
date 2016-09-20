using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.Net.Core.Beans.BeanReader
{
   public interface IBeanDefinitionReader
    {
       void loadBeanDefinitions(string location);
    }
}
