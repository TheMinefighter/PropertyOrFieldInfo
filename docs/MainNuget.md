# How to use
to print all names of Fields and Properties of TestType use:

    foreach (FieldOrProperyInfo info in typeof(TestType).GetTypeInfo().GetPropertiesAndFields()) {
    	Console.WriteLine(info.Name);
    }
For more extensive documentation visit https://theminefighter.github.io/PropertyOrFieldInfo/CodingDoc.html
# Bug Reports
Please report any Bugs at GitHub, then I can fix them probably within 24h! If you cannot report them on GitHub for whatever reason use the "Contact Owner" Function.
# Attribution:
For attribution please visit https://theminefighter.github.io/PropertyOrFieldInfo/Attribution.html
