using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_Api
{
    public class Receiver
    {
        public void Receive()
        {

            MessageQueue BookMSMQ = new MessageQueue(@".\Private$\BookMSMQ");
            List<string> msmqReceive = new List<string>();
            try
            {
                Message[] Messages = BookMSMQ.GetAllMessages();

                if (Messages.Length > 0)
                {
                    foreach (Message msg in Messages)
                    {
                        msg.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                        string Result = msg.Body.ToString();
                        BookMSMQ.Receive();
                        msmqReceive.Add(Result);
                        BookMSMQ.Refresh();
                    }
                }
                else
                {
                    Console.WriteLine("No New Messages in Message Queue");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
<<<<<<< HEAD
                TextWriter tw = new StreamWriter(@"C:\Users\user\mix\Desktop\BookStoreAppCohort-D\BookStore_Backend\BookStore_Api\ReceiveMessage.txt");
=======
                TextWriter tw = new StreamWriter(@"C:\Users\Anoop Kumar\Desktop\BookStoreAppCohort-D\BookStore_Backend\BookStore_Api\ReceiveMessage.txt");
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a

                foreach (String s in msmqReceive)
                    tw.WriteLine(s);

                tw.Close();
                BookMSMQ.Close();
                                             
            }

        }
    }
}
