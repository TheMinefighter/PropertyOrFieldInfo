using System;
using System.Reflection;

namespace PropertyOrFieldInfo
{
   public class PropertyOrFieldInfo : MemberInfo
   {
      private readonly FieldInfo _fieldInfo;
      private readonly PropertyInfo _propertyInfo;
      private readonly bool field;
      private readonly MemberInfo _memberInfo;

      private PropertyOrFieldInfo() { }

      public PropertyOrFieldInfo(PropertyInfo source)
      {
         _propertyInfo = source;
         _memberInfo = source;
      }

      public PropertyOrFieldInfo(FieldInfo source)
      {
         _fieldInfo = source;
         _memberInfo = source;
         field = true;
      }

      public Type GetType()
      {
         if (field)
         {
            return _fieldInfo.GetType();
         }
         else
         {
            return _propertyInfo.GetType();
         }
      }

      public object GetValue(object reference)
      {
         if (field)
         {
            return _fieldInfo.GetValue(reference);
         }
         else
         {
            return _propertyInfo.GetValue(reference);
         }
      }

      public void SetValue(object reference, object value)
      {
         if (field)
         {
            _fieldInfo.SetValue(reference, value);
         }
         else
         {
            _propertyInfo.SetValue(reference, value);
         }
      }



      public static explicit operator PropertyInfo(PropertyOrFieldInfo src)
      {
         if (!src.field)
         {
            return src._propertyInfo;
         }
         else
         {
            throw new InvalidOperationException("It´s a Fieldinfo");
         }
      }

      public static explicit operator FieldInfo(PropertyOrFieldInfo src)
      {
         if (src.field)
         {
            return src._fieldInfo;
         }
         else
         {
            throw new InvalidOperationException("It´s a PropertyInfo");
         }
      }

      public static explicit operator PropertyOrFieldInfo(FieldInfo src) => new PropertyOrFieldInfo(src);
      public static explicit operator PropertyOrFieldInfo(PropertyInfo src) => new PropertyOrFieldInfo(src);
      public override object[] GetCustomAttributes(bool inherit) => _memberInfo.GetCustomAttributes(inherit);

      public override object[] GetCustomAttributes(Type attributeType, bool inherit) => _memberInfo.GetCustomAttributes(attributeType, inherit);

      public override bool IsDefined(Type attributeType, bool inherit) => _memberInfo.IsDefined(attributeType, inherit);

      public override Type DeclaringType => _memberInfo.DeclaringType;

      public override MemberTypes MemberType => _memberInfo.MemberType;

      public override string Name => _memberInfo.Name;

      public override Type ReflectedType => _memberInfo.ReflectedType;


      public bool CanRead
      {
         get
         {
            if (field)
            {
               return _fieldInfo.IsPublic;

            }
            else
            {
               if (!_propertyInfo.CanRead)
               {
                  return false;
               }
               else
               {
                  return _propertyInfo.GetGetMethod().IsPublic;
               }
            }
         }
      }
      public bool CanWrite
      {
         get
         {
            if (field)
            {
               return _fieldInfo.IsPublic;

            }
            else
            {
               if (!_propertyInfo.CanWrite)
               {
                  return false;
               }
               else
               {
                  return _propertyInfo.GetSetMethod().IsPublic;
               }
            }
         }
      }
   }
}