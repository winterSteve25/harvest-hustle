namespace Lib.Serialization
{
    public interface IDeserializable
    {
        void Deserialize(IDataReader dataReader);
    }
}