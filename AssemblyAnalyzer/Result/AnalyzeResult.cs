using System.Collections.Concurrent;
using System.Reflection;

namespace Analyzer.Info
{
    public class MethodInfo
    {
        public string Name { get; set; }

        public string ReturnedType { get; set; }

        public string ParameterTypes { get; set; }
    }

    public class TypeInfo
    {
        private List<MethodInfo> _methods = new();

        public string Name { get; set; }

        public List<FieldInfo> Fields { get; set; }

        public List<PropertyInfo> Properties { get; set; }

        public List<MethodInfo> Methods { get => _methods;}

        public void AddMethods(System.Reflection.MethodInfo[] methods)
        {
            foreach (var method in methods)
                _methods.Add(new MethodInfo()
                {
                    Name = method.Name,
                    ReturnedType = method.ReturnType.Name,
                    ParameterTypes = String.Join(" ", method.GetParameters().Select(p => p.ParameterType.Name)) 
                });
        }
    }

    public class NamespaceInfo
    {
        public string Name { get; set; }

        public ICollection<TypeInfo> Types
        {
            get => _types.Values;
        }

        private ConcurrentDictionary<string, TypeInfo> _types = new();

        public ConcurrentDictionary<string, TypeInfo> TypesDictionary { get => _types; }

        public void AddType(Type type)
        {
            TypeInfo t = _types.GetOrAdd(type.Name, new TypeInfo() { Name = type.Name });
            t.Fields = new List<FieldInfo>(type.GetFields());
            t.Properties = new List<PropertyInfo>(type.GetProperties());
            t.AddMethods(type.GetMethods());
        }
    }

    public class AnalyzeResult
    {
        public string AssemblyName { get; set; }

        public ICollection<NamespaceInfo> Namespaces {
            get => _namesapces.Values;
        }

        public ConcurrentDictionary<string, NamespaceInfo> NamespacesDictionary { get => _namesapces; }

        private ConcurrentDictionary<string, NamespaceInfo> _namesapces = new();

        public void AddType(Type type)
        {
            if (type.Namespace != "System.Runtime.CompilerServices" && type.Namespace != "Microsoft.CodeAnalysis")
            {
                NamespaceInfo nsp = _namesapces.GetOrAdd(type.Namespace, new NamespaceInfo() { Name = type.Namespace });
                nsp.AddType(type);
            }
        }
    }
}
