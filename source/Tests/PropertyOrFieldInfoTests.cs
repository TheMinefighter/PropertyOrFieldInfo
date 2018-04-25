using System;
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
			FieldTest = typeInfo.DeclaredFields.ElementAt(1);//0 is backing field
			PropTest = typeInfo.DeclaredProperties.ElementAt(0); 
			TestObject=new TestClass();
		}

		public IEnumerable<PropertyOrFieldInfo> FieldsAndProperties;
		public FieldInfo FieldTest;
		public PropertyInfo PropTest;
		public TestClass TestObject;


		public class TestClass {
			public string Prop1 { get; set; }
			public int Field1;
			
			
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

		[Fact]
		public void MemberSpecificEqualityTest() {
			Assert.True(FieldsAndProperties.Any(x => x.EqualsMemberInfo(PropTest)));
			Assert.True(FieldsAndProperties.Any(x => x.EqualsMemberInfo(FieldTest)));
		}
		[Fact]
		public void NameMethod() {
			Assert.True(FieldsAndProperties.Select(x=>x.Name).Contains(nameof(TestClass.Prop1)));
			Assert.True(FieldsAndProperties.Select(x=>x.Name).Contains(nameof(TestClass.Field1)));
		}
		[Fact]
		public void SetMethod() {
			((PropertyOrFieldInfo) FieldTest).SetValue(TestObject,10);
			((PropertyOrFieldInfo) PropTest).SetValue(TestObject,"ThisIsATest");
			Assert.True(TestObject.Field1==10);
			Assert.True(TestObject.Prop1=="ThisIsATest");
		}
		[Fact]
		public void GetMethod() {
			TestObject.Field1 = 11;
			TestObject.Prop1 = "ThisIsAnotherTest";

			Assert.True((int) ((PropertyOrFieldInfo) FieldTest).GetValue(TestObject)==11);
			Assert.True((string) ((PropertyOrFieldInfo) PropTest).GetValue(TestObject)=="ThisIsAnotherTest");
		}

		[Fact]
		public void ValueType() {
			Assert.True(((PropertyOrFieldInfo) FieldTest).ValueType==typeof(int));
			Assert.True(((PropertyOrFieldInfo) PropTest).ValueType==typeof(string));
		}
		
	}
}