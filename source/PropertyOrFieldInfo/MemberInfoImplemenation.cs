using System;
using System.Reflection;

namespace PropertyOrFieldInfo
{
   public partial class PropertyOrFieldInfo
   {
      // All XML Comments in this class are based upon those from the dotnet-api-docs (available at https://github.com/dotnet/dotnet-api-docs/ ) to bes sepcific the ones in https://github.com/dotnet/dotnet-api-docs/blob/master/xml/System.Reflection/MemberInfo.xml ,
      // which are Licensed by the Microsoft Corporation under MIT License (see https://github.com/dotnet/dotnet-api-docs/blob/master/LICENSE-CODE)
      // I wouldn´t consider this as a substantial by any means part but one Attribution to much is better than one copyright lawsuit against Microsoft
      /// <summary>Returns an array of all custom attributes applied to this member.</summary>
      /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events.</param>
      /// <returns>An array that contains all the custom attributes applied to this member, or an array with zero elements if no attributes are defined.</returns>
      /// <exception cref="T:System.InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context. See <see cref="~/docs/framework/reflection-and-codedom/how-to-load-assemblies-into-the-reflection-only-context.md">How to: Load Assemblies into the Reflection-Only Context</see>.</exception>
      /// <exception cref="T:System.TypeLoadException">A custom attribute type could not be loaded.</exception>
      public override object[] GetCustomAttributes(bool inherit) => MemberInfo.GetCustomAttributes(inherit);

      /// <summary>Returns an array of custom attributes applied to this member and identified by <see cref="T:System.Type"></see>.</summary>
      /// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
      /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events.</param>
      /// <returns>An array of custom attributes applied to this member, or an array with zero elements if no attributes assignable to <paramref name="attributeType">attributeType</paramref> have been applied.</returns>
      /// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
      /// <exception cref="T:System.ArgumentNullException">If <paramref name="attributeType">attributeType</paramref> is null.</exception>
      /// <exception cref="T:System.InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context. See <see cref="~/docs/framework/reflection-and-codedom/how-to-load-assemblies-into-the-reflection-only-context.md">How to: Load Assemblies into the Reflection-Only Context</see>.</exception>
      public override object[] GetCustomAttributes(Type attributeType, bool inherit) =>
         MemberInfo.GetCustomAttributes(attributeType, inherit);
      /// <summary>Indicates whether one or more attributes of the specified type or of its derived types is applied to this member.</summary>
      /// <param name="attributeType">The type of custom attribute to search for. The search includes derived types.</param>
      /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events.</param>
      /// <returns>true if one or more instances of <paramref name="attributeType">attributeType</paramref> or any of its derived types is applied to this member; otherwise, false.</returns>
      public override bool IsDefined(Type attributeType, bool inherit) => MemberInfo.IsDefined(attributeType, inherit);
      /// <summary>Gets the class that declares this member.</summary>
      /// <returns>The Type object for the class that declares this member.</returns>
      public override Type DeclaringType => MemberInfo.DeclaringType;
      /// <summary>Gets a <see cref="T:System.Reflection.MemberTypes"></see> value indicating the type of the member — method, constructor, event, and so on.</summary>
      /// <returns>A <see cref="T:System.Reflection.MemberTypes"></see> value indicating the type of member.</returns>
      public override MemberTypes MemberType => MemberInfo.MemberType;
      public override string Name => MemberInfo.Name;
      public override Type ReflectedType => MemberInfo.ReflectedType;
   }
}