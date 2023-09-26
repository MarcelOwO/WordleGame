using System.ComponentModel;
using System.Windows.Media;

namespace WordleGame;

public class WordleItem : INotifyPropertyChanged
{
    private string _key;

    public string Key
    {
        get => _key;
        set
        {
            if (_key != value)
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }
    }

    public int Row { get;init; }
    public int Column { get; init; }
    
    private SolidColorBrush _color;

    public SolidColorBrush Color
    {
        get => _color;
        set
        {
            if (_color != value)
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public WordleItem()
    {
        _color = new SolidColorBrush(Colors.Black);
        _key = String.Empty;
    }
}