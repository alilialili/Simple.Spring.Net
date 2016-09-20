using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.Net.Core.Beans.BeanReader
{
  public abstract  class AbstractBeanDefinitionReader:IBeanDefinitionReader
    {

   
      public Dictionary<string, BeanDefinition> Registry { get; set; }

      protected AbstractBeanDefinitionReader()
      {

          this.Registry = new Dictionary<string, BeanDefinition>();
      }




      public virtual void loadBeanDefinitions(string location)
      {
      }
    }
}
