using System.ComponentModel;
using System.Printing;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordleGame;

public partial class MainWindow : Window
{
    private String[,] WordleGrid { get; set; }
    private (int, int) CurrentPos { get; set; }
    private List<Key> AllowedKeys { get; set; }
    private String Solution { get; set; }
    private Wordle wordle { get; set; }
    
    private List<KeyboardItem> keyListRow0 { get; set; }
    private List<KeyboardItem> keyListRow1 { get; set; }
    private List<KeyboardItem> keyListRow2 { get; set; }


    public MainWindow()
    {
        InitializeComponent();
        this.PreviewKeyDown += MainWindow_PreviewKeyDown;

        wordle = new();

        Solution = wordle.GetSolution();

        WordleGrid = new String[6, 5];

        CurrentPos = (0, 0);

        AllowedKeys = new();
        
        AllowedKeys.Add(Key.A);
        AllowedKeys.Add(Key.B);
        AllowedKeys.Add(Key.C);
        AllowedKeys.Add(Key.D);
        AllowedKeys.Add(Key.E);
        AllowedKeys.Add(Key.F);
        AllowedKeys.Add(Key.G);
        AllowedKeys.Add(Key.H);
        AllowedKeys.Add(Key.I);
        AllowedKeys.Add(Key.J);
        AllowedKeys.Add(Key.K);
        AllowedKeys.Add(Key.L);
        AllowedKeys.Add(Key.M);
        AllowedKeys.Add(Key.N);
        AllowedKeys.Add(Key.O);
        AllowedKeys.Add(Key.P);
        AllowedKeys.Add(Key.Q);
        AllowedKeys.Add(Key.R);
        AllowedKeys.Add(Key.S);
        AllowedKeys.Add(Key.T);
        AllowedKeys.Add(Key.U);
        AllowedKeys.Add(Key.V);
        AllowedKeys.Add(Key.W);
        AllowedKeys.Add(Key.X);
        AllowedKeys.Add(Key.Y);
        AllowedKeys.Add(Key.Z);
        
        keyListRow0 = new List<KeyboardItem>();
        keyListRow1 = new List<KeyboardItem>();
        keyListRow2 = new List<KeyboardItem>();
        
        keyListRow0.Add(new KeyboardItem() {KeyName = "E", Key = Key.E, Row = 0, Column = 2});
        keyListRow0.Add(new KeyboardItem() {KeyName = "I", Key = Key.I, Row = 0, Column = 7});
        keyListRow0.Add(new KeyboardItem() {KeyName = "O", Key = Key.O, Row = 0, Column = 8});
        keyListRow0.Add(new KeyboardItem() {KeyName = "P", Key = Key.P, Row = 0, Column = 9});
        keyListRow0.Add(new KeyboardItem() {KeyName = "Q", Key = Key.Q, Row = 0, Column = 0});
        keyListRow0.Add(new KeyboardItem() {KeyName = "R", Key = Key.R, Row = 0, Column = 3});
        keyListRow0.Add(new KeyboardItem() {KeyName = "T", Key = Key.T, Row = 0, Column = 4});
        keyListRow0.Add(new KeyboardItem() {KeyName = "U", Key = Key.U, Row = 0, Column = 6});
        keyListRow0.Add(new KeyboardItem() {KeyName = "W", Key = Key.W, Row = 0, Column = 1});
        keyListRow0.Add(new KeyboardItem() {KeyName = "Y", Key = Key.Y, Row = 0, Column = 5});

        keyListRow1.Add(new KeyboardItem()
            {KeyName = "A", Key = Key.A, Row = 1, Column = 0, Margin = new Thickness(15, 2, -10, 2)});
        keyListRow1.Add(new KeyboardItem()
            {KeyName = "D", Key = Key.D, Row = 1, Column = 2, Margin = new Thickness(15, 2, -10, 2)});
        keyListRow1.Add(new KeyboardItem()
            {KeyName = "F", Key = Key.F, Row = 1, Column = 3, Margin = new Thickness(15, 2, -10, 2)});
        keyListRow1.Add(new KeyboardItem()
            {KeyName = "G", Key = Key.G, Row = 1, Column = 4, Margin = new Thickness(15, 2, -10, 2)});
        keyListRow1.Add(new KeyboardItem()
            {KeyName = "H", Key = Key.H, Row = 1, Column = 5, Margin = new Thickness(15, 2, -10, 2)});
        keyListRow1.Add(new KeyboardItem()
            {KeyName = "J", Key = Key.J, Row = 1, Column = 6, Margin = new Thickness(15, 2, -10, 2)});
        keyListRow1.Add(new KeyboardItem()
            {KeyName = "K", Key = Key.K, Row = 1, Column = 7, Margin = new Thickness(15, 2, -10, 2)});
        keyListRow1.Add(new KeyboardItem()
            {KeyName = "L", Key = Key.L, Row = 1, Column = 8, Margin = new Thickness(15, 2, -10, 2)});
        keyListRow1.Add(new KeyboardItem()
            {KeyName = "S", Key = Key.S, Row = 1, Column = 1, Margin = new Thickness(15, 2, -10, 2)});

        keyListRow2.Add(new KeyboardItem() {KeyName = "B", Key = Key.B, Row = 2, Column = 5});
        keyListRow2.Add(new KeyboardItem() {KeyName = "C", Key = Key.C, Row = 2, Column = 3});
        keyListRow2.Add(new KeyboardItem() {KeyName = "V", Key = Key.V, Row = 2, Column = 4});
        keyListRow2.Add(new KeyboardItem() {KeyName = "X", Key = Key.X, Row = 2, Column = 2});
        keyListRow2.Add(new KeyboardItem() {KeyName = "M", Key = Key.M, Row = 2, Column = 7});
        keyListRow2.Add(new KeyboardItem() {KeyName = "N", Key = Key.N, Row = 2, Column = 6});
        keyListRow2.Add(new KeyboardItem() {KeyName = "Z", Key = Key.Z, Row = 2, Column = 1});
        keyListRow2.Add(new KeyboardItem() {KeyName = "Enter", Key = Key.Enter, Row = 2, Column = 0, Width = 55});
        keyListRow2.Add(new KeyboardItem() {KeyName = "Del", Key = Key.Back, Row = 2, Column = 8, Width = 55});


        KeyBoard0.ItemsSource = keyListRow0;
        KeyBoard1.ItemsSource = keyListRow1;
        KeyBoard2.ItemsSource = keyListRow2;
    }

    void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && CurrentPos.Item2 == 5)
        {
            StringBuilder sb = new();

            for (int i = 0; i < 5; i++)
            {
                sb.Append(WordleGrid[CurrentPos.Item1, i]);
            }

            CurrentPos = SubmitButton_Click(sb.ToString()) ? (CurrentPos.Item1 + 1, 0) : (CurrentPos.Item1, 0);
        }

        if (e.Key == Key.Delete || e.Key == Key.Back)
        {
            if (CurrentPos.Item2 == 0)
                return;

            CurrentPos = (CurrentPos.Item1, CurrentPos.Item2 - 1);
            SetTextonRectangle(String.Empty, CurrentPos);
        }

        if (AllowedKeys.Contains(e.Key) && CurrentPos.Item2 < 5)
        {
            String key = e.Key.ToString().ToLower();

            WordleGrid[CurrentPos.Item1, CurrentPos.Item2] = key;

            SetTextonRectangle(key, CurrentPos);

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
                SetColorsBox((CurrentPos.Item1, i), Brushes.Green);
                continue;
            }

            if (uniqeCharacterandcount[guessArray[i]] == 0)
                continue;

            SetColorsKey(guessArray[i], Brushes.DarkGoldenrod);
            SetColorsBox((CurrentPos.Item1, i), Brushes.DarkGoldenrod);

            uniqeCharacterandcount[guessArray[i]] = uniqeCharacterandcount[guessArray[i]] - 1;
        }
    }

    void SetColorsKey(char character, SolidColorBrush color)
    {
        
        foreach (KeyboardItem keyboardItem in keyListRow0)
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
                KeyBoard0.ItemsSource = new List<KeyboardItem>();
                KeyBoard0.ItemsSource = keyListRow0;
                return;
            }
            
        }
        foreach (KeyboardItem keyboardItem in keyListRow1)
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
                KeyBoard1.ItemsSource = new List<KeyboardItem>();
                KeyBoard1.ItemsSource = keyListRow1;
                return;
            }
            
        }
        foreach (KeyboardItem keyboardItem in keyListRow2)
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
                KeyBoard2.ItemsSource = new List<KeyboardItem>();
                KeyBoard2.ItemsSource = keyListRow2;
                return;
            }
        }

        return;
    }

    void SetColorsBox((int, int) pos, Brush color)
    {
        switch (pos)
        {
            case (0, 0):
                Box00.Background = color;
                break;
            case (0, 1):
                Box01.Background = color;
                break;
            case (0, 2):
                Box02.Background = color;
                break;
            case (0, 3):
                Box03.Background = color;
                break;
            case (0, 4):
                Box04.Background = color;
                break;

            case (1, 0):
                Box10.Background = color;
                break;
            case (1, 1):
                Box11.Background = color;
                break;
            case (1, 2):
                Box12.Background = color;
                break;
            case (1, 3):
                Box13.Background = color;
                break;
            case (1, 4):
                Box14.Background = color;
                break;

            case (2, 0):
                Box20.Background = color;
                break;
            case (2, 1):
                Box21.Background = color;
                break;
            case (2, 2):
                Box22.Background = color;
                break;
            case (2, 3):
                Box23.Background = color;
                break;
            case (2, 4):
                Box24.Background = color;
                break;

            case (3, 0):
                Box30.Background = color;
                break;
            case (3, 1):
                Box31.Background = color;
                break;
            case (3, 2):
                Box32.Background = color;
                break;
            case (3, 3):
                Box33.Background = color;
                break;
            case (3, 4):
                Box34.Background = color;
                break;

            case (4, 0):
                Box40.Background = color;
                break;
            case (4, 1):
                Box41.Background = color;
                break;
            case (4, 2):
                Box42.Background = color;
                break;
            case (4, 3):
                Box43.Background = color;
                break;
            case (4, 4):
                Box44.Background = color;
                break;

            case (5, 0):
                Box50.Background = color;
                break;
            case (5, 1):
                Box51.Background = color;
                break;
            case (5, 2):
                Box52.Background = color;
                break;
            case (5, 3):
                Box53.Background = color;
                break;
            case (5, 4):
                Box54.Background = color;
                break;
        }
    }


    void SetTextonRectangle(string key, (int, int) pos)
    {
        switch (pos)
        {
            case (0, 0):
                Rectangle00.Text = key;
                break;
            case (0, 1):
                Rectangle01.Text = key;
                break;
            case (0, 2):
                Rectangle02.Text = key;
                break;
            case (0, 3):
                Rectangle03.Text = key;
                break;
            case (0, 4):
                Rectangle04.Text = key;
                break;

            case (1, 0):
                Rectangle10.Text = key;
                break;
            case (1, 1):
                Rectangle11.Text = key;
                break;
            case (1, 2):
                Rectangle12.Text = key;
                break;
            case (1, 3):
                Rectangle13.Text = key;
                break;
            case (1, 4):
                Rectangle14.Text = key;
                break;

            case (2, 0):
                Rectangle20.Text = key;
                break;
            case (2, 1):
                Rectangle21.Text = key;
                break;
            case (2, 2):
                Rectangle22.Text = key;
                break;
            case (2, 3):
                Rectangle23.Text = key;
                break;
            case (2, 4):
                Rectangle24.Text = key;
                break;

            case (3, 0):
                Rectangle30.Text = key;
                break;
            case (3, 1):
                Rectangle31.Text = key;
                break;
            case (3, 2):
                Rectangle32.Text = key;
                break;
            case (3, 3):
                Rectangle33.Text = key;
                break;
            case (3, 4):
                Rectangle34.Text = key;
                break;

            case (4, 0):
                Rectangle40.Text = key;
                break;
            case (4, 1):
                Rectangle41.Text = key;
                break;
            case (4, 2):
                Rectangle42.Text = key;
                break;
            case (4, 3):
                Rectangle43.Text = key;
                break;
            case (4, 4):
                Rectangle44.Text = key;
                break;

            case (5, 0):
                Rectangle50.Text = key;
                break;
            case (5, 1):
                Rectangle51.Text = key;
                break;
            case (5, 2):
                Rectangle52.Text = key;
                break;
            case (5, 3):
                Rectangle53.Text = key;
                break;
            case (5, 4):
                Rectangle54.Text = key;
                break;
        }
    }


    bool SubmitButton_Click(string guess)
    {
        switch (wordle.CheckGuess(guess))
        {
            case 0: //invalid
                MessageBox.Show("Not a word");
                deleteLine();
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

    private void deleteLine()
    {
        for (int i = 0; i < 5; i++)
        {
            WordleGrid[CurrentPos.Item1, i] = String.Empty;
            SetTextonRectangle(String.Empty, (CurrentPos.Item1, i));
        }
    }
}