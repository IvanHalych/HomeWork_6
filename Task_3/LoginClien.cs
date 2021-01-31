using System;
using System.Threading;

namespace Task3
{
    internal static class LoginClien
    {
        internal static string Login(string login, string password)
        {
            Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble()));
            if (new Random().NextDouble() <= 0.5)
            {
                return Guid.NewGuid().ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
