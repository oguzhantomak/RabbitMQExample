using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory();
factory.Uri = new Uri("yourMQConnectionString");

using var connection = factory.CreateConnection();
var channel = connection.CreateModel();


//channel.QueueDeclare("first queue ", true, false, false);

var consumer = new EventingBasicConsumer(channel);

/*
 * consumer = que. name
 * autoAck = if the message is true or false delete the message from que. If the mark false, if the message is true we need to approve the message it's true and then delete the message from que.
 */
channel.BasicConsume("first queue", true, consumer);

consumer.Received += (sender, eventArgs) =>
{
    var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
    Console.WriteLine("Incoming message: " + message.ToString());
};

Console.ReadLine();
