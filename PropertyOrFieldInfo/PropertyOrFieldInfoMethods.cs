using System;
using System.Reflection;

namespace PropertyOrFieldInfo {
	public partial class PropertyOrFieldInfo {
      /// <summary>
      /// 
      /// </summary>
		public bool CanRead {
			get {
				if (IsField) {
					return ((FieldInfo) MemberInfo).IsPublic;
				}
				else {
					if (!((PropertyInfo) MemberInfo).CanRead) {
						return false;
					}
					else
					{
					   return ((PropertyInfo) MemberInfo).GetGetMethod() != null;
					}
				}
			}
		}

		public bool CanWrite {
			get {
				if (IsField) {
					return ((FieldInfo) MemberInfo).IsPublic;
				}
				else {
					if (!((PropertyInfo) MemberInfo).CanWrite) {
						return false;
					}
					else {
						return ((PropertyInfo) MemberInfo).GetSetMethod() != null;
					}
				}
			}
		}

		public Type GetValueType() {
			if (IsField)
			{
			   return ((FieldInfo) MemberInfo).FieldType;
			}
			else
			{
			   return ((PropertyInfo) MemberInfo).PropertyType;
			}
		}

		public object GetValue(object reference) {
			if (IsField) {
				return ((FieldInfo) MemberInfo).GetValue(reference);
			}
			else {
				return ((PropertyInfo) MemberInfo).GetValue(reference);
			}
		}

		public void SetValue(object reference, object value) {
			if (IsField) {
				((FieldInfo) MemberInfo).SetValue(reference, value);
			}
			else {
				((PropertyInfo) MemberInfo).SetValue(reference, value);
			}
		}

		public override object[] GetCustomAttributes(bool inherit) => MemberInfo.GetCustomAttributes(inherit);
		public override object[] GetCustomAttributes(Type attributeType, bool inherit) => MemberInfo.GetCustomAttributes(attributeType, inherit);
		public override bool IsDefined(Type attributeType, bool inherit) => MemberInfo.IsDefined(attributeType, inherit);
		public override Type DeclaringType => MemberInfo.DeclaringType;
		public override MemberTypes MemberType => MemberInfo.MemberType;
		public override string Name => MemberInfo.Name;
		public override Type ReflectedType => MemberInfo.ReflectedType;
	}
}