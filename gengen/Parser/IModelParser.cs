using GenGen.ModelProvider;
using System;
using System.IO;

namespace GenGen.Parser
{
    public interface IModelParser
    {
        public void Read(Stream s);
        public IModelProvider Parse();
    }
}
