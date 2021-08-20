using GenGen.ModelContext;
using GenGen.ModelProvider;
using GenGen.Parser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GenGen.GoModelParser
{
    public class ModelProvider : IModelProvider
    {
        IModel IModelProvider.GetModel(string name)
        {
            throw new NotImplementedException();
        }

        HashSet<IModel> IModelProvider.GetModelDependencies(IModel model)
        {
            throw new NotImplementedException();
        }

        HashSet<IModel> IModelProvider.GetModels(IModel model)
        {
            throw new NotImplementedException();
        }
    }
    public class Parser : IModelParser
    {

        /// <summary>
        /// 输入：一个 Go 文件，格式为：
        /// package model
        /// 
        /// /*
        ///  * @autocode({"module":"blog", "table": "posts", "json": "post", "label": "文章"})
        ///  */
        /// type BlogPost struct {
        /// 
        ///     ID int64  `json:"id"          gorm:"column=id;primaryKey" auto:"weight=0;searchable=false;sortable=true ;mode=r;required=true; type=text;label=ID"`
        /// 	...
        /// }
        /// 输出：
        /// group 1: meta {"module":"blog", "table": "posts", "json": "post", "label": "文章"}
        /// group 2: modelName BlogPost
        /// group 3: struct body
        /// </summary>
        private string modelRegex = @"@autocode\((.*?)\).*[\n\w\W]*?type (.*?) struct {([\n\w\W]*?)}";


        /// <summary>
        /// 输入：结构体的 Body
        /// 输出：
        /// group 1: 字段变量名
        /// group 2: 字段类型
        /// group 3: Tag
        /// </summary>
        private string bodyRegex = @"\W*(\w*?)\W+(\w*?)\W+`(.*?)`";
        // 输入：tag，如 json:"id" gorm:"column=id;primaryKey"
        // 输出
        // group 1: tagKey
        // group 2: tagValue
        private string tagRegex = @"(\w*?):""(.*?)""";
        public void Read(string s)
        {
            ModelBasicData data = ReadBasicData(s);
        }
        private ModelBasicData ReadBasicData(string s)
        {
            RegexOptions options = RegexOptions.Multiline;
            var matches = Regex.Matches(s, modelRegex, options);
            foreach (Match m in matches)
            {
                var metaJson = m.Groups[1].Value;
                var modelMeta = JsonConvert.DeserializeObject<ModelMeta>(metaJson);
            }
        }

        public ModelProvider Parse()
        {
            throw new NotImplementedException();
        }
    }
}
