using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace EventHubProducerV5
{
   class Program
   {
      static async Task Main(string[] args)
      {
         var hubConn = "Endpoint=sb://chyaeventhub.servicebus.windows.net/;SharedAccessKeyName=SendToHub;SharedAccessKey=KOP/lcCcI7UdbuQPmJyZUxK4ujYzFdrtX3MLJLzNJyU=;EntityPath=chyahub";
         var hubName = "chyahub";

         Console.WriteLine("Event Hub Producer V5...");

         var client = new EventHubProducerClient(hubConn, hubName);

         //Send in batch, max 1MB per send
         Console.WriteLine("Enter event data (Q to quit):");
         var dataList = new List<EventData>();
         while (true)
         {
            var msg = Console.ReadLine();
            if (msg == "Q")
            {
               break;
            }
            var data = new EventData(new BinaryData(msg));
            dataList.Add(data);
         }

         await client.SendAsync(dataList);

         Console.WriteLine("Event sent...");

         Console.ReadKey();

         await client.CloseAsync();

      }
   }
}
