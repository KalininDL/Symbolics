using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class Variables
    {
        static Number nil = new Number(0);
        private static Dictionary<String, Value> variables;
        private static Stack<Dictionary<String, Value>> stack;

        static Variables()
        {
            stack = new Stack<Dictionary<string, Value>>();
            variables = new Dictionary<string, Value>();
            variables.Add("pi", new Number(Math.PI));
            variables.Add("e", new Number(Math.E));
        }

        public static void push()
        {
            stack.Push(new Dictionary<string, Value>(variables));
        }

        public static void pop()
        {
            variables = stack.Pop();
        }



        public static bool isExists(string key)
        {
            return variables.ContainsKey(key);
        }

        public static Value get(string key)
        {
            if (!isExists(key))
            {              
                return nil;
            }
            else return variables[key];
        }

        public static void add(string key, Value value)
        {
            if (!variables.ContainsKey(key))
                variables.Add(key, value);
            else
                variables[key] = value;
        }
    }
}
