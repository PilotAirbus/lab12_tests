using Lab12;

namespace Testing;

[TestClass]
public class TableTests
{
        [TestMethod]
        public void TestConstructor()
        {
            Table<int> table = new Table<int>();
            Assert.IsNotNull(table.set);
            Assert.AreEqual(10, table.Count);
        }

        [TestMethod]
        public void TestAdd_SingleElement()
        {
            Table<int> table = new Table<int>();
            table.Add(42);
            int index = Math.Abs(42.GetHashCode()) % table.Count;
            Assert.IsNotNull(table.set[index]);
            Assert.AreEqual(42, table.set[index].Data);
        }

        [TestMethod]
        public void TestAdd_Duplicate()
        {
            Table<int> table = new Table<int>();
            table.Add(42);
            table.Add(42);
            int index = Math.Abs(42.GetHashCode()) % table.Count;
            Assert.IsNull(table.set[index].Next);
        }

        [TestMethod]
        public void TestContains_ExistingElement()
        {
            Table<int> table = new Table<int>();
            table.Add(42);
            Assert.IsTrue(table.Contains(42));
        }

        [TestMethod]
        public void TestContains_NonExistingElement()
        {
            Table<int> table = new Table<int>();
            Assert.IsFalse(table.Contains(42));
        }

        [TestMethod]
        public void TestRemove_FirstElementInChain()
        {
            Table<int> table = new Table<int>();
            table.Add(42);
            bool result = table.Remove(42);
            Assert.IsTrue(result);
            Assert.IsNull(table.set[Math.Abs(42.GetHashCode()) % table.Count]);
        }

        [TestMethod]
        public void TestRemove_NonExistingElement()
        {
            Table<int> table = new Table<int>();
            bool result = table.Remove(42);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestClear()
        {
            Table<int> table = new Table<int>();
            table.Add(42);
            table.Clear();
            Assert.IsNull(table.set);
        }

        [TestMethod]
        public void TestPrint()
        {
            Table<int> table = new Table<int>();
            table.Add(42);
            table.Add(43);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                table.Print();
                string output = sw.ToString();
                Assert.IsTrue(output.Contains("42"));
                Assert.IsTrue(output.Contains("43"));
            }
        }
    
        [TestMethod]
        public void TestRemove_LastElementInChain()
    {
        Table<int> table = new Table<int>();
        table.Add(42);
        table.Add(43);
        bool result = table.Remove(43);
        Assert.IsTrue(result);
        int index = Math.Abs(42.GetHashCode()) % table.Count;
        Assert.AreEqual(42, table.set[index].Data);
        Assert.IsNull(table.set[index].Next);
    }
    
        [TestMethod]
        public void TestAdd_NullElement()
    {
        Table<string> table = new Table<string>();
        Assert.ThrowsException<Exception>(() => table.Add(null));
    }
    
        [TestMethod]
        public void TestPrint_EmptyTable()
    {
        Table<int> table = new Table<int>();

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            table.Print();
            string output = sw.ToString();
            Assert.IsTrue(output.Contains(":"));
        }
    }
    
        [TestMethod]
        public void TestClear_AfterMultipleAdds()
    {
        Table<int> table = new Table<int>();
        table.Add(42);
        table.Add(43);
        table.Clear();
        Assert.IsNull(table.set);
    }
}
