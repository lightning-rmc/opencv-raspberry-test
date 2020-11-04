using System.ComponentModel;

namespace opencv_raspberry_test.server.Services
{
    public class SpeedService : INotifyPropertyChanged
    {
        private int _frequence = 1;
        public int Frequence { get => _frequence; set { _frequence = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Frequence))); } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
