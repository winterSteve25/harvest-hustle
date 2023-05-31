namespace Lib.Serialization
{
    public readonly struct DataKey<T> : IDataKey<T>
    {
        public string Value { get; }
        
        public DataKey(string value)
        {
            Value = value;
        }
    }
}