using System.Windows;
using System.Windows.Input;

namespace WordleGame;

public partial class MainWindow
{
    private readonly Helper _helper;


    public MainWindow()
    {
        InitializeComponent();
        this.PreviewKeyDown += MainWindow_PreviewKeyDown;

        _helper = new Helper();

        KeyBoard.ItemsSource = _helper.GetKeyList();
        WordleGameGrid.ItemsSource = _helper.GetWordleList();
    }

    void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        _helper.KeyInputHandler(e.Key);
    }

    private void VirtualKeyBoard_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if ((sender as FrameworkElement)?.DataContext is KeyboardItem item) _helper.KeyInputHandler(item.Key);
    }

    private void WORDLE_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _helper.Reset();
        KeyBoard.ItemsSource = _helper.GetKeyList();
        WordleGameGrid.ItemsSource = _helper.GetWordleList();
    }
}