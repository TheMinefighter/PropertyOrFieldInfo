## How to use
to print all names of Fields and Properties of TestType use:

    foreach (FieldOrProperyInfo info in typeof(TestType).GetTypeInfo().GetPropertiesAndFields()) {
    	Console.WriteLine(info.Name);
    }

For further information about using features of this package visit [this](./CodingDoc.html).
## Download
Download this package in your NuGet Client or [here](https://www.nuget.org/packages/PropertyOrFieldInfo)
## License
This project has been published by Tobias Brohl under [MIT License](https://raw.githubusercontent.com/TheMinefighter/PropertyOrFieldInfo/master/LICENSE.md).
## Bug Reports
Please report any Bugs  [here](https://github.com/TheMinefighter/PropertyOrFieldInfo/issues), then I can fix them probably within 24h!
## Attribution:
You can find attribution for all libraries used [here](./acknowledgements.html).
## Contribution
Please review [this](https://raw.githubusercontent.com/TheMinefighter/PropertyOrFieldInfo/master/CONTRIBUTING.md) before contributing.
