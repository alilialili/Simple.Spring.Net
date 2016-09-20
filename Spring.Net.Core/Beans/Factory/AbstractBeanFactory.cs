using Spring.Net.Core.Beans.BeanReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.Net.Core.Beans.Factory
{
    public abstract class AbstractBeanFactory : IBeanFactory
    {
        private Dictionary<string, BeanDefinition> beanDefinitionMap = new Dictionary<string, BeanDefinition>();
        private List<string> beanDefinitionNames = new List<string>();

        public T GetBean<T>(string name)
        {
            BeanDefinition beanDefinition = beanDefinitionMap[name];
            if (beanDefinition.Bean == null)
            {
                CreateBeanInstance(beanDefinition);
                CreateBeanPropertyValues(beanDefinition);
            }
            return (T)beanDefinition.Bean;

        }
        public void RegisterBeanDefinition(string name, BeanDefinition beanDefinition)
        {
            beanDefinitionMap.Add(name, beanDefinition);
            beanDefinitionNames.Add(name);
        }

        private void CreateBeanInstance(BeanDefinition beanDefinition)
        {

            beanDefinition.Bean= Activator.CreateInstance(Type.GetType(beanDefinition.TypeName));

        }

        private void CreateBeanPropertyValues(BeanDefinition beanDefinition)
        {

            foreach (var item in beanDefinition.PropertyValues)
            {
                var pro = beanDefinition.Bean.GetType().GetProperty(item.Name);
                if (CheckObjectTypeIsValueType(pro.PropertyType))
                {
                    pro.SetValue(beanDefinition.Bean, Convert.ChangeType(item.Value, pro.PropertyType), null);
                }
                else {
                    if (item.Value is BeanDefinition)
                    {
                        var refBeanDefinition=item.Value as BeanDefinition;
                        CreateBeanInstance(refBeanDefinition);
                        CreateBeanPropertyValues(refBeanDefinition);
                        pro.SetValue(beanDefinition.Bean, refBeanDefinition.Bean, null);
                    }
                   
                }
               
            }
        }

        private bool CheckObjectTypeIsValueType(Type type) {
           
            if (typeof(int)==type||typeof(string)==type)
            {
                return true;
            }

            return false;
            
                
            
        
        }
    }
}
