namespace TestProject;

using System.Reflection;
using Xunit.Sdk;

public sealed class RepeatAttribute : AutoMoqDataAttribute
{
    private readonly int _count;

    public RepeatAttribute(int count)
    {
        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(
                paramName: nameof(count),
                message: "Repeat count must be greater than 0."
            );
        }
        _count = count;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        for (var i = 0; i < _count; ++i)
        {
            yield return base.GetData(testMethod).First();
        }
    }
}