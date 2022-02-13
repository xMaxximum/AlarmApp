using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlarmApp
{
    public class Util
    {
        public static async Task RunInBackground(TimeSpan timeSpan, Action action)
        {
            PeriodicTimer? periodicTimer = new(timeSpan);
            while (await periodicTimer.WaitForNextTickAsync())
            {
                action();
            }
        }

        public static bool AreDigitsOnly(string text)
        {
            return text.All(c => c >= '0' && c <= '9' || c == ':');
        }

        public static string ConvertDateToRelative(DateTime time)
        {
            StringBuilder sb = new("");
            string suffix = "from now";

            TimeSpan timeSpan = new(Math.Abs(DateTime.Now.Subtract(time).Ticks));
            TimeSpan span = new(Math.Abs(TimeSpan.FromTicks(timeSpan.Ticks).Ticks));

            if (timeSpan.Days > 0)
            {
                sb.AppendFormat("{0} {1}", timeSpan.Days, (timeSpan.Days > 1) ? "days" : "day");
                if (timeSpan.Hours <= 0 && timeSpan.Minutes <= 0 && timeSpan.Seconds <= span.Seconds)
                {
                }
                else
                {
                    sb.Append(", ");
                }
            }

            if (timeSpan.Hours > 0)
            {
                sb.AppendFormat("{0} {1}", timeSpan.Hours, (timeSpan.Hours > 1) ? "hours" : "hour");
                if (timeSpan.Minutes > 0 || timeSpan.Seconds > 0)
                {
                    sb.Append(", ");
                }
            }

            if (timeSpan.Minutes > 0)
            {
                sb.AppendFormat("{0} {1}", timeSpan.Minutes, (timeSpan.Minutes > 1) ? "minutes" : "minute");
                if (timeSpan.Seconds > 0)
                {
                    sb.Append(", ");
                }
            }

            if (timeSpan.Seconds > 0)
            {
                sb.AppendFormat("{0} {1}", timeSpan.Seconds, (timeSpan.Seconds > 1) ? "seconds " : "second ");
            }

            sb.Append(suffix);
            return sb.ToString();
        }

        public static DateTime ConvertStringToTime(string time, Times timeType)
        {
            DateTime until = DateTime.Now;

            bool first = true;
            int number = 0;

            foreach (string s in time.Split(':'))
            {
                if (first)
                {
                    switch (timeType)
                    {
                        case Times.Seconds:
                            until = until.AddSeconds(int.Parse(s));
                            break;
                        case Times.Minutes:
                            until = until.AddMinutes(int.Parse(s));
                            break;
                        case Times.Hours:
                            until = until.AddHours(int.Parse(s));
                            break;
                        case Times.Days:
                            until = until.AddHours(int.Parse(s));
                            break;
                        default:
                            break;
                    }
                    first = false;
                    number++;
                }

                else
                {
                    switch (timeType - number)
                    {
                        case Times.Seconds:
                            until = until.AddSeconds(int.Parse(s));
                            break;
                        case Times.Minutes:
                            until = until.AddMinutes(int.Parse(s));
                            break;
                        case Times.Hours:
                            until = until.AddHours(int.Parse(s));
                            break;
                        case Times.Days:
                            until = until.AddHours(int.Parse(s));
                            break;
                        default:
                            break;
                    }
                    number++;
                }

            }
            return until;
        }
    }
}
