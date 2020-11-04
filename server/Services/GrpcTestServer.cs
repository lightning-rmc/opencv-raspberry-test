using Grpc.Core;
using Microsoft.Extensions.Logging;
using opencv_raspberry_test.shared;
using System.Threading.Tasks;

namespace opencv_raspberry_test.server.Services
{
    public class GrpcTestServer : shared.Greeter.GreeterBase
    {
        private readonly ILogger<GrpcTestServer> logger;
        private readonly SpeedService speedService;

        public GrpcTestServer(ILogger<GrpcTestServer> logger, SpeedService speedService)
        {
            this.logger = logger;
            this.speedService = speedService;
        }
        public override async Task SayHello(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("next");
                await responseStream.WriteAsync(new());
                await Task.Delay(1_000/speedService.Frequence);
            }
            logger.LogInformation("Killed");
        }
    }
}
