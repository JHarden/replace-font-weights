using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;


namespace ReplaceFontWeights
{
    class Program
    {
        public static void Main(string[] args)
        {

            initReplace();         

        }

        //takes user input for base directory
        public static void initReplace()
        {           
           
            Console.WriteLine("::: enter the root scss directory location :::");
            string loc = Console.ReadLine();
                       
            Console.WriteLine("checking ::: " + loc);

            DirSearch(loc);   
            
        }


        //recursive directory search from selected directory
        private static void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        
                        if (f.Contains(".scss") && !f.Contains("typography")) { 

                            doReplace(f);

                        }

                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        //do the replace operation on the selected file
        private static void doReplace(string path)
        {
            try
            {
                string text = File.ReadAllText(path);
                Console.WriteLine("replacing in ::: " + path);
               
                text = Regex.Replace(text, @"(font-weight)\s*:\s*(light)+", "font-family:'HelveticaNeueW01-45Ligh', sans-serif");
                text = Regex.Replace(text, @"(font-weight)\s*:\s*[100]+", "font-family:'HelveticaNeueW01-45Ligh', sans-serif");
                text = Regex.Replace(text, @"(font-weight)\s*:\s*[200]+", "font-family:'HelveticaNeueW01-45Ligh', sans-serif");
                text = Regex.Replace(text, @"(font-weight)\s*:\s*[300]+", "font-family:'HelveticaNeueW01-45Ligh', sans-serif");
                text = Regex.Replace(text, @"(font-weight)\s*:\s*[400]+", "font-family:'HelveticaNeue-Medium', sans-serif");
                text = Regex.Replace(text, @"(font-weight)\s*:\s*[500]+", "font-family:'HelveticaNeue-Medium', sans-serif");
                text = Regex.Replace(text, @"(font-weight)\s*:\s*(normal)+", "font-family:'HelveticaNeue-Medium', sans-serif");
                text = Regex.Replace(text, @"(font-weight)\s*:\s*.(font-weight-normal)+", "font-family:'HelveticaNeue-Medium', sans-serif");   
                text = Regex.Replace(text, @"(font-weight)\s*:\s*(bold)+", "font-family:'HelveticaNeueW01-75Bold', sans-serif");
                text = Regex.Replace(text, @"(font-weight)\s*:\s*(bolder)+", "font-family:'HelveticaNeueW01-75Bold', sans-serif");
                text = Regex.Replace(text, @"(font-weight)\s*:\s*[600]+", "font-family:'HelveticaNeueW01-75Bold', sans-serif");
                text = Regex.Replace(text, @"(font-weight)\s*:\s*[700]+", "font-family:'HelveticaNeueW01-75Bold', sans-serif");
                text = Regex.Replace(text, @"(font-weight)\s*:\s*.(font-weight-bold)+", "font-family:'HelveticaNeueW01-75Bold', sans-serif");
                File.WriteAllText(path, text);

            }

            catch (FileNotFoundException f)
            {

                Console.WriteLine("File not found! D'oh! ");
                Console.WriteLine(f);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            } 
             

        }




    }

}
