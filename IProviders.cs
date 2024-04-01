using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_1
{
    internal interface IProvider<T>
    {
        T RandomValue();
    }

    class IntProvider : IProvider<int>
    {
        Random rnd = new Random();
        public int RandomValue()
        {
            return rnd.Next();
        }
    }

    class StringProvider : IProvider<string>
    {
        private const string symbols = "QWERTYUIOPASDFGHJKLZXCVBNM";
        public string RandomValue()
        {
            Random rand = new Random();
            int length = 10;
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = symbols[rand.Next(symbols.Length)];
            }
            return new string(chars);
        }
    }

    class BoolProvider : IProvider<bool>
    {
        Random rnd = new Random();
        public bool RandomValue()
        {
            int a = rnd.Next(0, 2);
            bool t = Convert.ToBoolean(a);
            return t;
        }
    }

    class DoubleProvider : IProvider<double>
    {
        Random rnd = new Random();
        public double RandomValue()
        {
            return rnd.NextDouble();
        }
    }
}
