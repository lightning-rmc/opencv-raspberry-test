using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using OpenCvSharp;

namespace opencv_raspberry_test.client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //  using var src = Cv2.ImRead("Kamera_2.png");

            // using (new Window("SubMat", src))
            // {
            //     Cv2.WaitKey();
            // }
            var channel = GrpcChannel.ForAddress("https://10.0.0.11//50001");

            var client = new shared.Greeter.GreeterClient(channel);

            var stream =  client.SayHello(new());
            await foreach (var item in stream.ResponseStream.ReadAllAsync())
            {
                using var capture = new VideoCapture("Alone_hd.mp4");
                int sleepTime = (int)Math.Round(1000 / capture.Fps);

                using (var window = new Window("capture"))
                {
                    // Frame image buffer
                    var image = new Mat();

                    // When the movie playback reaches end, Mat.data becomes NULL.
                    while (true)
                    {
                        capture.Read(image); // same as cvQueryFrame
                        if (image.Empty())
                            break;

                        window.ShowImage(image);
                        Cv2.WaitKey(sleepTime);
                    }
                    // Cv2.WaitKey();
                }
            }
            // Console.ReadKey();
        }
    }
}
