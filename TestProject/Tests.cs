namespace TestProject;

public class Tests
{
    [Theory]
    [Repeat(100)]
    public void Test1(LearningDocument document)
    {
        Assert.NotNull(document.Id);
    }
}