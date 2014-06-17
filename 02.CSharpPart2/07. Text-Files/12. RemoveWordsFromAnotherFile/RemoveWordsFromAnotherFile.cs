using System;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;

class RemoveWordsFromAnotherFile
{
    static void Main()
    {
        try
        {
            StreamReader input = new StreamReader("../../input.txt");
            StreamWriter output = new StreamWriter("../../output.txt");
            string regex = @"\b(" + String.Join("|", File.ReadAllLines("../../words.txt")) + @")\b";

            using (input)
            using (output)
            {
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    output.WriteLine(Regex.Replace(line, regex, String.Empty));
                }

                Console.WriteLine("Done!! check the output.txt file");
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (SecurityException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

