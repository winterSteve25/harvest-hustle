using System;

namespace Lib.Serialization
{
    public class Optional<T>
    {
        private readonly bool _isPresent;
        private readonly T _value;

        private Optional(T value)
        {
            _value = value;
            _isPresent = _value != null;
        }

        private Optional()
        {
            _value = default;
            _isPresent = false;
        }

        public T Unwrap()
        {
            return _value;
        }
        
        public T UnwrapOrDefault(T def = default)
        {
            return _isPresent ? _value : def;
        }

        public Optional<TR> Map<TR>(Func<T, TR> mapper)
        {
            return !_isPresent ? Optional<TR>.None() : Optional<TR>.Some(mapper(_value));
        }

        public void IfPresent(Action<T> action)
        {
            if (!_isPresent) return;
            action(_value);
        }

        public static Optional<T> Some(T value)
        {
            return new Optional<T>(value);
        }

        public static Optional<T> None()
        {
            return new Optional<T>();
        }
    }
}