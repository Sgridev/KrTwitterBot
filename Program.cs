using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace twitterBot1
{
    class Program
    {
        private static  string customer_key = "3wxC4PHtaE2Yzq5LaBKop0bsJ";
        private static  string customer_key_secret = "yMF5kFNZ2CfEoHfjluSaz1m4WLmrDwWJhZmco2ebxHx0Mvtm5K";
        private static  string access_token = "1158289304612986880-05SCqmpAV4reqZDXv2wiH3YoE2v0Mu";
        private static  string access_token_secret = "tE1XMvCMOoQW21tdLuVqfYtwcmJLGxe2gF9QSQ2QTNhQN";
   
        private static TwitterService service = new TwitterService(customer_key, customer_key_secret, access_token, access_token_secret);
        private static Random random = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine($"<{DateTime.Now}> - Bot Started");
            SendTweet("Daily reminder: Sara è bellissima " + random.Next(1000).ToString());
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
