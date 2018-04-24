using System;
using System.Reflection;
using System.Transactions;

namespace PropertyOrFieldInfo
{
   public partial class PropertyOrFieldInfo : MemberInfo, IEquatable<PropertyOrFieldInfo>, IEquatable<PropertyInfo>, IEquatable<FieldInfo>
   {
      /// <summary>
      /// True if it is a <see cref="FieldInfo"/>, false if it is a <see cref="PropertyInfo"/>
      /// </summary>
      public bool IsField { get;  }
      /// <summary>
      /// The actual <see cref="System.Reflection.MemberInfo"/>
      /// </summary>
      public MemberInfo MemberInfo { get;  }

      private PropertyOrFieldInfo() { }
      /// <inheritdoc />
      /// <summary>
      /// Tesst whether two <see cref="T:PropertyOrFieldInfo.PropertyOrFieldInfo" />s are Equal
      /// </summary>
      /// <param name="other">The <see cref="T:PropertyOrFieldInfo.PropertyOrFieldInfo" /> to compare with</param>
      /// <returns>Whether both are equal</returns>
      public bool Equals(PropertyOrFieldInfo other)
      {
         return MemberInfo.Equals(other.MemberInfo);
      }
      /// <inheritdoc />
      /// <summary>
      /// Tests whether a this <see cref="T:PropertyOrFieldInfo.PropertyOrFieldInfo" /> is equal to a <see cref="T:System.Reflection.PropertyInfo" />
      /// </summary>
      /// <param name="other">The <see cref="T:System.Reflection.PropertyInfo" /> to compare with</param>
      /// <returns>Whether both are equal</returns>
      public bool Equals(PropertyInfo other)
      {
         return MemberInfo.Equals(other);
      }

      /// <inheritdoc />
      /// <summary>
      /// Tests whether a this <see cref="T:PropertyOrFieldInfo.PropertyOrFieldInfo" /> is equal to a <see cref="T:System.Reflection.FieldInfo" />
      /// </summary>
      /// <param name="other">The <see cref="T:System.Reflection.FieldInfo" /> to compare with</param>
      /// <returns>Whether both are equal</returns>
      public bool Equals(FieldInfo other)
      {
         return MemberInfo.Equals(other);
      }
   }
}