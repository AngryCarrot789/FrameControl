using System;
using System.Collections.Generic;
using REghZy.MVVM.ViewModels;

namespace FrameControl.ViewModels {
    public class VMManager {
        public static VMManager Instance { get; } = new VMManager();

        private readonly Dictionary<Type, object> map;

        public VMManager() {
            this.map = new Dictionary<Type, object>();
        }

        public T Get<T>() where T : BaseViewModel {
            if (this.map.TryGetValue(typeof(T), out object value)) {
                return (T) value;
            }
            else {
                throw new Exception("No view model available for type: " + typeof(T));
            }
        }

        public void Set<T>(T value) where T : BaseViewModel {
            this.map[typeof(T)] = value;
        }
    }
}