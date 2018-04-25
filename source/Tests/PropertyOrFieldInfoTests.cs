using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PropertyOrFieldInfoPackage;
using Xunit;

namespace Tests {
	public class PropertyOrFieldInfoTests {
		public PropertyOrFieldInfoTests() {
			TypeInfo typeInfo = typeof(TestClass).GetTypeInfo();
			FieldsAndProperties = typeInfo.DeclaredPropertiesAndFields();
			FieldTest = typeInfo.DeclaredFields.ElementAt(0);
			PropTest = typeInfo.DeclaredProperties.ElementAt(0);
		}

		public IEnumerable<PropertyOrFieldInfo> FieldsAndProperties;
		public FieldInfo FieldTest;
		public PropertyInfo PropTest;

		public void MemberSpecificEqualityTest() {
			Assert.True(FieldsAndProperties.Any(x => x.Equals(PropTest as MemberInfo)));
			Assert.True(FieldsAndProperties.Any(x => x.Equals(FieldTest)));
		}

		private class TestClass {
			public int Field1;
			public string Prop1 { get; set; }
		}

		[Fact]
		public void ExtensionTest1() {
			Assert.True(FieldsAndProperties.Count() == 2);
		}

		[Fact]
		public void ExtensionTest2() {
			Assert.True(FieldsAndProperties.Select(x => x.MemberInfo).Any(x => x.Equals(PropTest)));
			Assert.True(FieldsAndProperties.Select(x => x.MemberInfo).Any(x => x.Equals(FieldTest)));
		}

		[Fact]
		public void SpecificEqualityTest() {
			Assert.True(FieldsAndProperties.Any(x => x.Equals(PropTest)));
			Assert.True(FieldsAndProperties.Any(x => x.Equals(FieldTest)));
		}
	}
}