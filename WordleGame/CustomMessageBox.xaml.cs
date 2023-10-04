using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace WordleGame;

public partial class CustomMessageBox : Window
{
    private bool _stupidChecktomakesurethewindowisopenbeforeitisclosedagain = false;
    public CustomMessageBox()
    {
        InitializeComponent();
        KeyDown += KeyBoardButtonPressEventthatforsomereasonisactivatedwaytoearlyandfuckseverythingup;
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        Hide();
        _stupidChecktomakesurethewindowisopenbeforeitisclosedagain = false;
    }
    
    public void Show(string text)
    {
        TextBlock.Text = text;
        Topmost = true;
        Show();
        
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(100);
        timer.Tick += (sender, e) =>
        {
           timer.Stop();
           _stupidChecktomakesurethewindowisopenbeforeitisclosedagain = true;
        };
        timer.Start();
    }

    private void KeyBoardButtonPressEventthatforsomereasonisactivatedwaytoearlyandfuckseverythingup(object sender, KeyEventArgs e)
    {
        if (_stupidChecktomakesurethewindowisopenbeforeitisclosedagain)
        {
            Hide();
            _stupidChecktomakesurethewindowisopenbeforeitisclosedagain = false;
            
        }
        
    }



}