using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenGen.GoModelParser
{

    public class ModelMeta
    {
        // 模块名
        [JsonProperty("module")] public string Module { get; set; }
        // 模型名（Pascal 命名）
        [JsonProperty("name")] public string Name { get; set; }
        // 表名
        [JsonProperty("table")] public string Table { get; set; }
        // JSON 名
        [JsonProperty("json")] public string Json { get; set; }
        // JSON 名（复数，用于生成 RESTful 路由）
        [JsonProperty("json")] public string JsonPlural { get; set; }
        // 显示名（用于 UI 展示） 
        [JsonProperty("label")] public string Label { get; set; }

        public void AutoFill()
        {
            var sb = new StringBuilder();
            if (Module.Length > 0)
            {
                sb.Append(Module.ToLower());
                sb.Append("_");
            }
            sb.Append()
        }
    }
}
