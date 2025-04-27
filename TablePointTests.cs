using Lab12;

namespace Testing;

[TestClass]
public class TablePointTests
{
        [TestMethod]
        public void TestConstructorWithoutParameters()
        {
            // Arrange
            TablePoint<int> expected = new TablePoint<int>();
            expected.Data = default(int);
            expected.Next = null;

            // Act
            TablePoint<int> actual = new TablePoint<int>();

            // Assert
            Assert.AreEqual(expected.Data, actual.Data);
            Assert.IsNull(actual.Next);
        }

        [TestMethod]
        public void TestConstructorWithParameter()
        {
            // Arrange
            int testData = 42;
            TablePoint<int> expected = new TablePoint<int>();
            expected.Data = testData;
            expected.Next = null;

            // Act
            TablePoint<int> actual = new TablePoint<int>(testData);

            // Assert
            Assert.AreEqual(expected.Data, actual.Data);
            Assert.IsNull(actual.Next);
        }

        [TestMethod]
        public void TestToString()
        {
            // Arrange
            int testData = 42;
            TablePoint<int> point = new TablePoint<int>(testData);

            // Act
            string result = point.ToString();

            // Assert
            Assert.AreEqual(testData.ToString(), result);

            // ???????? ??? ??????, ????? Data == null
            TablePoint<int?> nullablePoint = new TablePoint<int?>();
            string resultNull = nullablePoint.ToString();
            Assert.AreEqual("null", resultNull);
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            // Arrange
            int testData = 42;
            TablePoint<int> point = new TablePoint<int>(testData);

            // Act
            int hashCode = point.GetHashCode();

            // Assert
            Assert.AreEqual(testData.GetHashCode(), hashCode);

            // ???????? ??? ??????, ????? Data == null
            TablePoint<int?> nullablePoint = new TablePoint<int?>();
            int hashCodeNull = nullablePoint.GetHashCode();
            Assert.AreEqual(0, hashCodeNull); // ???? Data == null, ???????????? 0
        }

}