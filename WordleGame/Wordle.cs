using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Resources;
using Microsoft.VisualBasic;

namespace WordleGame;

public class Wordle
{
    private static String Solution { get; set; }
    private static String[] PossibleWords { get; set; }

    public string GetSolution()
    {
        return Solution;
    }

    public Wordle()
    {
        Uri uri = new Uri("/combined_wordlist.txt", UriKind.Relative);
        StreamResourceInfo info = Application.GetResourceStream(uri);
        Stream stream = info.Stream;
        StreamReader reader = new StreamReader(stream);
        
        List<string> buffer = new List<string>();

        while (!reader.EndOfStream)
        {
            string word = reader.ReadLine();

            word = word.Trim();

            if (word.Length == 5)
            {
                buffer.Add(word);
            }
        }
        reader.Close();
        stream.Close();

        PossibleWords = buffer.ToArray();

        Random rnd = new Random();

        Solution = PossibleWords[rnd.Next(PossibleWords.Length)];
    }


    public int CheckGuess(string guess)
    {
        //0 = invalid
        //1 = valid but not solution
        //2 = solution

        if (guess == Solution)
            return 2;

        foreach (var word in PossibleWords)
        {
            if (word == guess)
                return 1;
        }

        return 0;
    }
}