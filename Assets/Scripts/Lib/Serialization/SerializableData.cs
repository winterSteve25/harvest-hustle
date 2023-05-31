using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Lib.Serialization
{
    [Serializable]
    public class SerializableData : ISerializable, IDeserializable
    {
        [ShowInInspector, ReadOnly, OdinSerialize]
        private readonly Dictionary<string, object> _data;

        public SerializableData()
        {
            _data = new Dictionary<string, object>();
        }
        
        public void Set<T>(IDataKey<T> key, T value)
        {
            _data[key.Value] = value;
        }

        public Optional<T> Get<T>(IDataKey<T> key)
        {
            return _data.TryGetValue(key.Value, out var value) ? Optional<T>.Some((T)value) : Optional<T>.None();
        }

        public bool Has<T>(IDataKey<T> key)
        {
            return _data.ContainsKey(key.Value);
        }

        public static bool operator ==(SerializableData obj1, SerializableData obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null))
            {
                return false;
            }

            return obj1._data.SequenceEqual(obj2._data);
        }

        public static bool operator !=(SerializableData obj1, SerializableData obj2)
        {
            return !(obj1 == obj2);
        }

        protected bool Equals(SerializableData other)
        {
            return Equals(_data, other._data);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SerializableData)obj);
        }

        public override int GetHashCode()
        {
            return (_data != null ? _data.GetHashCode() : 0);
        }

        public void Serialize(IDataWriter dataWriter)
        {
            throw new System.NotImplementedException();
        }

        public void Deserialize(IDataReader dataReader)
        {
            throw new System.NotImplementedException();
        }
    }
}