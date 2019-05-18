using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace PropertyOrFieldInfoPackage {
/// <summary>
///  Provides Extensions supporting the <see cref="PropertyOrFieldInfo" /> class
/// </summary>
[PublicAPI]
public static class PropertyOrFieldInfoExtensions {
	/// <summary>
	///  Loads all declared <see cref="PropertyOrFieldInfo" />s from a given <see cref="TypeInfo" />
	/// </summary>
	/// <param name="source">The TypeInfo to load the <see cref="PropertyOrFieldInfo" />s from</param>
	/// <returns>An <see cref="IEnumerable{PropertyOrFieldInfo}" /> containing all Properties and Fields of the Type</returns>
	[PublicAPI]
	public static IEnumerable<PropertyOrFieldInfo> DeclaredPropertiesAndFields(this TypeInfo source) => source
		.DeclaredProperties.Select(x => new PropertyOrFieldInfo(x))
		.Concat(source.DeclaredFields.Select(x => new PropertyOrFieldInfo(x)));

	/// <summary>
	///  Loads all runtime <see cref="PropertyOrFieldInfo" />s from a given <see cref="TypeInfo" />
	/// </summary>
	/// <param name="source">The TypeInfo to load the <see cref="PropertyOrFieldInfo" />s from</param>
	/// <returns>An <see cref="IEnumerable{PropertyOrFieldInfo}" /> containing all Properties and Fields of the Type</returns>
	[PublicAPI]
	public static IEnumerable<PropertyOrFieldInfo> GetRuntimePropertiesAndFields(this TypeInfo source) => source
		.GetRuntimeProperties().Select(x => new PropertyOrFieldInfo(x))
		.Concat(source.GetRuntimeFields().Select(x => new PropertyOrFieldInfo(x)));

	/// <summary>
	///  Loads all <see cref="PropertyOrFieldInfo" />s from a given <see cref="TypeInfo" />
	/// </summary>
	/// <param name="source">The TypeInfo to load the <see cref="PropertyOrFieldInfo" />s from</param>
	/// <param name="flags">Flags to check for</param>
	/// <returns>An <see cref="IEnumerable{PropertyOrFieldInfo}" /> containing all Properties and Fields of the Type</returns>
	[PublicAPI]
	public static IEnumerable<PropertyOrFieldInfo> GetPropertiesAndFields(this TypeInfo source, BindingFlags flags) {
		return source.GetProperties(flags)
			.Select(x => new PropertyOrFieldInfo(x))
			.Concat(source.GetFields(flags)
				.Select(x => new PropertyOrFieldInfo(x)));
	}
}
}