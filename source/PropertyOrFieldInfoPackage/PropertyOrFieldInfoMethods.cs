using System;
using System.Reflection;
using JetBrains.Annotations;

namespace PropertyOrFieldInfoPackage {
public partial class PropertyOrFieldInfo {
	/// <summary>
	///  Whether the property/field get be read
	/// </summary>
	[PublicAPI]
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

	/// <summary>
	///  Checks whether the value can be written
	/// </summary>
	[PublicAPI]
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
	[PublicAPI]
	public Type ValueType {
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
	[PublicAPI]
	public object? GetValue(object? toReadFrom) {
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
	/// <param name="value">The value to set the target to</param>
	[PublicAPI]
	public void SetValue(object? target, object? value) {
		if (IsField) {
			((FieldInfo) MemberInfo).SetValue(target, value);
		}
		else {
			((PropertyInfo) MemberInfo).SetValue(target, value);
		}
	}

	/// <summary>
	///  Checks if a field or property is static
	/// </summary>
	/// <returns>True for static false for non static</returns>
	/// <exception cref="InvalidOperationException">If a property is defined without accessors</exception>
	[PublicAPI]
	public bool IsStatic() {
		if (IsField) {
			return ((FieldInfo) MemberInfo).IsStatic;
		}
		else {
			MethodInfo[] accessors = ((PropertyInfo) MemberInfo).GetAccessors(true);
			if (accessors.Length == 0) {
				throw new InvalidOperationException("The property has no accessor");
			}

			return accessors[0].IsStatic;
		}
	}
}
}