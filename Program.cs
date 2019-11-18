using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;
using static System.Net.Mime.MediaTypeNames;
//now with 100% less binded public credentials
namespace twitterBot1
{
    class Program
    {
        private static string customer_key = ConfigurationManager.AppSettings["customer_key"];
        private static  string customer_key_secret = ConfigurationManager.AppSettings["customer_key_secret"];
        private static  string access_token = ConfigurationManager.AppSettings["access_token"];
        private static  string access_token_secret = ConfigurationManager.AppSettings["access_token_secret"];
      
        private static TwitterService service = new TwitterService(customer_key, customer_key_secret, access_token, access_token_secret);
        private static Random random = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine($"<{DateTime.Now}> - Bot Started");
            SendTweet("Daily reminder: Sara è bellissima " + random.Next(10000).ToString());
            Console.Read();
        }

        private static void SendTweet(string _status)
        {
           
            service.SendTweet(new SendTweetOptions{ Status = _status} , (tweet, response) =>
            {
                if(response.StatusCode == System.Net.HttpStatusCode.OK){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"<{DateTime.Now}> - Tweet Sent!");
                    Console.ResetColor();
                    Environment.Exit(0);
                }
            else
            {
                 if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"<ERROR> " + response.Error.Message);
                    Console.ResetColor();
                    
            }
        
        });
          

            }
    }
}
