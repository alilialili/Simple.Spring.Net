using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.Net.Core.Beans.Factory
{
    public interface IBeanFactory
    {
        T GetBean<T>(string name);
    }
}
