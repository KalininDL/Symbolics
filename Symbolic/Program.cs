using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Symbolic
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\ДАНИИЛ\\Desktop\\Символьные\\Symbolics\\Symbolic\\Program.txt";
            string exp = "";
            try
            {
                Console.WriteLine("******считываем весь файл********");
                using (StreamReader sr = new StreamReader(path))
                {
                    string result = sr.ReadToEnd();
                    exp = result;
                    sr.Close();
                }
               

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            List<Token> tokens = new SyntaxLayer(exp).toTokens();
            foreach (Token t in tokens)
            {
                Console.WriteLine(t);
            }


            Statement expressions = new Parser(tokens).parse();
            Console.WriteLine(expressions.ToString());
            expressions.execute();
            
            Console.Read();
        }
    }
}
