using GenGen.GoModelParser;
using System;

namespace GenGen.CLI
{
    class Program
    {
        /// <summary>
        /// 输入：一堆模型文件，可以是 Go 语言的结构体，也可以是 Java/PHP/Python
        /// 输出：
        /// 1. 后端代码：控制器、服务、模型、仓库（可以输出各种语言）
        /// 2. 前端代码
        ///      1. API 调用的封装（JS，TS）
        ///      2. 增删查改的界面（可以是 Vue，React）
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // 渲染流程
            // ---
            // 读入文件/输入流（IParser 接口）
            // -> 解析得到多个模型的原始 metadata（放在 modelProvider 里）
            // -> 整理模型之间的关系，生成更多复杂数据（放在 ModelContext 里）
            // -> 梳理出渲染所需要的数据（放在 templateContext 里）
            // -> 渲染（IRenderer 接口）

            // 设计一个 IModelParser 接口，规定一组要支持的方法。
            // 接口可以各种方式实现，从而能够 Parse 各个语言的输入
            var goParser = new GoModelParser.Parser();            
            goParser.Read(System.IO.File.ReadAllText("user.go"));
            // modelProvider 是一堆模型的容器，存放模型，提供模型查找、依赖处理
            var modelProvider = goParser.Parse();
            // 
            var modelContext = new ModelContext.ModelContext(modelProvider);
            modelContext.AddProvider(modelProvider);
            var templateContext = new TemplateContext.TemplateContext(modelContext);

            var bRenderer = new GoBackendRenderer.Renderer(templateContext);
            bRenderer.Render();

        }
    }
}
