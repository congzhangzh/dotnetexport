# 背景
验证将.Net 6.0 中的类导出成C库的方法是否可行

# 理论依据

https://github.com/AaronRobinsonMSFT/DNNE#experimental-attribute

## 核心部分

    ```csharp
    //ref: https://github.com/AaronRobinsonMSFT/DNNE#experimental-attribute

    //1. [必须]原样保留，这是工具要求的
    namespace DNNE
    {
        internal class ExportAttribute : Attribute
        {
            public ExportAttribute() { }
            public string EntryPoint { get; set; }
        }
    }


    public class Exports
    {
        //3. [必须]辅助委托 {Name}Delegate
        public delegate int MyExportDelegate(int a);

        //2. [核心]导出标定
        [DNNE.Export(EntryPoint = "FancyName")] //[DNNE.Export()]?
        public static int MyExport(int a)
        {
            return a;
        }
    }

    ```

# 产出验证

    obj/Debug/net6.0/dnne/bin/dotnetexport.so ：.Net 中的实际方法？
    obj/Debug/net6.0/dnne/bin/dotnetexportNE.so ： C到出库