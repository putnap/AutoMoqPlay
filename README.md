This project reproduces performance issue with using AutoFixture to create large record types.

Command to test performance
```
dotnet clean && dotnet build  && time dotnet test
```

Testing two scenarios, with `OmitAutoPropertiesForRecordTypes` Customization added and without.
My own testing in this project showed that by omiting auto properties for record types, I get performance bump from ~400 seconds to about 10.

P.S. I am assuming that `CompilerGeneratedAttribute` marks all the properties of record type so I have a solution wide workaround, instead of going through each type and customizing with `OmitAutoProperties()`.
