using System;
using System.Reflection;

namespace PropertyOrFieldInfo {
	public partial class PropertyOrFieldInfo {
      /// <summary>
      /// Creates a new <see cref="PropertyOrFieldInfo"/> from a <see cref="PropertyInfo"/>
      /// </summary>
      /// <param name="source">The <see cref="PropertyInfo"/> to use</param>
      public PropertyOrFieldInfo(PropertyInfo source) {
			MemberInfo = source;
			//IsField is false by default
		}
      /// <summary>
      /// Creates a new <see cref="PropertyOrFieldInfo"/> from a <see cref="FieldInfo"/>
      /// </summary>
      /// <param name="source">The <see cref="FieldInfo"/> to use</param>
		public PropertyOrFieldInfo(FieldInfo source) {
			MemberInfo = source;
			IsField = true;
		}
      /// <summary>
      /// Creates a new <see cref="PropertyOrFieldInfo"/> from a <see cref="System.Reflection.MemberInfo"/>
      /// </summary>
      /// <param name="source">The MemberInfo to use</param>
      /// <exception cref="ArgumentException">Thrown when the MemberInfo is not a <see cref="PropertyInfo"/> neither a <see cref="FieldInfo"/></exception>  
      public PropertyOrFieldInfo(MemberInfo source) {
			switch (source.MemberType) {
				case MemberTypes.Field:
					IsField = true;
					break;
				case MemberTypes.Property:
					//IsField is false by default
					break;
				default: throw new ArgumentException("Not a PropertyInfo neither a FieldInfo",nameof(source));
			} 	

			MemberInfo = source;
		}
      /// <summary>
      /// Convertes a <see cref="PropertyOrFieldInfo"/> to a <see cref="PropertyInfo"/> if possible, throws otherwise
      /// </summary>
      /// <param name="source">The <see cref="PropertyOrFieldInfo"/> to convert</param>
      /// <exception cref="InvalidOperationException">Thrown when it is a <see cref="FieldInfo"/> instead of the requested <see cref="PropertyInfo"/></exception>
		public static explicit operator PropertyInfo(PropertyOrFieldInfo source) {
			if (!source.IsField) {
				return (PropertyInfo) source.MemberInfo;
			}
			else {
				throw new InvalidOperationException("It´s a FieldInfo not a PropertyInfo");
			}
		}
      /// <summary>
      /// Convertes a <see cref="PropertyOrFieldInfo"/> to a <see cref="FieldInfo"/> if possible, throws otherwise
      /// </summary>
      /// <param name="source">The <see cref="PropertyOrFieldInfo"/> to convert</param>
      /// <exception cref="InvalidOperationException">Thrown when it is a <see cref="PropertyInfo"/> instead of the requested <see cref="FieldInfo"/></exception>
      public static explicit operator FieldInfo(PropertyOrFieldInfo source) {
			if (source.IsField) {
				return (FieldInfo) source.MemberInfo;
			}
			else {
				throw new InvalidOperationException("It´s a PropertyInfo not a FieldInfo");
			}
		}
	   /// <summary>
	   /// Convertes a <see cref="FieldInfo"/> to a <see cref="PropertyOrFieldInfo"/>
	   /// </summary>
	   /// <param name="source">The <see cref="FieldInfo"/> to convert</param>
      public static explicit operator PropertyOrFieldInfo(FieldInfo source) => new PropertyOrFieldInfo(source);
      /// <summary>
      /// Convertes a <see cref="PropertyInfo"/> to a <see cref="PropertyOrFieldInfo"/>
      /// </summary>
      /// <param name="source">The <see cref="PropertyInfo"/> to convert</param>
      public static explicit operator PropertyOrFieldInfo(PropertyInfo source) => new PropertyOrFieldInfo(source);
	}
}