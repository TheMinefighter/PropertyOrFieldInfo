# How to use
to print all names of Fields and Properties of TestType use:

    foreach (FieldOrProperyInfo info in typeof(TestType).GetTypeInfo().DeclaredPropertiesAndFields()) {
    	Console.WriteLine(info.Name);
    }

For further information about using features of this package visit [this](./CodingDoc.html).+
# License
This project has been published by Tobias Brohl under [MIT License](https://raw.githubusercontent.com/TheMinefighter/PropertyOrFieldInfo/master/LICENSE.md)
# Bug Reports
Please report any Bugs  [here](https://github.com/TheMinefighter/PropertyOrFieldInfo/issues), then I can fix them probably within 24h!
# Attribution:
Parts of [this](https://github.com/dotnet/dotnet-api-docs/blob/master/xml/System.Reflection/MemberInfo.xml) licensed by the Microsoft Corporation under [MIT License](https://github.com/dotnet/dotnet-api-docs/blob/master/LICENSE-CODE) were used in this project.
# Contribution
Please review [this](https://raw.githubusercontent.com/TheMinefighter/PropertyOrFieldInfo/master/CONTRIBUTING.md) before contributing.
