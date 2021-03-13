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
         var hubConn = "Endpoint=sb://chyaeventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=//JboujWToYmJ2tytgSKApsCgERt2OC4O4/H5uXD7CQ=";
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
            var data = new EventData(Encoding.UTF8.GetBytes(msg));
            dataList.Add(data);
         }

         await client.SendAsync(dataList);

         Console.WriteLine("Event sent...");

         Console.ReadKey();

         await client.CloseAsync();

      }
   }
}
