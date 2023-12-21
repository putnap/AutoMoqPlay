namespace TestProject;

using System.Reflection;
using System.Runtime.CompilerServices;
using AutoFixture;
using AutoFixture.Kernel;

public class OmitPropertyForRecordTypes : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        // CompilerGeneratedAttribute signals record type property
        if (request is PropertyInfo propertyInfo &&
            !propertyInfo.GetCustomAttributes<CompilerGeneratedAttribute>().Any())
        {
            return new OmitSpecimen();
        }

        return new NoSpecimen();
    }
}

public class OmitAutoPropertiesForRecordTypes : ICustomization
{
    public void Customize(IFixture fixture) =>
        fixture.Customizations.Add(new OmitPropertyForRecordTypes());
}
