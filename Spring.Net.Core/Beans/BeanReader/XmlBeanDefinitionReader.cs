using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Spring.Net.Core.Beans.BeanReader
{
   public class XmlBeanDefinitionReader:AbstractBeanDefinitionReader
    {
       

       public override void loadBeanDefinitions(string location)
       {
           doloadBeanDefinitions(location);
       }
       private void doloadBeanDefinitions(string location)
       {
           XmlDocument xml = new XmlDocument();
           xml.Load(location);
           XmlNodeList xmlNodeList = xml.SelectSingleNode("beans").ChildNodes;
           foreach (XmlNode node in xmlNodeList)
           {
               BuildBeanDefinition(node);
              
           }
       }

       private void BuildBeanDefinition(XmlNode xmlNode)
       {
           BeanDefinition bean = new BeanDefinition();
           string name = xmlNode.Attributes["id"].InnerText;
           string typeName = xmlNode.Attributes["type"].InnerText;
           bean.TypeName = typeName;
           BuildBeanDefinitionPropertyValues(xmlNode,bean);
           Registry.Add(name, bean);
       }

       private void BuildBeanDefinitionPropertyValues(XmlNode xmlNode, BeanDefinition beanDefinition) 
       {
           XmlNodeList xmlNodeList = xmlNode.SelectNodes("Property");
           foreach (XmlNode node in xmlNodeList)
           {
               string name = node.Attributes["name"].InnerText;
               var value = node.Attributes["value"];
               if (value != null)
               {
                   beanDefinition.PropertyValues.Add(new PropertyValue(name, value.InnerText));
               }
               else 
               {
                   string refObject = node.Attributes["ref"].InnerText;
               }
           }
       }
    
      
    }
}
