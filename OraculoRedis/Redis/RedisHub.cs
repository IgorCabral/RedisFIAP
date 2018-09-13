using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OraculoRedis.Redis
{
    public static class RedisHub
    {
        public static void EstabelecerConexao()
        {
            var redis = ConnectionMultiplexer.Connect("127.0.0.1");

            

                var sub = redis.GetSubscriber();
                var db = redis.GetDatabase();                

                sub.Subscribe("perguntas", (ch, msg) =>
                {
                    Console.WriteLine(msg.ToString());

                    Task.Delay(1000).Wait();
                    var resposta = Console.ReadLine();
                    db.HashSet("perguntas", new HashEntry[] { new HashEntry("olhacara", resposta) });
                });            

            comecarDenovo:
                Task.Delay(1000).Wait();            
            goto comecarDenovo;                
        }
    }
}
