using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using PropertyOrFieldInfoPackage;
using Xunit;

namespace Tests {
	public class PropertyOrFieldInfoTests {
		public PropertyOrFieldInfoTests() {
			TypeInfo typeInfo = typeof(TestClass).GetTypeInfo();
			FieldsAndProperties = typeInfo.DeclaredPropertiesAndFields();
			FieldTest = typeInfo.DeclaredFields.Where(x=>!x.IsDefined(typeof(CompilerGeneratedAttribute))).ElementAt(0); //0 is backing field
			PropTest = typeInfo.DeclaredProperties.ElementAt(0);
			TestObject = new TestClass();
		}

		public IEnumerable<PropertyOrFieldInfo> FieldsAndProperties;
		public FieldInfo FieldTest;
		public PropertyInfo PropTest;
		public TestClass TestObject;


		public class TestClass {
			public int Field1;
			public string Prop1 { get; set; }
		}

		[Fact]
		public void Constructors() {
			MemberInfo propertyInfo = PropTest;
			MemberInfo fieldInfo = FieldTest;

			Assert.True(new PropertyOrFieldInfo(propertyInfo).Equals(PropTest));
			Assert.True(new PropertyOrFieldInfo(fieldInfo).Equals(FieldTest));
		}

		[Fact]
		public void Conversions() {
			Assert.True(((PropertyInfo) (PropertyOrFieldInfo) PropTest).Equals(PropTest));
			Assert.True(((FieldInfo) (PropertyOrFieldInfo) FieldTest).Equals(FieldTest));
		}

		[Fact]
		public void ExtensionTest1() {
			Assert.True(FieldsAndProperties.Count() == 2);
		}

		[Fact]
		public void ExtensionTest2() {
			Assert.True(FieldsAndProperties.Select(x => x.MemberInfo).Any(x => x.Equals(PropTest)));
			Assert.True(FieldsAndProperties.Select(x => x.MemberInfo).Any( x => x.Equals(FieldTest)));
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
			Assert.True(FieldsAndProperties.Select(x => x.Name).Any(x=>x==nameof(TestClass.Prop1)));
			Assert.True(FieldsAndProperties.Select(x => x.Name).Any(x=>x==nameof(TestClass.Field1)));
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
			Assert.True(FieldsAndProperties.Any(x => x.Equals(PropTest)));
			Assert.True(FieldsAndProperties.Any(x => x.Equals(FieldTest)) );
		}

		[Fact]
		public void ValueType() {
			Assert.True(((PropertyOrFieldInfo) FieldTest).ValueType == typeof(int));
			Assert.True(((PropertyOrFieldInfo) PropTest).ValueType == typeof(string));
		}
	}
}