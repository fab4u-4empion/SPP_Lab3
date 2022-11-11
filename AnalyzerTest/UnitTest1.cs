using Analyzer.Core;
using Analyzer.Info;

namespace AnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        private AnalyzeResult result = AssemblyAnalyzer.Analyze("D:\\ÁÃÓÈÐ\\5 סולוסענ\\ÑÏÏ\\Ëאבא3\\Lab3\\TestClass\\bin\\Debug\\net6.0\\TestClass.dll");

        [TestMethod]
        public void TestResult()
        {
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestNamespacesCount()
        {
            Assert.AreEqual(result.Namespaces.Count, 3);
        }

        [TestMethod]
        public void TestTypesCount()
        {
            Assert.AreEqual(result.NamespacesDictionary["Namespace2"].Types.Count, 1);
        }

        [TestMethod]
        public void TestMethodsCount()
        {
            Assert.AreEqual(result.NamespacesDictionary["Namespace2"].Types[0].Methods.Count, 6);
        }

        [TestMethod]
        public void TestFieldsCount()
        {
            Assert.AreEqual(result.NamespacesDictionary["Namespace2"].Types[0].Fields.Count, 2);
        }

        [TestMethod]
        public void TestProperiesCount()
        {
            Assert.AreEqual(result.NamespacesDictionary["Namespace2"].Types[0].Properties.Count, 0);
        }
    }
}