using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Media;

namespace WordleGame;

public class KeyboardItem
{
    public string KeyName { get; set; }
    public System.Windows.Input.Key Key { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }

    public int Width { get; set; } = 35;
    public Thickness Margin { get; set; } = new Thickness(2, 2, 2, 2);

    public SolidColorBrush Color
    {
        get;
        
        set;
        
    } = new SolidColorBrush(Colors.Gray);
    
   
    
}