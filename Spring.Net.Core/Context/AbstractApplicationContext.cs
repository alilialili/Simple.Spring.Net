using Spring.Net.Core.Beans.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.Net.Core.Context
{
    public abstract class AbstractApplicationContext : IApplicationContext
    {
        protected AbstractBeanFactory beanFactory;


        public AbstractApplicationContext(AbstractBeanFactory beanFactory)
        {
            this.beanFactory = beanFactory;
        }

        public void Refresh() {
            loadBeanDefinitions(beanFactory);
        } 

        public T GetBean<T>(string name)
        {
            return beanFactory.GetBean<T>(name);
        }
        protected abstract void loadBeanDefinitions(AbstractBeanFactory beanFactory);
    }
}
