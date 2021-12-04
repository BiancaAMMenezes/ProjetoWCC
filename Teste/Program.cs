using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace Teste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter a string having '&', '<', '>' or '\"' in it: ");
            string myEncodedString = Console.ReadLine();

            string teste = Regex.Replace(myEncodedString, "<[^>]*>", String.Empty);
            Console.WriteLine($"Decoded string of the above encoded string is: {teste}");

            // Encode the string.
            //string myEncodedString = HttpUtility.HtmlEncode(myString);

            //Console.WriteLine($"HTML Encoded string is: {myEncodedString}");
            StringWriter myWriter = new StringWriter();

            // Decode the encoded string.
            HttpUtility.HtmlDecode(myEncodedString, myWriter);

            string myDecodedString = myWriter.ToString();
            Console.WriteLine($"Decoded string of the above encoded string is: {myDecodedString}");

            
        }
    }
}
