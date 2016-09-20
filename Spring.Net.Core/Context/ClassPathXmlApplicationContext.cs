using Spring.Net.Core.Beans.BeanReader;
using Spring.Net.Core.Beans.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.Net.Core.Context
{
   public class ClassPathXmlApplicationContext:AbstractApplicationContext
    {
       private string configLocation;


       public ClassPathXmlApplicationContext(string configLocation)
           : this(configLocation,new AutowireCapableBeanFactory())
       {
       
       }
       public ClassPathXmlApplicationContext(String configLocation, AbstractBeanFactory beanFactory)
           : base(beanFactory)
       {

           this.configLocation =System.Environment.CurrentDirectory+"\\"+configLocation;
           Refresh();

       }
       protected override void loadBeanDefinitions(AbstractBeanFactory beanFactory)
       {
           XmlBeanDefinitionReader beanDefinitionReader = new XmlBeanDefinitionReader();
           beanDefinitionReader.loadBeanDefinitions(configLocation);
           foreach (var item in beanDefinitionReader.Registry)
           {
               beanFactory.RegisterBeanDefinition(item.Key, item.Value);

           }
       }
    }
}
