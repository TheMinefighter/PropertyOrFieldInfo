# How to use
to print all names of Fields and Properties of TestType use:

    foreach (FieldOrProperyInfo info in typeof(TestType).GetTypeInfo().DeclaredPropertiesAndFields()) {
    	Console.WriteLine(info.Name);
    }

# Bug Reports
Please report any Bugs  [here](projectUrl), then I can fix them probably within 24h!
# Attribution:
Parts of https://github.com/dotnet/dotnet-api-docs/blob/master/xml/System.Reflection/MemberInfo.xml licensed by the Microsoft Corporation under MIT License (https://github.com/dotnet/dotnet-api-docs/blob/master/LICENSE-CODE) were used in this project.