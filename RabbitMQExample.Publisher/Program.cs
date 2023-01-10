using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://ecgjjuwy:4sqODmsB-w4KJXi293xnQG5GzegqS2MG@sparrow.rmq.cloudamqp.com/ecgjjuwy");

using var connection = factory.CreateConnection();
var channel = connection.CreateModel();

/*
 * queue = your que. name
 * durable = if you restart rabbitmq your queue  still on.
 * exclusive = if you want to connect this que. from another channel/project you need to use false but if you want to only allow to connect this que in there you need tou mark as true
 * autodelete = if our subsc. is down you want to delete the que. you need to mark as true if you dont false.
 */
channel.QueueDeclare("first queue", true, false, false);


/*
 * Messages are going to que. byte type.
 */

string message = "This is the first que.";

var messageBody = Encoding.UTF8.GetBytes(message);

/*
 * If we dont use Exchange we need to provide routingKey same as declared queue
 */

channel.BasicPublish(string.Empty, "first queue", null, messageBody);
Console.WriteLine("Message sent!");
Console.ReadLine();