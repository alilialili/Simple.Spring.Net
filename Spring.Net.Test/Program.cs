using Spring.Net.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.Net.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext applicationContext = new ClassPathXmlApplicationContext("test.xml");
            applicationContext.GetBean<ISpirngTest>("SpringTest").HelloWorld("SpringTest");
            applicationContext.GetBean<ISpirngTest>("SpringTest").HelloWorld("SpringTest");
            applicationContext.GetBean<ISpirngTest>("SpringTest").HelloWorld("SpringTest");
            applicationContext.GetBean<ISpirngTest>("SpringTest").HelloWorld("SpringTest");
            applicationContext.GetBean<ISpirngTest>("SpringTest").HelloWorld("SpringTest");
            applicationContext.GetBean<ISpirngTest>("SpringTest1").HelloWorld("SpringTest1");
            Console.Read();
        }
    }
    public interface ISpirngTest {

        void HelloWorld(string message);
    }

    public class SpringTest : ISpirngTest
    {
        public string TestProty { get; set; }

        public int TestIntProty { get; set; }

        public RefSpringTest RefSpringTest { get; set; }

        public void HelloWorld(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(TestProty);
            Console.WriteLine(TestIntProty);
            Console.WriteLine(RefSpringTest.TestProty);
        }
    }
    public class SpringTest1 : ISpirngTest
    {
        public string TestProty { get; set; }
        public void HelloWorld(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(TestProty);
        }
    }

    public class RefSpringTest 
    {
        public string TestProty { get; set; }
    }
}
