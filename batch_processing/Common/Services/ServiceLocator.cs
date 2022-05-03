using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batch_processing.Common.Services
{
    internal class ServiceLocator
    {
        public ServiceLocator()
        {
            _services = new Dictionary<Type, IService>();
        }

        bool RegisterServiceAs<T>(IService service)
        {
            if (_services.ContainsKey(typeof(T)))
                return false;

            _services.Add(typeof(T), service);
            return true;
        }
        
        IService GetService<T>()
        {
            if (!_services.ContainsKey(typeof(T)))
                return new NullService();

            return _services[typeof(T)];
        }

        T GetServiceAs<T>() where T : IService
        {
            IService serv = GetService<T>();

            if (serv is T)
                return (T)serv;

            return default(T);
        }

        private Dictionary<Type, IService> _services;
    }

    interface IService
    {
        
    }

    public class NullService : IService
    {
        
    }
}
