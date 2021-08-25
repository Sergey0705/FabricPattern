using System;
using System.Collections.Generic;
using System.Text;

namespace HrAPI
{
    public static class FactoryPattern<K,T> where T : class,K,new()
    {
        public static K GetInstanse()
        {
            K objK;
            objK = new T();
            return objK;
        }
    }
}
