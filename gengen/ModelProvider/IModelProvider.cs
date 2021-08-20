using GenGen.ModelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenGen.ModelProvider
{
    public interface IModelProvider
    {
        public IModel GetModel(string name);
        public HashSet<IModel> GetModelDependencies(IModel model);
        public HashSet<IModel> GetModels(IModel model);
    }
}
