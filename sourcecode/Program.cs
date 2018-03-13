using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace sourcecode
{
    class Program
    {

       

        static void Main(string[] args)
        {
            string url;
            string sourcecode;
            int list = 0;
            int[] storlekborjan = new int[9];
            int[] storlekslutet = new int[9];
            string[] matMeny = new string[9];

            url = Console.ReadLine();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());

            sourcecode = Convert.ToString(sr.ReadToEnd());

            Console.WriteLine(sourcecode);

            Console.ReadKey();
          
            foreach (Match item in Regex.Matches(sourcecode, "<li>"))
            {
                Console.WriteLine(item.Index + " +"  + list);
                list++;
                if (list >= 10)
                {
                    goto endofloop1;
                }
            }

            endofloop1:

            list = 0;
            Console.WriteLine("slutar här");

            foreach (Match item in Regex.Matches(sourcecode, "</li>"))
            {
                Console.WriteLine(item.Index +  "+ " + list);
                list++;
                if (list >= 10)
                {
                    goto endofloop2;
                }
            }

            endofloop2:
            list = 0;

            for (int i = 0; i <= 8; i++)
            {
                int length;
                int begin = Convert.ToInt32(storlekborjan[i]);
                int borgan = Convert.ToInt32(storlekborjan[i]);
                int slutet = Convert.ToInt32(storlekslutet[i]);



                length = slutet - borgan;



                while (begin >= length)
                {

                    matMeny[i] += sourcecode[begin];
                    begin++;
                }

                
            }

            Console.WriteLine(matMeny[0]);

            Console.WriteLine(list);
            Console.ReadKey();

        }
    }
}
