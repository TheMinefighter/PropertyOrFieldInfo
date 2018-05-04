using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PropertyOrFieldInfoPackage {
	public static class PropertyOrFieldInfoExtensions {
		/// <summary>
		///  Loads all <see cref="PropertyOrFieldInfo" />s from a given <see cref="TypeInfo" />
		/// </summary>
		/// <param name="source">The TypeInfo to load the <see cref="PropertyOrFieldInfo" />s from</param>
		/// <param name="includeCompilerGeneratedFields">Whether to include compiler generated field, like backing ones</param>
		/// <param name="includeParents">Whther to include fields and properties from parent classes</param>
		/// <returns>An <see cref="IEnumerable{PropertyOrFieldInfo}" /> containing all Properties and Fields of the Type</returns>
		public static IEnumerable<PropertyOrFieldInfo> DeclaredPropertiesAndFields(this TypeInfo source,
			bool includeCompilerGeneratedFields = false, bool includeParents = false) {
			if (includeParents) {
				return source.GetRuntimeProperties()
					.Select(x => new PropertyOrFieldInfo(x))
					.Concat(source.DeclaredFields.Where(x => includeCompilerGeneratedFields || !x.IsDefined(typeof(CompilerGeneratedAttribute), false))
						.Select(x => new PropertyOrFieldInfo(x)));
			}
			else {
				return source.DeclaredProperties
					.Select(x => new PropertyOrFieldInfo(x))
					.Concat(source.DeclaredFields.Where(x => includeCompilerGeneratedFields || !x.IsDefined(typeof(CompilerGeneratedAttribute), false))
						.Select(x => new PropertyOrFieldInfo(x)));
			}
		}

		/// <summary>
		///  Loads all <see cref="PropertyOrFieldInfo" />s from a given <see cref="TypeInfo" />
		/// </summary>
		/// <param name="source">The TypeInfo to load the <see cref="PropertyOrFieldInfo" />s from</param>
		/// <param name="flags">Flags to check for</param>
		/// <param name="includeCompilerGeneratedFields">Whether to include compiler generated field, like backing ones</param>
		/// <returns>An <see cref="IEnumerable{PropertyOrFieldInfo}" /> containing all Properties and Fields of the Type</returns>
		public static IEnumerable<PropertyOrFieldInfo> DeclaredPropertiesAndFields(this TypeInfo source, BindingFlags flags,
			bool includeCompilerGeneratedFields = false) {
			return source.GetProperties(flags)
				.Select(x => new PropertyOrFieldInfo(x))
				.Concat(source.GetFields(flags).Where(x => includeCompilerGeneratedFields || !x.IsDefined(typeof(CompilerGeneratedAttribute), false))
					.Select(x => new PropertyOrFieldInfo(x)));
		}
	}
}