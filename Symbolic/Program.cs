using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Symbolic
{
    public partial class Program : Form
    {
        public Program()
        {
            InitializeComponent();
        }
        
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());

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
            expressions.accept(new FunctionAdder());
            expressions.accept(new AssignValidator());
            expressions.execute();

            Console.Read();
        }

        private void execute()
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
            expressions.accept(new FunctionAdder());
            expressions.accept(new AssignValidator());
            expressions.execute();

            Console.Read();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(500, 376);
            this.Name = "Program";
            this.Load += new System.EventHandler(this.Program_Load);
            this.ResumeLayout(false);
            this.execute();

        }

        private void Program_Load(object sender, EventArgs e)
        {

        }
    }
}
