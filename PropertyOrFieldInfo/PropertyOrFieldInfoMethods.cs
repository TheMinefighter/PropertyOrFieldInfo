using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PropertyOrFieldInfo
{
   public static class PropertyOrFieldInfoMethods
   {
      public static IEnumerable<PropertyOrFieldInfo> DeclaredPropertiesAndFields(this TypeInfo src) => src.DeclaredProperties
         .Select(x => new PropertyOrFieldInfo(x))
         .Concat(src.DeclaredProperties.Select(x => new PropertyOrFieldInfo(x)));
   }
}