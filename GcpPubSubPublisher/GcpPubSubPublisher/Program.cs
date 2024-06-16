using Google.Apis.Auth.OAuth2;
using Google.Cloud.PubSub.V1;
using Grpc.Auth;

namespace GcpPubSubPublisher
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //var saCredential = new ServiceAccountCredential
            var credential = GoogleCredential.FromFile(@"E:\Dev\GCPPubSubTeste\GcpPubSubPublisher\gcp-4-dev-417723-6fbbcbe3bfbd.json");

            var createSettings = new PublisherClient.ClientCreationSettings(credentials: credential.ToChannelCredentials());

            var topic = TopicName.FromProjectTopic("gcp-4-dev-417723", "teste_topic_tf");
            var publisher = await PublisherClient.CreateAsync(topic, clientCreationSettings: createSettings);

            int publishedMessageCount = 0;
            var message = "Testando Publisher no Topico do neco2";
            try
            {
                string publishMessage = await publisher.PublishAsync(message);
                Console.WriteLine($"Published message {publishMessage}");
                Interlocked.Increment(ref publishedMessageCount);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error ocurred when publishing message {message}: {exception.Message}");
            }

        }
    }
}
