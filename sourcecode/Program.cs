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
            string url = "http://www.jojcatering.se/";
            string sourcecode;
            int list = 0;
            int[] storlekborjan = new int[10];
            int[] storlekslutet = new int[10];
            byte[] matMenyByte;
            string[] matMeny = new string[10];


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());

            sourcecode = Convert.ToString(sr.ReadToEnd());

        //    Console.WriteLine(sourcecode);

        //    Console.ReadKey();
          
            foreach (Match item in Regex.Matches(sourcecode, "<li>"))
            {
                //Console.WriteLine(item.Index + " +"  + list);

                if (list >= 10)
                {
                    goto endofloop1;
                }

                storlekborjan[list] = item.Index + 4;
                list++;
                
                
            }

            endofloop1:

            list = 0;
           // Console.WriteLine("slutar här");

            foreach (Match item in Regex.Matches(sourcecode, "</li>"))
            {
             //   Console.WriteLine(item.Index +  "+ " + list);
                if (list >= 10)
                {
                    goto endofloop2;
                }
                storlekslutet[list] = item.Index;
                list++;

            }

            endofloop2:
            list = 0;

            for (int i = 0; i <= 9; i++)
            {
                matMeny[i] = sourcecode.Substring(storlekborjan[i], (storlekslutet[i] - storlekborjan[i]));
            }



            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine(matMeny[i]);
            }
           

           
            Console.ReadKey();

        }
    }
}
