using GenGen.ModelProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenGen.ModelContext
{
    public class ModelContext
    {
        public ModelContext(IModelProvider modelProvider)
        {
            this.modelProvider = modelProvider;
        }

        private IModelProvider modelProvider { get; set; }

        public void AddProvider(IModelProvider modelProvider)
        {
            throw new NotImplementedException();
        }
    }
}
