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

            MessageQueue Msmq = new MessageQueue(@".\Private$\Msmq");
            List<string> msmqReceive = new List<string>();
            try
            {
                Message[] Messages = Msmq.GetAllMessages();

                if (Messages.Length > 0)
                {
                    foreach (Message msg in Messages)
                    {
                        msg.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                        string Result = msg.Body.ToString();
                        Msmq.Receive();
                        msmqReceive.Add(Result);
                        Msmq.Refresh();
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
                TextWriter tw = new StreamWriter(@"C:\Users\Kuldeep\Desktop\BookStoreAppCohort-D\BookStore_Backend\BookStore_Api\ReceiveMessage.txt");

                foreach (String s in msmqReceive)
                    tw.WriteLine(s);

                tw.Close();
                Msmq.Close();
            }

        }
    }
}