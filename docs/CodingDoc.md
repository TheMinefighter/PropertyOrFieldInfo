Obtaining a IEnumerable<PropertyOrFieldInfo> from a given type:

```
TypeInfo myTypeInfo=typeof(MyType).GetTypeInfo();
IEnumerable<PropertyOrFieldInfo> PropertiesAndFields=myTypeInfo.GetPropertiesAndFields();
```

Now you can Iterate through that IEnumerable:
```
foreach (PropertyOrFieldInfo info in PropertiesAndFields) {
//Do something
}
```
But what can I do with that?
Get it´s name:
```
Console.WriteLine(info.Name);
```
Test if it´s readable: 
```
if (info.CanRead) {
	Console.WriteLine("I can read this!");
```
If that's the case and it is static read it´s value
```
	if (info.IsStatic) {
		Console.WriteLine("It is static and it´s value is "+ 
		info.GetValue(
		//For NonStatics insert the reference here
		null));
	}
}
```

Furthermore there are the `TypeInfo.GetRuntimePropertiesAndFields` and `TypeInfo.DeclaredPropertiesAndFields` based on the corresponding standard properties/methods.