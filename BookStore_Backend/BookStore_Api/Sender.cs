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
                MessageQueue BookMSMQ = null;
                if (MessageQueue.Exists(@".\Private$\Msmq"))
                {
                    BookMSMQ = new MessageQueue(@".\Private$\Msmq");
                }
                else
                {
                    BookMSMQ = MessageQueue.Create(@".\Private$\Msmq");
                }
                BookMSMQ.Send(value.ToString(), "Message send");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
