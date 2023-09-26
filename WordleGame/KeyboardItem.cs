using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace WordleGame
{
    public class KeyboardItem : INotifyPropertyChanged
    {
        public string KeyName { get; init; }
        public System.Windows.Input.Key Key { get; init; }
        public int Row { get; set; }
        public int Column { get; set; }
        public double Width { get; set; }
        public Thickness Margin { get; set; }

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

        public KeyboardItem()
        {
            Margin = new Thickness(2);
            Width = 35;
            _color = new SolidColorBrush(Colors.Gray);
            KeyName = String.Empty;
            
        }
    }
}