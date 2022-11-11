namespace Namespace1
{
    public class ClassA
    {
        public string Field1;
        public int Field2;
        public bool Field3;
        public double Field6;
    }
}

namespace Namespace2
{

    public class ClassB
    {
        public string Field1;
        public bool Field2;

        public int CharCount(string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }

        public void Counter(int k)
        {
            for (int i = 0; i < 10; i++)
            {
                k++;
            }
        }
    }
}

namespace Namespace3
{

    public class ClassC
    {
        public double Field3 { get; set; }
        public int Field4 { get; set; }
        public string Field5;
        public bool Field6;

        public string Method1(string str, int t, bool isCorrect)
        {
            return str;
        }
    }
}