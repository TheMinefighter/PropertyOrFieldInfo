using System;
using System.Collections.Generic;
using System.Reflection;

namespace PropertyOrFieldInfoPackage {
public partial class PropertyOrFieldInfo {
	/// <inheritdoc />
	public override Type DeclaringType => MemberInfo.DeclaringType;

	/// <inheritdoc />
	public override MemberTypes MemberType => MemberTypes.Custom;

	/// <inheritdoc />
	public override string Name => MemberInfo.Name;

	/// <inheritdoc />
	public override Type ReflectedType => MemberInfo.ReflectedType;

	/// <inheritdoc />
	public override Module Module => MemberInfo.Module;

	/// <inheritdoc />
	public override int MetadataToken => MemberInfo.MetadataToken;

	/// <inheritdoc />
	public override IEnumerable<CustomAttributeData> CustomAttributes => MemberInfo.CustomAttributes;

	/// <inheritdoc />
	public override object[] GetCustomAttributes(bool inherit) => MemberInfo.GetCustomAttributes(inherit);

	/// <inheritdoc />
	public override object[] GetCustomAttributes(Type attributeType, bool inherit) =>
		MemberInfo.GetCustomAttributes(attributeType, inherit);

	/// <inheritdoc />
	public override bool IsDefined(Type attributeType, bool inherit) => MemberInfo.IsDefined(attributeType, inherit);

	/// <inheritdoc />
	public override IList<CustomAttributeData> GetCustomAttributesData() => MemberInfo.GetCustomAttributesData();
}
}