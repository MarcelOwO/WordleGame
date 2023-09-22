using System.IO;
using System.Reflection;

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
        
        String Filelocation = Path.Combine(Environment.CurrentDirectory,"words_alpha.txt");
        
        string[] intermediate = File.ReadAllLines(Filelocation);
        List<String> buffer = new();

        foreach (var word in intermediate)
        {
            if (word.Length == 5)
            {
                buffer.Add(word);
            }
        }

        PossibleWords = buffer.ToArray();

        
        Random rnd = new Random();
        
        Solution = PossibleWords[rnd.Next(PossibleWords.Length)];
        Console.WriteLine(Solution);
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