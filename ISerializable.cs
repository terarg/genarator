using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NonogramGen
{
    public interface ISerializable //тот же интерфейс чо у сани данилова
    {
        public void Serialize(string path);
        public static ISerializable Deserialize(string line) { return null; }
    }
}
