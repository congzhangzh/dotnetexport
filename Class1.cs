//namespace dotnetexport;
//ref: https://github.com/AaronRobinsonMSFT/DNNE#experimental-attribute

using System;

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
    public delegate int MyExportDelegate(int a);

    [DNNE.Export(EntryPoint = "FancyName")]
    public static int MyExport(int a)
    {
        return a;
    }
}
