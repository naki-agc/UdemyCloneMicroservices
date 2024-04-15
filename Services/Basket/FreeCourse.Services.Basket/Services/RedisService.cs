using StackExchange.Redis;
using System;

namespace FreeCourse.Services.Basket.Services
{
    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;

        private ConnectionMultiplexer _ConnectionMultiplexer;  // redisle bağlantı sağlayacak sınıf 


        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }


        public void Connect() => _ConnectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1) => _ConnectionMultiplexer.GetDatabase(db);  //redisin 1 2 3 olarak içerdiği sayılar bu sınıf içerisinde mevcutlarmıi


    }

}
