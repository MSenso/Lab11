using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public static class DeepCopy
    {
        public static T DeepClone<T>(this T @object)
        {
            using (var memory_stream = new MemoryStream())
            {
                var binary_formatter = new BinaryFormatter();
                binary_formatter.Serialize(memory_stream, @object);
                memory_stream.Position = 0;
                return (T)binary_formatter.Deserialize(memory_stream);
            }
        }
    }
}
