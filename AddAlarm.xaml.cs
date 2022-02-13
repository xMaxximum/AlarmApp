using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AlarmApp
{
    /// <summary>
    /// Interaction logic for AddAlarm.xaml
    /// </summary>
    public partial class AddAlarm : Window
    {
        public Times timeType;
        private readonly MainWindowViewModel mainWindowViewModel;

        public AddAlarm(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            this.mainWindowViewModel = mainWindowViewModel;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void Seconds_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            timeType = Times.Seconds;
            TimeSplitButton.Content = timeType;
        }

        private void Minutes_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            timeType = Times.Minutes;
            TimeSplitButton.Content = timeType;
        }

        private void Hours_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            timeType = Times.Hours;
            TimeSplitButton.Content = timeType;
        }

        private void Days_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            timeType = Times.Days;
            TimeSplitButton.Content = timeType;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Set_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Enum.IsDefined(typeof(Times), TimeSplitButton.Content))
            {
                if (TimePicker_TextBox.Text.Any())
                {
                    if (NameTextBox.Text.Length > 15)
                    {
                        MessageBox.Show("The name of the Alarm can be 15 characters at most!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (Util.AreDigitsOnly(TimePicker_TextBox.Text))
                    {
                        DateTime time = Util.ConvertStringToTime(TimePicker_TextBox.Text, timeType);

                        var alarm = new AlarmModel()
                        {
                            Name = NameTextBox.Text,
                            Date = time
                        };

                        alarm.Update(time);

                        mainWindowViewModel.AddAlarm(alarm);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("You need to put in a valid time!\nValid Format Example: (Minutes) 10:20 => 10 minutes and 20 seconds.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You need to put in a time!\nValid Format Example: (Minutes) 10:20 => 10 minutes and 20 seconds.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("You need to put in a valid time format in the Time Format Picker Box!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
