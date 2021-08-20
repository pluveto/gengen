using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenGen.TemplateContext
{
    public interface ITemplateContext { }
    public class TemplateContext
    {
        public TemplateContext(ModelContext.ModelContext modelContext)
        {
            ModelContext = modelContext;
        }

        public ModelContext.ModelContext ModelContext { get; }
    }
}
