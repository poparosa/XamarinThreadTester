using System;
using System.Threading;
using Xamarin.Forms;

namespace ThreadTest
{
    class MyPage : ContentPage
    {
        Label label = new Label()
        {
            Text = "init",
            HorizontalTextAlignment = TextAlignment.Center,
            FontSize = 30
        };
        private int _IntervalInMS = 500;

        public MyPage()
        {
            FireUpTimerTask();
            Content = new StackLayout()
            {
                Children = { label }
            };
        }

        public void FireUpTimerTask()
        {
            new Thread(doWork).Start();
        }

        private void doWork()
        {
            while (true)
            {
                UpdateResults();
                System.Threading.Thread.Sleep(_IntervalInMS);
            }
        }

        private void UpdateResults()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var mSeconds = DateTime.Now.Millisecond;
                var seconds = DateTime.Now.Second;
                label.Text = string.Format("time: {0}.{1} seconds", seconds, mSeconds);
            });
        }
    }
}
