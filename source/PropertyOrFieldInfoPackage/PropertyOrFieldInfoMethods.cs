using System;
using System.Reflection;

namespace PropertyOrFieldInfoPackage {
	public partial class PropertyOrFieldInfo {
		/// <summary>
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
					else {
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

		/// <summary>
		///  Gets the Datatype stored  inside the Field or Property
		/// </summary>
		/// <returns> The <see cref="Type" /> stored inside the field or property</returns>
		public Type GetValueType {
			get {
				if (IsField) {
					return ((FieldInfo) MemberInfo).FieldType;
				}
				else {
					return ((PropertyInfo) MemberInfo).PropertyType;
				}
			}
		}

		/// <summary>
		///  Reads the value of a field or property of a certain object or statics
		/// </summary>
		/// <param name="toReadFrom">The object to Read the data from, use null if the property or field is static</param>
		/// <returns>The value of the field or property for the specified object</returns>
		public object GetValue(object toReadFrom) {
			if (IsField) {
				return ((FieldInfo) MemberInfo).GetValue(toReadFrom);
			}
			else {
				return ((PropertyInfo) MemberInfo).GetValue(toReadFrom);
			}
		}

		/// <summary>
		///  Writes a value to a field or property of a certain object or statics
		/// </summary>
		/// <param name="target">The object to Read the data from, use null if the property or field is static</param>
		/// <param name="value"></param>
		/// <returns>The value of the field or property for the specified object</returns>
		public void SetValue(object target, object value) {
			if (IsField) {
				((FieldInfo) MemberInfo).SetValue(target, value);
			}
			else {
				((PropertyInfo) MemberInfo).SetValue(target, value);
			}
		}
	}
}