using System.ComponentModel;
using System.Threading.Tasks;

namespace opencv_raspberry_test.server.Services
{
    public class SpeedService : INotifyPropertyChanged
    {
        private int _frequence = 1;
        private TaskCompletionSource tcs = new TaskCompletionSource();
        public int Frequence { get => _frequence; set { _frequence = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Frequence))); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Start()
        {
            tcs.TrySetResult();
        }

        public Task GetStartupCall()
        {
            return tcs.Task;
        }
    }
}
