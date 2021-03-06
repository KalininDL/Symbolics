﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    //class Functions : IFunction
    //{
    //    static Number nil = new Number(0);
    //    private static Dictionary<String, Delegate> functions;

    //    static Functions()
    //    {
    //        functions = new Dictionary<string, Delegate>();

    //        functions.Add("sin", new Func<Value[], Value>(Sin));
    //        functions.Add("cos", new Func<Value[], Value>(Cos));
    //        functions.Add("echo", new Func<Value[], Value>(Echo));
    //    }



    //    private static bool isExists(string key)
    //    {
    //        return functions.ContainsKey(key);
    //    }

    //    private static Value Echo(Value[] n)
    //    {
    //        foreach (Value val in n)
    //        {
    //            Console.WriteLine(val);
    //        }
    //        return nil;
    //    }

    //    private static Value Sin(Value[] n)
    //    {
    //        if (n.Length > 1) { throw new ArgumentException(); }
    //        else
    //        return new Number(Math.Sin(n[0].asDouble()));
    //    }

    //    private static Number Cos(Value[] n)
    //    {
    //        if (n.Length > 1) { throw new ArgumentException(); }
    //        else
    //            return new Number(Math.Cos(n[0].asDouble()));
    //    }



    //    public static Delegate get(string key)
    //    {
    //        if (!isExists(key))
    //        {
    //            throw new Exception("Function " + key + " not found");
    //        }
    //        else return functions[key];
    //    }

    //    public static void add(string key, Delegate function)
    //    {
    //        if (!functions.ContainsKey(key))
    //            functions.Add(key, function);
    //        else
    //            functions[key] = function;
    //    }

    //    public Value execute(params Value[] args)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    class Sin : IFunction
    {
        public Value execute(params Value[] args)
        {
            if (args.Length > 1) { throw new ArgumentException(); }
            else
                return new Number(Math.Sin(args[0].asDouble()));
        }
    }

    class NEWARRAY : IFunction
    {
        public Value execute(params Value[] args)
        {
                return createArray(args, 0);
        }

        private Array createArray(Value[] args, int index)
        {
            int size = (int)args[index].asDouble();
            int last = args.Length - 1;
            Array array = new Array(size);
            if (index == last)
            {
                for (int i = 0; i < size; i++)
                {
                    array.set(i, Number.nil);
                }
            }
            else if (index < last)
            {
                for (int i = 0; i < size; i++)
                {
                    array.set(i, createArray(args, index + 1));
                }
            }
            return array;
        }
    }

    class Cos : IFunction
    {
        public Value execute(params Value[] args)
        {
            if (args.Length > 1) { throw new ArgumentException(); }
            else
                return new Number(Math.Sin(args[0].asDouble()));
        }
    }

    class DrawDot : IFunction
    {
        public Value execute(params Value[] args)
        {
            return null;
        }
    }

    class Functions : IFunction
    {
        static Number nil = new Number(0);
        private static Dictionary<String, IFunction> functions;

        static Functions()
        {
            functions = new Dictionary<string, IFunction>();

            functions.Add("sin", new Sin());
            functions.Add("cos", new Cos());
            functions.Add("MAKEARR", new NEWARRAY());
            functions.Add("drawdot", new DrawDot());
            //functions.Add("echo", new Func<Value[], Value>(Echo));
        }



        private static bool isExists(string key)
        {
            return functions.ContainsKey(key);
        }

        private static Value Echo(Value[] n)
        {
            foreach (Value val in n)
            {
                Console.WriteLine(val);
            }
            return nil;
        }

        private static Value Sin(Value[] n)
        {
            if (n.Length > 1) { throw new ArgumentException(); }
            else
                return new Number(Math.Sin(n[0].asDouble()));
        }

        private static Number Cos(Value[] n)
        {
            if (n.Length > 1) { throw new ArgumentException(); }
            else
                return new Number(Math.Cos(n[0].asDouble()));
        }



        public static IFunction get(string key)
        {
            if (!isExists(key))
            {
                throw new Exception("Function " + key + " not found");
            }
            else return functions[key];
        }

        public static void add(string key, IFunction function)
        {
            if (!functions.ContainsKey(key))
                functions.Add(key, function);
            else
                functions[key] = function;
        }

        public Value execute(params Value[] args)
        {
            throw new NotImplementedException();
        }
    }
}
