namespace TestProject;

using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

public class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute() : this(Array.Empty<ICustomization>())
    {
    }

    private AutoMoqDataAttribute(params ICustomization[] customizations) : base(
        () =>
        {
            var fixture = new Fixture()
                .Customize(new AutoMoqCustomization { ConfigureMembers = true });

            //fixture.Customize(new OmitAutoPropertiesForRecordTypes());

            foreach (var customization in customizations)
            {
                fixture.Customize(customization);
            }

            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            return fixture;
        })
    {
    }
}

