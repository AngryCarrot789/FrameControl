using System;
using System.Collections.Generic;

namespace FrameControl.Core.Services {
    public class ServiceManager {
        public static ServiceManager Instance { get; } = new ServiceManager();

        private readonly Dictionary<Type, object> map;

        public ServiceManager() {
            this.map = new Dictionary<Type, object>();
        }

        public T Get<T>() {
            if (this.map.TryGetValue(typeof(T), out object value)) {
                return (T) value;
            }
            else {
                throw new Exception("No view model available for type: " + typeof(T));
            }
        }

        public void Set<T>(T value) {
            this.map[typeof(T)] = value;
        }
    }
}