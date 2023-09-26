using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WordleGame;

public class Helper
{
    private (int, int) CurrentPos { get; set; }
    private List<Key> AllowedKeys { get; set; }
    private String Solution { get; set; }
    private Wordle Wordle { get; set; }
    private List<KeyboardItem> KeyList { get; set; }
    private List<WordleItem> WordleList { get; set; }


    public Helper()
    {
         Wordle = new();
        Solution = Wordle.GetSolution();
        CurrentPos = (0, 0);
        AllowedKeys = new()
        {
            Key.A,
            Key.B,
            Key.C,
            Key.D,
            Key.E,
            Key.F,
            Key.G,
            Key.H,
            Key.I,
            Key.J,
            Key.K,
            Key.L,
            Key.M,
            Key.N,
            Key.O,
            Key.P,
            Key.Q,
            Key.R,
            Key.S,
            Key.T,
            Key.U,
            Key.V,
            Key.W,
            Key.X,
            Key.Y,
            Key.Z,
        };
        WordleList = new List<WordleItem>()
        {
            new WordleItem( ) {Key = "", Row = 1, Column = 1},
            new WordleItem( ) {Key = "", Row = 1, Column = 2},
            new WordleItem( ) {Key = "", Row = 1, Column = 3},
            new WordleItem( ) {Key = "", Row = 1, Column = 4},
            new WordleItem( ) {Key = "", Row = 1, Column = 5},
            new WordleItem( ) {Key = "", Row = 2, Column = 1},
            new WordleItem( ) {Key = "", Row = 2, Column = 2},
            new WordleItem( ) {Key = "", Row = 2, Column = 3},
            new WordleItem( ) {Key = "", Row = 2, Column = 4},
            new WordleItem( ) {Key = "", Row = 2, Column = 5},
            new WordleItem( ) {Key = "", Row = 3, Column = 1},
            new WordleItem( ) {Key = "", Row = 3, Column = 2},
            new WordleItem( ) {Key = "", Row = 3, Column = 3},
            new WordleItem( ) {Key = "", Row = 3, Column = 4},
            new WordleItem( ) {Key = "", Row = 3, Column = 5},
            new WordleItem( ) {Key = "", Row = 4, Column = 1},
            new WordleItem( ) {Key = "", Row = 4, Column = 2},
            new WordleItem( ) {Key = "", Row = 4, Column = 3},
            new WordleItem( ) {Key = "", Row = 4, Column = 4},
            new WordleItem( ) {Key = "", Row = 4, Column = 5},
            new WordleItem( ) {Key = "", Row = 5, Column = 1},
            new WordleItem( ) {Key = "", Row = 5, Column = 2},
            new WordleItem( ) {Key = "", Row = 5, Column = 3},
            new WordleItem( ) {Key = "", Row = 5, Column = 4},
            new WordleItem( ) {Key = "", Row = 5, Column = 5},
            new WordleItem( ) {Key = "", Row = 6, Column = 1},
            new WordleItem( ) {Key = "", Row = 6, Column = 2},
            new WordleItem( ) {Key = "", Row = 6, Column = 3},
            new WordleItem( ) {Key = "", Row = 6, Column = 4},
            new WordleItem( ) {Key = "", Row = 6, Column = 5},

        };

        
        KeyList = new List<KeyboardItem>()
        {
            new KeyboardItem() {KeyName = "Q", Key = Key.Q, Row = 0, Column = 0, Margin = new Thickness(-12, 2, 10, 2)},
            new KeyboardItem() {KeyName = "W", Key = Key.W, Row = 0, Column = 1, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "E", Key = Key.E, Row = 0, Column = 2, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "R", Key = Key.R, Row = 0, Column = 3, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "T", Key = Key.T, Row = 0, Column = 4, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "Y", Key = Key.Y, Row = 0, Column = 5, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "U", Key = Key.U, Row = 0, Column = 6, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "I", Key = Key.I, Row = 0, Column = 7, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "O", Key = Key.O, Row = 0, Column = 8, Margin = new Thickness(-31, 2, 27, 2)},
            new KeyboardItem() {KeyName = "P", Key = Key.P, Row = 0, Column = 9, Margin = new Thickness(-35, 2, 27, 2)},

            new KeyboardItem() {KeyName = "A", Key = Key.A, Row = 1, Column = 0, Margin = new Thickness(15, 2, -10, 2)},
            new KeyboardItem() {KeyName = "D", Key = Key.D, Row = 1, Column = 2, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "F", Key = Key.F, Row = 1, Column = 3, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "G", Key = Key.G, Row = 1, Column = 4, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "H", Key = Key.H, Row = 1, Column = 5, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "J", Key = Key.J, Row = 1, Column = 6, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "K", Key = Key.K, Row = 1, Column = 7, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "L", Key = Key.L, Row = 1, Column = 8, Margin = new Thickness(-4, 2, 6, 2)},
            new KeyboardItem() {KeyName = "S", Key = Key.S, Row = 1, Column = 1, Margin = new Thickness(4, 2, 2, 2)},

            new KeyboardItem() {KeyName = "B", Key = Key.B, Row = 2, Column = 5},
            new KeyboardItem() {KeyName = "C", Key = Key.C, Row = 2, Column = 3},
            new KeyboardItem() {KeyName = "V", Key = Key.V, Row = 2, Column = 4},
            new KeyboardItem() {KeyName = "X", Key = Key.X, Row = 2, Column = 2},
            new KeyboardItem() {KeyName = "M", Key = Key.M, Row = 2, Column = 7},
            new KeyboardItem() {KeyName = "N", Key = Key.N, Row = 2, Column = 6},
            new KeyboardItem() {KeyName = "Z", Key = Key.Z, Row = 2, Column = 1},
            new KeyboardItem() {KeyName = "Enter", Key = Key.Enter, Row = 2, Column = 0, Width = 55},
            new KeyboardItem() {KeyName = "Del", Key = Key.Back, Row = 2, Column = 8, Width = 55},
        };

    }
    
    public List<WordleItem> GetWordleList()
    {
        return WordleList;
    }
    
    public List<KeyboardItem> GetKeyList()
    {
        return KeyList;
    }

    internal void KeyInputHandler(Key e)
    {
        if (e == Key.Enter && CurrentPos.Item2 == 5)
        {
            StringBuilder sb = new();

            for (int i = 0; i < 5; i++)
            {
                sb.Append(WordleList[CurrentPos.Item1 * 5 + i].Key);
            }

            CurrentPos = SubmitButton_Click(sb.ToString()) ? (CurrentPos.Item1 + 1, 0) : (CurrentPos.Item1, 0);
        }

        if (e == Key.Delete || e == Key.Back)
        {
            if (CurrentPos.Item2 == 0)
                return;

            CurrentPos = (CurrentPos.Item1, CurrentPos.Item2 - 1);
            
            WordleList[CurrentPos.Item1*5+ CurrentPos.Item2].Key = String.Empty;
        }

        if (AllowedKeys.Contains(e) && CurrentPos.Item2 < 5)
        {
            String key = e.ToString().ToLower();
            
            WordleList[CurrentPos.Item1*5+ CurrentPos.Item2].Key = key;

            CurrentPos = (CurrentPos.Item1, CurrentPos.Item2 + 1);
        }
    }
    
    void SetColor(string guess)
    {
        char[] solutionArray = Solution.ToArray();

        char[] guessArray = guess.ToArray();

        var uniqeCharacterandcount = new Dictionary<char, int>();

        foreach (var c in guess)
        {
            if (uniqeCharacterandcount.ContainsKey(c))
            {
                uniqeCharacterandcount[c] = uniqeCharacterandcount[c]++;
            }
            else
            {
                uniqeCharacterandcount.Add(c, 1);
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (!solutionArray.Contains(guessArray[i]))
            {
                
                SetColorsKey(guessArray[i],new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333")));
                continue;
            }

            if (solutionArray[i] == guessArray[i])
            {
                SetColorsKey(guessArray[i], Brushes.Green);
                WordleList[CurrentPos.Item1*5+ i].Color = Brushes.Green;
                continue;
            }

            if (uniqeCharacterandcount[guessArray[i]] == 0)
                continue;

            SetColorsKey(guessArray[i], Brushes.DarkGoldenrod);
            WordleList[CurrentPos.Item1*5+ i].Color = Brushes.DarkGoldenrod;
            uniqeCharacterandcount[guessArray[i]] = uniqeCharacterandcount[guessArray[i]] - 1;
        }
    }
    void SetColorsKey(char character, SolidColorBrush color)
    {
        foreach (KeyboardItem keyboardItem in KeyList)
        {
            if (keyboardItem.KeyName == character.ToString().ToUpper())
            {
                if (Equals(color, Brushes.DarkGoldenrod)&&Equals(keyboardItem.Color, Brushes.Green))
                    return;
                
                if (Equals(color, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333")))&&Equals(keyboardItem.Color, Brushes.Green))
                    return;
                
                if (Equals(color, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333")))&&Equals(keyboardItem.Color, Brushes.DarkGoldenrod))
                    return;
                
                keyboardItem.Color = color;
                return;
            }
            
        }
    }

    bool SubmitButton_Click(string guess)
    {
        switch (Wordle.CheckGuess(guess))
        {
            case 0: //invalid
                MessageBox.Show("Not a word");
                DeleteLine();
                return false;

            case 1: //valid but not solution
                MessageBox.Show("Not the solution");
                SetColor(guess);
                return true;

            case 2: //solution
                MessageBox.Show("Correct! You win!");
                SetColor(guess);
                return true;

            default:
                return true;
        }
    }

    private void DeleteLine()
    {
        for (int i = 0; i < 5; i++)
        {
            WordleList[CurrentPos.Item1*5+ i].Key = String.Empty;
        }
    }
    public void Reset()
    {
        Wordle = new();

        Solution = Wordle.GetSolution();

        CurrentPos = (0, 0);
        
        WordleList = new List<WordleItem>()
        {
            new WordleItem( ) {Key = "", Row = 1, Column = 1},
            new WordleItem( ) {Key = "", Row = 1, Column = 2},
            new WordleItem( ) {Key = "", Row = 1, Column = 3},
            new WordleItem( ) {Key = "", Row = 1, Column = 4},
            new WordleItem( ) {Key = "", Row = 1, Column = 5},
            new WordleItem( ) {Key = "", Row = 2, Column = 1},
            new WordleItem( ) {Key = "", Row = 2, Column = 2},
            new WordleItem( ) {Key = "", Row = 2, Column = 3},
            new WordleItem( ) {Key = "", Row = 2, Column = 4},
            new WordleItem( ) {Key = "", Row = 2, Column = 5},
            new WordleItem( ) {Key = "", Row = 3, Column = 1},
            new WordleItem( ) {Key = "", Row = 3, Column = 2},
            new WordleItem( ) {Key = "", Row = 3, Column = 3},
            new WordleItem( ) {Key = "", Row = 3, Column = 4},
            new WordleItem( ) {Key = "", Row = 3, Column = 5},
            new WordleItem( ) {Key = "", Row = 4, Column = 1},
            new WordleItem( ) {Key = "", Row = 4, Column = 2},
            new WordleItem( ) {Key = "", Row = 4, Column = 3},
            new WordleItem( ) {Key = "", Row = 4, Column = 4},
            new WordleItem( ) {Key = "", Row = 4, Column = 5},
            new WordleItem( ) {Key = "", Row = 5, Column = 1},
            new WordleItem( ) {Key = "", Row = 5, Column = 2},
            new WordleItem( ) {Key = "", Row = 5, Column = 3},
            new WordleItem( ) {Key = "", Row = 5, Column = 4},
            new WordleItem( ) {Key = "", Row = 5, Column = 5},
            new WordleItem( ) {Key = "", Row = 6, Column = 1},
            new WordleItem( ) {Key = "", Row = 6, Column = 2},
            new WordleItem( ) {Key = "", Row = 6, Column = 3},
            new WordleItem( ) {Key = "", Row = 6, Column = 4},
            new WordleItem( ) {Key = "", Row = 6, Column = 5},

        };
        
        KeyList = new List<KeyboardItem>()
        {
            new KeyboardItem() {KeyName = "Q", Key = Key.Q, Row = 0, Column = 0, Margin = new Thickness(-12, 2, 10, 2)},
            new KeyboardItem() {KeyName = "W", Key = Key.W, Row = 0, Column = 1, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "E", Key = Key.E, Row = 0, Column = 2, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "R", Key = Key.R, Row = 0, Column = 3, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "T", Key = Key.T, Row = 0, Column = 4, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "Y", Key = Key.Y, Row = 0, Column = 5, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "U", Key = Key.U, Row = 0, Column = 6, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "I", Key = Key.I, Row = 0, Column = 7, Margin = new Thickness(-20, 2, 19, 2)},
            new KeyboardItem() {KeyName = "O", Key = Key.O, Row = 0, Column = 8, Margin = new Thickness(-31, 2, 27, 2)},
            new KeyboardItem() {KeyName = "P", Key = Key.P, Row = 0, Column = 9, Margin = new Thickness(-35, 2, 27, 2)},

            new KeyboardItem() {KeyName = "A", Key = Key.A, Row = 1, Column = 0, Margin = new Thickness(15, 2, -10, 2)},
            new KeyboardItem() {KeyName = "D", Key = Key.D, Row = 1, Column = 2, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "F", Key = Key.F, Row = 1, Column = 3, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "G", Key = Key.G, Row = 1, Column = 4, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "H", Key = Key.H, Row = 1, Column = 5, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "J", Key = Key.J, Row = 1, Column = 6, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "K", Key = Key.K, Row = 1, Column = 7, Margin = new Thickness(4, 2, 2, 2)},
            new KeyboardItem() {KeyName = "L", Key = Key.L, Row = 1, Column = 8, Margin = new Thickness(-4, 2, 6, 2)},
            new KeyboardItem() {KeyName = "S", Key = Key.S, Row = 1, Column = 1, Margin = new Thickness(4, 2, 2, 2)},

            new KeyboardItem() {KeyName = "B", Key = Key.B, Row = 2, Column = 5},
            new KeyboardItem() {KeyName = "C", Key = Key.C, Row = 2, Column = 3},
            new KeyboardItem() {KeyName = "V", Key = Key.V, Row = 2, Column = 4},
            new KeyboardItem() {KeyName = "X", Key = Key.X, Row = 2, Column = 2},
            new KeyboardItem() {KeyName = "M", Key = Key.M, Row = 2, Column = 7},
            new KeyboardItem() {KeyName = "N", Key = Key.N, Row = 2, Column = 6},
            new KeyboardItem() {KeyName = "Z", Key = Key.Z, Row = 2, Column = 1},
            new KeyboardItem() {KeyName = "Enter", Key = Key.Enter, Row = 2, Column = 0, Width = 55},
            new KeyboardItem() {KeyName = "Del", Key = Key.Back, Row = 2, Column = 8, Width = 55},
        };

    }
}