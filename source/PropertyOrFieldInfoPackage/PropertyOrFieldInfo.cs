using System;
using System.Reflection;
using JetBrains.Annotations;

namespace PropertyOrFieldInfoPackage {
/// <summary>
///  Can represent either a field or property, manages all accesses and provides a unified interface
/// </summary>
public partial class PropertyOrFieldInfo : MemberInfo, IEquatable<PropertyOrFieldInfo>, IEquatable<PropertyInfo>,
	IEquatable<FieldInfo> {
	/// <summary>
	///  True if it is a <see cref="FieldInfo" />, otherwise false
	/// </summary>
	[PublicAPI]
	public bool IsField { get; }

	/// <summary>
	///  True if it is a <see cref="PropertyInfo" />, otherwise false
	/// </summary>
	[PublicAPI]
	public bool IsProperty => !IsField;

	/// <summary>
	///  The actual <see cref="System.Reflection.MemberInfo" />
	/// </summary>
	[PublicAPI]
	public MemberInfo MemberInfo { get; }

	/// <inheritdoc />
	/// <summary>
	///  Tests whether a this <see cref="T:PropertyOrFieldInfoPackage.PropertyOrFieldInfo" /> is equal to a
	///  <see cref="T:System.Reflection.FieldInfo" />
	/// </summary>
	/// <param name="other">The <see cref="T:System.Reflection.FieldInfo" /> to compare with</param>
	/// <returns>Whether both are equal</returns>
	[PublicAPI]
	public bool Equals(FieldInfo other) => MemberInfo.Equals(other);

	/// <inheritdoc />
	/// <summary>
	///  Tests whether a this <see cref="T:PropertyOrFieldInfoPackage.PropertyOrFieldInfo" /> is equal to a
	///  <see cref="T:System.Reflection.PropertyInfo" />
	/// </summary>
	/// <param name="other">The <see cref="T:System.Reflection.PropertyInfo" /> to compare with</param>
	/// <returns>Whether both are equal</returns>
	[PublicAPI]
	public bool Equals(PropertyInfo other) => MemberInfo.Equals(other);

	/// <inheritdoc />
	/// <summary>
	///  Test whether two <see cref="T:PropertyOrFieldInfoPackage.PropertyOrFieldInfo" />s are Equal
	/// </summary>
	/// <param name="other">The <see cref="T:PropertyOrFieldInfoPackage.PropertyOrFieldInfo" /> to compare with</param>
	/// <returns>Whether both are equal</returns>
	[PublicAPI]
	public bool Equals(PropertyOrFieldInfo other) => MemberInfo.Equals(other.MemberInfo);

	/// <summary>
	///  Test whether two <see cref="T:PropertyOrFieldInfoPackage.PropertyOrFieldInfo" />s are Equal
	/// </summary>
	/// <param name="other">The <see cref="T:PropertyOrFieldInfoPackage.PropertyOrFieldInfo" /> to compare with</param>
	/// <returns>Whether both are equal</returns>
	[PublicAPI]
	public bool EqualsMemberInfo(MemberInfo other) => MemberInfo.Equals(other);
}
}