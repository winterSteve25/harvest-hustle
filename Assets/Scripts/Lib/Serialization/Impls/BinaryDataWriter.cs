using System.IO;

namespace Lib.Serialization.Impls
{
    public class BinaryDataWriter : IDataWriter
    {
        private BinaryWriter _binaryWriter;

        public BinaryDataWriter(Stream stream)
        {
            _binaryWriter = new BinaryWriter(stream);
        }
    }
}