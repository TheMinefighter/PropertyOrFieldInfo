using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using PropertyOrFieldInfoPackage;
using Xunit;

namespace Unittests {
public class PropertyOrFieldInfoTests {
	public PropertyOrFieldInfoTests() {
		TypeInfo typeInfo = typeof(TestClass).GetTypeInfo();
		FieldsAndProperties = typeInfo.GetPropertiesAndFields();
		FieldTest = typeInfo.DeclaredFields.Where(x => !x.IsDefined(typeof(CompilerGeneratedAttribute)))
			.ElementAt(0); //0 is backing field
		PropTest = typeInfo.DeclaredProperties.ElementAt(0);
		TestObject = new TestClass();
		p = (PropertyOrFieldInfo) PropTest;
		f = (PropertyOrFieldInfo) FieldTest;
	}

	public PropertyOrFieldInfo[] FieldsAndProperties;
	public FieldInfo FieldTest;
	public PropertyInfo PropTest;
	public TestClass TestObject;
	public PropertyOrFieldInfo f;
	public PropertyOrFieldInfo p;


	public class TestClass {
		public int Field1;
		public string Prop1 { get; set; }
	}

	[Fact]
	public void Conversions1() {
		Assert.True(p.Equals(PropTest));
		Assert.True(f.Equals(FieldTest));
	}

	[Fact]
	public void Conversions2() {
		Assert.True(((FieldInfo) f).Equals(FieldTest));
		Assert.True(((PropertyInfo) p).Equals(PropTest));
	}

	[Fact]
	public void Conversions3() {
		Assert.True(((FieldInfo) FieldsAndProperties[1]).Equals(FieldTest));
		Assert.True(((PropertyInfo) FieldsAndProperties[0]).Equals(PropTest));
	}

	[Fact]
	public void ExtensionTest1() {
		Assert.True(FieldsAndProperties.Count() == 2);
	}

	[Fact]
	public void ExtensionTest2() {
		Assert.Contains(FieldsAndProperties.Select(x => x.MemberInfo), x => x.Equals(PropTest));
		Assert.Contains(FieldsAndProperties.Select(x => x.MemberInfo), x => x.Equals(FieldTest));
	}

	[Fact]
	public void GetMethod() {
		TestObject.Field1 = 11;
		TestObject.Prop1 = "ThisIsAnotherTest";

		Assert.True((int) ((PropertyOrFieldInfo) FieldTest).GetValue(TestObject) == 11);
		Assert.True((string) ((PropertyOrFieldInfo) PropTest).GetValue(TestObject) == "ThisIsAnotherTest");
	}

	[Fact]
	public void MemberSpecificEqualityTest() {
		Assert.Contains(FieldsAndProperties, x => x.EqualsMemberInfo(PropTest));
		Assert.Contains(FieldsAndProperties, x => x.EqualsMemberInfo(FieldTest));
	}

	[Fact]
	public void NameMethod() {
		Assert.Contains(FieldsAndProperties.Select(x => x.Name), x => x == nameof(TestClass.Prop1));
		Assert.Contains(FieldsAndProperties.Select(x => x.Name), x => x == nameof(TestClass.Field1));
	}

	[Fact]
	public void SetMethod() {
		((PropertyOrFieldInfo) FieldTest).SetValue(TestObject, 10);
		((PropertyOrFieldInfo) PropTest).SetValue(TestObject, "ThisIsATest");
		Assert.True(TestObject.Field1 == 10);
		Assert.True(TestObject.Prop1 == "ThisIsATest");
	}

	[Fact]
	public void SpecificConstructors() {
		Assert.True(new PropertyOrFieldInfo(PropTest).Equals(PropTest));
		Assert.True(new PropertyOrFieldInfo(FieldTest).Equals(FieldTest));
	}

	[Fact]
	public void SpecificEqualityTest() {
		Assert.Contains(FieldsAndProperties, x => x.Equals(PropTest));
		Assert.Contains(FieldsAndProperties, x => x.Equals(FieldTest));
	}

	[Fact]
	public void TestMemberInfoMethods() {
		FieldsAndProperties[0].GetCustomAttribute<UsedImplicitlyAttribute>();
	}

	[Fact]
	public void ValueType() {
		Assert.True(((PropertyOrFieldInfo) FieldTest).ValueType == typeof(int));
		Assert.True(((PropertyOrFieldInfo) PropTest).ValueType == typeof(string));
	}
}
}