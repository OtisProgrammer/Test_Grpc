using ClientApp.Person;
using Grpc.Net.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7036");
var client = new People.PeopleClient(channel);
var reply = await client.GetAsync(new GetRequest() { Id = 1 });
Console.WriteLine("Person : " + reply.FirstName + " " + reply.LastName);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();