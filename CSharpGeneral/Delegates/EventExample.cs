using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpGeneral.Delegates
{
    public class EventExample
    {
        public void Play()
        {
            Publisher pub = new Publisher();
            Subscriber sub1 = new Subscriber(1, pub);
            Subscriber sub2 = new Subscriber(2, pub);

            pub.SomethingThatWillEndupRaisingEvent();
        }
    }

    public class WeatherEventArgs : EventArgs
    {
        public DateTime Date { get; }
        public int Temeperature { get; }

        public WeatherEventArgs(DateTime date, int temperature)
        {
            Date = date;
            Temeperature = temperature;
        }
    }

    public class Publisher
    {
        public event EventHandler<WeatherEventArgs> WeatherForecastEvent;

        public void SomethingThatWillEndupRaisingEvent()
        {
            OnRaiseWeatherForecastEvent(new WeatherEventArgs(DateTime.Now, 21));
        }

        protected virtual void OnRaiseWeatherForecastEvent(WeatherEventArgs e)
        {
            //WeatherForecastEvent(this, e);
            WeatherForecastEvent?.Invoke(this, e);
        }
    }

    public class Subscriber
    {
        private readonly int id;
        private readonly Publisher _publisher;

        public Subscriber(int id, Publisher publisher)
        {
            this.id = id;
            this._publisher = publisher;

            _publisher.WeatherForecastEvent += HandleWeatherForecastEvent;
        }

        private void HandleWeatherForecastEvent(object sender, WeatherEventArgs e)
        {
            Debug.Print($"Subscriver {id} received event: {e.Date}, {e.Temeperature}");
        }
    }
}
