using System;

namespace ChoosingBot.Extensions
{
    public static class ReflectionObject
    {
        public static T GenericReflection<T>(string className) where T : class
        {
            try
            {
                string baseNamespace = typeof(T).Namespace;
                Type type = Type.GetType($"{baseNamespace}.{className}");
                T result = (Activator.CreateInstance(type)) as T;
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static T GenericReflectionWithParm<T>(string className, object[] obj) where T : class
        {
            try
            {
                string baseNamespace = typeof(T).Namespace;
                Type type = Type.GetType($"{baseNamespace}.{className}");
                T result = (Activator.CreateInstance(type, obj)) as T;
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}