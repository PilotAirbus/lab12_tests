using Lab12;

using ToolLibrary;

namespace Testing;

[TestClass]
public class ElementTests
{
    [TestMethod]
    public void TestConstructor1()
    {
        // Arrange
        Point<Tool> element = new Point<Tool>();

        // Act
        Point<Tool> expected = new Point<Tool>();
        expected.Data = default(Tool);
        expected.Next = null;
        expected.Prev = null;

        // Assert
        Assert.AreEqual(expected.Data, element.Data);
        Assert.IsNull(element.Next);
        Assert.IsNull(element.Prev);
    }

    [TestMethod]
    public void TestConstructor2()
    {
        // Arrange
        Tool testData = new Tool();
        Point<Tool> element = new Point<Tool>(testData);

        // Act
        Point<Tool> expected = new Point<Tool>();
        expected.Data = testData;
        expected.Next = null;
        expected.Prev = null;

        // Assert
        Assert.AreEqual(expected.Data, element.Data);
        Assert.IsNull(element.Next);
        Assert.IsNull(element.Prev);
    }

    [TestMethod]
    public void TestToString_WithData()
    {
        // Arrange
        Tool testData = new Tool();
        Point<Tool> element = new Point<Tool>(testData);

        // Act
        string result = element.ToString();

        // Assert
        Assert.AreEqual(testData.ToString(), result);
    }

    [TestMethod]
    public void TestToString_WithNullData()
    {
        // Arrange
        Point<Tool> element = new Point<Tool>();

        // Act
        string result = element.ToString();

        // Assert
        Assert.AreEqual("null", result);
    }

}