using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PropertyOrFieldInfoPackage {
	public static class PropertyOrFieldInfoExtensions {
	   /// <summary>
	   ///  Loads all <see cref="DeclaredPropertiesAndFields" /> from a given <see cref="TypeInfo" />
	   /// </summary>
	   /// <param name="source">The TypeInfo to load the <see cref="DeclaredPropertiesAndFields" /> from</param>
	   /// <returns>An <see cref="IEnumerable{PropertyOrFieldInfo}" /> containing all Properties and Fields of the Type</returns>
	   public static IEnumerable<PropertyOrFieldInfo> DeclaredPropertiesAndFields(this TypeInfo source) {
			return source.DeclaredProperties
				.Select(x => new PropertyOrFieldInfo(x))
				.Concat(source.DeclaredProperties.Select(x => new PropertyOrFieldInfo(x)));
		}
	}
}