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
      public bool Equals(PropertyOrFieldInfo other)
      {
         return MemberInfo.Equals(other.MemberInfo);
      }

      public bool Equals(PropertyInfo other)
      {
         return MemberInfo.Equals(other);
      }

      public bool Equals(FieldInfo other)
      {
         return MemberInfo.Equals(other);
      }
   }
}