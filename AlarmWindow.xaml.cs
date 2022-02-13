using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlarmApp
{
    /// <summary>
    /// Interaction logic for AlarmWindow.xaml
    /// </summary>
    public partial class AlarmWindow : Window
    {
        public AlarmWindow()
        {
            InitializeComponent();

            var timeline = new MediaTimeline(new Uri(@$"{Directory.GetCurrentDirectory()}\ring.mp3"))
            {
                RepeatBehavior = System.Windows.Media.Animation.RepeatBehavior.Forever
            };

            var mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@$"{Directory.GetCurrentDirectory()}\ring.mp3"));
            mediaPlayer.Clock = timeline.CreateClock();
            mediaPlayer.Clock.Controller.Begin();
        }
    }
}
