using System;
using System.Reflection;
using JetBrains.Annotations;

namespace PropertyOrFieldInfoPackage {
public partial class PropertyOrFieldInfo {
	/// <summary>
	///  Creates a new <see cref="T:PropertyOrFieldInfoPackage.PropertyOrFieldInfo" /> from a <see cref="T:System.Reflection.PropertyInfo" />
	/// </summary>
	/// <param name="source">The <see cref="T:System.Reflection.PropertyInfo" /> to use</param>
	[PublicAPI]
	public PropertyOrFieldInfo(PropertyInfo source) => MemberInfo = source;

	/// <summary>
	///  Creates a new <see cref="T:PropertyOrFieldInfoPackage.PropertyOrFieldInfo" /> from a <see cref="T:System.Reflection.FieldInfo" />
	/// </summary>
	/// <param name="source">The <see cref="T:System.Reflection.FieldInfo" /> to use</param>
	/// 
	[PublicAPI]
	public PropertyOrFieldInfo(FieldInfo source) {
		MemberInfo = source;
		IsField = true;
	}

	/// <summary>
	///  Creates a new <see cref="T:PropertyOrFieldInfoPackage.PropertyOrFieldInfo" /> from a <see cref="T:System.Reflection.MemberInfo" />
	/// </summary>
	/// <param name="source">The MemberInfo to use</param>
	/// <exception cref="T:System.ArgumentException">
	///  Thrown when the MemberInfo is not a <see cref="T:System.Reflection.PropertyInfo" /> neither a <see cref="T:System.Reflection.FieldInfo" />
	/// </exception>
	[PublicAPI]
	public PropertyOrFieldInfo(MemberInfo source) {
		switch (source.MemberType) {
			case MemberTypes.Field:
				IsField = true;
				break;
			case MemberTypes.Property:
				//IsField is false by default
				break;
			default: throw new ArgumentException("Neither a PropertyInfo nor a FieldInfo", nameof(source));
		}

		MemberInfo = source;
	}

	/// <summary>
	///  Converts a <see cref="PropertyOrFieldInfoPackage.PropertyOrFieldInfo" /> to a <see cref="PropertyInfo" /> if possible, throws otherwise
	/// </summary>
	/// <param name="source">The <see cref="PropertyOrFieldInfoPackage.PropertyOrFieldInfo" /> to convert</param>
	/// <exception cref="InvalidOperationException">
	///  Thrown when it is a <see cref="FieldInfo" /> instead of the requested
	///  <see cref="PropertyInfo" />
	/// </exception>
	[PublicAPI]
	public static explicit operator PropertyInfo(PropertyOrFieldInfo source) {
		if (!source.IsField) {
			return (PropertyInfo) source.MemberInfo;
		}
		else {
			throw new InvalidOperationException("It´s a FieldInfo not a PropertyInfo");
		}
	}

	/// <summary>
	///  Converts a <see cref="PropertyOrFieldInfoPackage.PropertyOrFieldInfo" /> to a <see cref="FieldInfo" /> if possible, throws otherwise
	/// </summary>
	/// <param name="source">The <see cref="PropertyOrFieldInfoPackage.PropertyOrFieldInfo" /> to convert</param>
	/// <exception cref="InvalidOperationException">
	///  Thrown when it is a <see cref="PropertyInfo" /> instead of the requested
	///  <see cref="FieldInfo" />
	/// </exception>
	[PublicAPI]
	public static explicit operator FieldInfo(PropertyOrFieldInfo source) {
		if (source.IsField) {
			return (FieldInfo) source.MemberInfo;
		}
		else {
			throw new InvalidOperationException("It´s a PropertyInfo not a FieldInfo");
		}
	}

	/// <summary>
	///  Converts a <see cref="FieldInfo" /> to a <see cref="PropertyOrFieldInfoPackage.PropertyOrFieldInfo" />
	/// </summary>
	/// <param name="source">The <see cref="FieldInfo" /> to convert</param>
	//[Obsolete("Use a new Expression instead, forbidden by C#")]
	[PublicAPI]
	public static explicit operator PropertyOrFieldInfo(FieldInfo source) => new PropertyOrFieldInfo(source);

	/// <summary>
	///  Converts a <see cref="PropertyInfo" /> to a <see cref="PropertyOrFieldInfoPackage.PropertyOrFieldInfo" />
	/// </summary>
	/// <param name="source">The <see cref="PropertyInfo" /> to convert</param>
	//[Obsolete("Use a new Expression instead, forbidden by C#")]
	[PublicAPI]
	public static explicit operator PropertyOrFieldInfo(PropertyInfo source) => new PropertyOrFieldInfo(source);

//		public static explicit operator PropertyOrFieldInfo(RuntimePropertyInfo source) => null;
}
}