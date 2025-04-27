using ToolLibrary;

namespace Testing
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void TestConstruct1()
        {
            // Arrange & Act
            Lab12.List<Tool> list = new Lab12.List<Tool>();

            // Assert
            Assert.IsNull(list.begin);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestAddToEnd_WithEmptyList()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            Tool item = new Tool();

            // Act
            list.AddToEnd(item);

            // Assert
            Assert.IsNotNull(list.begin);
            Assert.AreEqual(item, list.begin.Data);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void TestAddToEnd_WithNonEmptyList()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            list.AddToEnd(new Tool());
            list.AddToEnd(new Tool());

            // Act
            list.AddToEnd(new Tool());

            // Assert
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(new Tool().Name, list.begin.Next.Next.Data.Name);
        }

        [TestMethod]
        public void TestAddToBegin()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            list.AddToEnd(new Tool());
            list.AddToEnd(new Tool());

            // Act
            list.AddToBegin(new Lab12.Point<Tool>(new Tool()));

            // Assert
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(new Tool().Name, list.begin.Data.Name); // Сравниваем конкретные поля вместо всего объекта
            Assert.AreEqual(new Tool().Name, list.begin.Next.Data.Name); // Сравниваем конкретные поля вместо всего объекта
        }

        [TestMethod]
        public void TestAddToIndex_Middle()
            {
            // Arrange
                Lab12.List<Tool> list = new Lab12.List<Tool>();
                Tool tool1 = new Tool("Перфоратор 1", 1);
                Tool tool2 = new Tool("Перфоратор 2", 2);
                Tool tool3 = new Tool("Перфоратор 3", 3);

                list.AddToEnd(tool1);
                list.AddToEnd(tool3);

                // Act
                list.AddToIndex(new Lab12.Point<Tool>(tool2), 1);

                // Assert
                Assert.AreEqual(3, list.Count);
                Assert.AreEqual(tool2.Name, list.begin.Next.Data.Name);
            }

        [TestMethod]
        public void TestAddToIndex_Begin()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            Tool tool1 = new Tool("Перфоратор 1", 1);
            Tool tool2 = new Tool("Перфоратор 2", 2);

            list.AddToEnd(tool1);

            // Act
            list.AddToIndex(new Lab12.Point<Tool>(tool2), 0);

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(tool2.Name, list.begin.Data.Name);
        }

        [TestMethod]
        public void TestAddToIndex_End()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            Tool tool1 = new Tool("Перфоратор 1", 1);
           Tool tool2 = new Tool("Перфоратор 2", 2);

            list.AddToEnd(tool1);

            // Act
            list.AddToIndex(new Lab12.Point<Tool>(tool2), 1);

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(tool2.Name, list.begin.Next.Data.Name);
        }

        [TestMethod]
        public void TestContains_True()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            Tool tool1 = new Tool("Перфоратор 1", 1);
            Tool tool2 = new Tool("Перфоратор 2", 2);

            list.AddToEnd(tool1);
            list.AddToEnd(tool2);

            // Act
            bool result = list.Contains(tool2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestContains_False()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            var tool1 = new Tool("Перфоратор 1", 1);
            var tool2 = new Tool("Перфоратор 2", 2);

            list.AddToEnd(tool1);

            // Act
            bool result = list.Contains(tool2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRemoveByIndex_Head()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            var tool1 = new Tool("Перфоратор 1", 1);
            var tool2 = new Tool("Перфоратор 2", 2);

            list.AddToEnd(tool1);
            list.AddToEnd(tool2);

            // Act
            bool result = list.RemoveByIndex(0);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(tool2.Name, list.begin.Data.Name);
        }

        [TestMethod]
        public void TestRemoveByIndex_Middle()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            var tool1 = new Tool("Перфоратор 1", 1);
            var tool2 = new Tool("Перфоратор 2", 2);
            var tool3 = new Tool("Перфоратор 3", 3);

            list.AddToEnd(tool1);
            list.AddToEnd(tool2);
            list.AddToEnd(tool3);

            // Act
            bool result = list.RemoveByIndex(1);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(tool3.Name, list.begin.Next.Data.Name);
        }

        [TestMethod]
        public void TestRemoveByIndex_Tail()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            var tool1 = new Tool("Перфоратор 1", 1);
            var tool2 = new Tool("Перфоратор 2", 2);

            list.AddToEnd(tool1);
            list.AddToEnd(tool2);

            // Act
            bool result = list.RemoveByIndex(1);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, list.Count);
            Assert.IsNull(list.begin.Next);
        }

        [TestMethod]
        public void TestClear()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            var tool1 = new Tool("Перфоратор 1", 1);
            var tool2 = new Tool("Перфоратор 2", 2);

            list.AddToEnd(tool1);
            list.AddToEnd(tool2);

            // Act
            list.Clear();

            // Assert
            Assert.IsNull(list.begin);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestClone_CreatesIndependentCopy()
        {
            // Arrange
            Lab12.List<Tool> list = new Lab12.List<Tool>();
            var tool1 = new Tool("Перфоратор 1", 1);
            var tool2 = new Tool("Перфоратор 2", 2);

            list.AddToEnd(tool1);
            list.AddToEnd(tool2);

            // Act
            Lab12.List<Tool> clonedList = (Lab12.List<Tool>)list.Clone();

            // Assert
            Assert.IsNotNull(clonedList);
            Assert.AreEqual(list.Count, clonedList.Count);
            Assert.AreEqual(list.begin.Data.Name, clonedList.begin.Data.Name);
            Assert.AreNotSame(list.begin, clonedList.begin);
        }

    }
}
