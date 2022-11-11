using System.Reflection;
using System.Text;
using Analyzer.Info;

namespace Analyzer.Core
{
    public class AssemblyAnalyzer
    {
        public static AnalyzeResult Analyze(string path)
        {
            Assembly asm = Assembly.LoadFrom(path);

            AnalyzeResult result = new() { AssemblyName = asm.FullName};

            Type[] types = asm.GetTypes();
            foreach (Type t in types) 
                result.AddType(t);

            return result;
        }
    }
}