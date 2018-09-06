using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            begin();
        }
        public void begin()
        {
            Canvas canvas = new Canvas();
            canvas.Width = 1024;
            canvas.Height = 768;
            canvasMain.Children.Add(canvas);
            UIkruskal main = new UIkruskal(canvas);
            main.initback();
            main.init();
            main.initline();
            main.treework();
            main.beginStoryBoard();
            
        }
    }
}
