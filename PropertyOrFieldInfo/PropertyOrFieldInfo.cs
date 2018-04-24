using System;
using System.Reflection;
using System.Transactions;

namespace PropertyOrFieldInfo
{
   public partial class PropertyOrFieldInfo : MemberInfo
   {
      public bool IsField { get;  }
      public MemberInfo MemberInfo { get;  }

      private PropertyOrFieldInfo() { }
   }
}