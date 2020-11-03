using Grpc.Core;
using opencv_raspberry_test.shared;
using System.Threading.Tasks;

namespace opencv_raspberry_test.server.Services
{
    public class GrpcTestServer : shared.Greeter.GreeterBase
    {
        public override async Task SayHello(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            while (true)
            {
                await responseStream.WriteAsync(new());
                await Task.Delay(30_000);
            }
        }
    }
}
