using System;
using System.Linq;
using System.Reflection;

namespace Validation_Attributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType
                .GetProperties()
                .Where(pi => pi.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj);

                foreach (CustomAttributeData customAttributeData in property.CustomAttributes)
                {
                    Type customnAttributeType = customAttributeData.AttributeType;
                    object attrbuteInstance = property
                        .GetCustomAttribute(customnAttributeType);

                    MethodInfo validationMethod = customnAttributeType
                        .GetMethods()
                        .First(m => m.Name == "IsValid");
                    bool result = (bool)validationMethod.
                        Invoke(attrbuteInstance, new object[] {propValue});
                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
