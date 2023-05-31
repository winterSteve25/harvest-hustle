using System.IO;

namespace Lib.Serialization.Impls
{
    public class BinaryDataReader : IDataReader
    {
        private BinaryReader _binaryReader;

        public BinaryDataReader(Stream stream)
        {
            _binaryReader = new BinaryReader(stream);
        }
    }
}