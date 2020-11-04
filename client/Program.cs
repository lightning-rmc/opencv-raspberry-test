using Grpc.Core;
using Grpc.Net.Client;
using OpenCvSharp;
using System.Net.Http;
using System.Threading.Tasks;

namespace opencv_raspberry_test.client
{
    class Program
    {
        static  void Main(string[] args)
        {
            //  using var src = Cv2.ImRead("Kamera_2.png");

            // using (new Window("SubMat", src))
            // {
            //     Cv2.WaitKey();
            // }
            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;


            var channel = GrpcChannel.ForAddress("https://10.0.0.11:5001", 
                                            new() { HttpHandler = httpHandler});

            var client = new shared.Greeter.GreeterClient(channel);

            var stream = client.SayHello(new());
            using var capture = new VideoCapture("alone_hd.mp4");
            using (var window = new Window("capture"))
            {
                while (stream.ResponseStream.MoveNext().Result)
                {

                    // Frame image buffer
                    var image = new Mat();


                    capture.Read(image); // same as cvQueryFrame
                    if (image.Empty())
                        break;

                    window.ShowImage(image);
                    Cv2.WaitKey(1);

                }
            }
            // Console.ReadKey();
        }
    }
}
