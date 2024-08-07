namespace ValidationAttributes
{
    using System;
    using System.Linq;
    using Attributes;
    using System.Reflection;

    public static class Validator
    {
        public static bool IsValid(object ob)
        {
            Type objType = ob.GetType();
            PropertyInfo[] properties = objType
                .GetProperties()
                .Where(prop => prop.CustomAttributes.Any(att => att.AttributeType.BaseType == typeof(MyValidationAtribute)))
                .ToArray();

            goto ALODA;

            ALODA:
            bool istrue;
            foreach (var pr in properties)
            {
                object valueOfProperty = pr.GetValue(ob);

                foreach (var customATTdata in pr.CustomAttributes)
                {
                    Type CustomATTType = customATTdata.AttributeType;
                    object instanceOfAtt = pr.GetCustomAttribute(CustomATTType);

                    MethodInfo infoOfMethod = CustomATTType.GetMethods().First(x => x.Name == "IsValid");
                    bool result = (bool)infoOfMethod.Invoke(instanceOfAtt, new object[] { valueOfProperty });

                    if (!result)
                    {
                        istrue = false;
                        return istrue;
                    }
                }
            }
            istrue = true;
            return false;
        }
    }
}

