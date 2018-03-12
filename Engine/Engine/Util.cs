using System;
using System.Collections.Generic;

namespace Engine
{
    public static class Util
    {
        public static void Write(string str)
        {
            Console.WriteLine(str);
        }

        public static void Write(List<string> strList)
        {
            
            Console.WriteLine("String List::");
            foreach(var str in strList)
                Console.WriteLine(str);
            Console.WriteLine("::End Sting List");
        }

        public static void Write<T>(T type)
        {
            Console.WriteLine(type.ToString());
        }

        public static void Write<T>(List<T> typeList)
        {
            Console.WriteLine($"{typeof(T)} List::");
            foreach(var t in typeList)
                Console.WriteLine(t.ToString());
            Console.WriteLine($"::End {typeof(T)} List ");
        }
        
    }
}