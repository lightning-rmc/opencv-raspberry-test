﻿using Grpc.Core;
using Grpc.Net.Client;
using OpenCvSharp;
using System.Net.Http;

namespace opencv_raspberry_test.client
{
    class Program
    {
        static void Main(string[] args)
        {
            //  using var src = Cv2.ImRead("Kamera_2.png");

            // using (new Window("SubMat", src))
            // {
            //     Cv2.WaitKey();
            // }
            try
            {
                var httpHandler = new HttpClientHandler();
                // Return `true` to allow certificates that are untrusted/invalid
                httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;


                var channel = GrpcChannel.ForAddress("https://localhost:5001",
                new() { HttpHandler = httpHandler });

                var client = new shared.Greeter.GreeterClient(channel);

                var stream = client.SayHello(new());
                using (var window = new Window("capture"))
                {
                    while (true)
                    {
                        using var capture = new VideoCapture("alone_low.mp4");
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
                }
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);

                throw;
            }

            // Console.ReadKey();
        }
    }
}
