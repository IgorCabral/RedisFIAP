using System;
using OraculoRedis.Redis;
using StackExchange.Redis;

namespace OraculoRedis
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisHub.EstabelecerConexao();            
        }
    }
}
