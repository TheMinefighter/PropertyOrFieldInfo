using System;
using System.Reflection;

namespace PropertyOrFieldInfo {
	public partial class PropertyOrFieldInfo {
		public PropertyOrFieldInfo(PropertyInfo source) {
			MemberInfo = source;
			//IsField is false by default
		}

		public PropertyOrFieldInfo(FieldInfo source) {
			MemberInfo = source;
			IsField = true;
		}

		public PropertyOrFieldInfo(MemberInfo src) {
			switch (src.MemberType) {
				case MemberTypes.Field:
					IsField = true;
					break;
				case MemberTypes.Property:
					//IsField is false by default
					break;
				default: throw new ArgumentException("Not a PropertyInfo neither a Fieldinfo");
			}

			MemberInfo = src;
		}

		public static explicit operator PropertyInfo(PropertyOrFieldInfo src) {
			if (!src.IsField) {
				return (PropertyInfo) src.MemberInfo;
			}
			else {
				throw new InvalidOperationException("It´s a FieldInfo not a PropertyInfo");
			}
		}

		public static explicit operator FieldInfo(PropertyOrFieldInfo src) {
			if (src.IsField) {
				return (FieldInfo) src.MemberInfo;
			}
			else {
				throw new InvalidOperationException("It´s a PropertyInfo not a Fieldinfo");
			}
		}

		public static explicit operator PropertyOrFieldInfo(FieldInfo src) => new PropertyOrFieldInfo(src);
		public static explicit operator PropertyOrFieldInfo(PropertyInfo src) => new PropertyOrFieldInfo(src);
	}
}