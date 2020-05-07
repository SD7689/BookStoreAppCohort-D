using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_Api
{
    public class Sender
    {
        public void Send(object value)
        {
            try
            {
                MessageQueue Msmq = null;
                if (MessageQueue.Exists(@".\Private$\Msmq"))
                {
                    Msmq = new MessageQueue(@".\Private$\Msmq");
                }
                else
                {
                    Msmq = MessageQueue.Create(@".\Private$\Msmq");
                }
                Msmq.Send(value.ToString(), "Message send");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
