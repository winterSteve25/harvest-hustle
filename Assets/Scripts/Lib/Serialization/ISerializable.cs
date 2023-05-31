namespace Lib.Serialization
{
    public interface ISerializable
    {
        void Serialize(IDataWriter dataWriter);
    }
}