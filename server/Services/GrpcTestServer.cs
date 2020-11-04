using Grpc.Core;
using Microsoft.Extensions.Logging;
using opencv_raspberry_test.shared;
using System.Threading.Tasks;

namespace opencv_raspberry_test.server.Services
{
    public class GrpcTestServer : shared.Greeter.GreeterBase
    {
        private readonly ILogger<GrpcTestServer> logger;

        public GrpcTestServer(ILogger<GrpcTestServer> logger)
        {
            this.logger = logger;
        }
        public override async Task SayHello(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("next");
                await responseStream.WriteAsync(new());
                await Task.Delay(1_000/120);
            }
            logger.LogInformation("Killed");
        }
    }
}
