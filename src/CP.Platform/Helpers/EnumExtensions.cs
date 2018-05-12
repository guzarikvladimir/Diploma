using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace CP.Platform.Helpers
{
    public static class EnumExtensions
    {
        public static List<T> GetValues<T>()
        {
            return typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(fi => (T) Enum.Parse(typeof(T), fi.Name, false))
                .ToList();
        }

        public static T Parse<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static List<string> GetNames<T>()
        {
            return typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(fi => fi.Name)
                .ToList();
        }

        public static List<string> GetDisplayValues<T>()
        {
            return GetNames<T>()
                .Select(obj => GetDisplayValue(Parse<T>(obj)))
                .ToList();
        }

        public static string GetDisplayValue<T>(this T @enum)
        {
            var fieldInfo = @enum.GetType().GetField(@enum.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes[0].ResourceType != null)
            {
                return LookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);
            }

            return descriptionAttributes.Length > 0 
                ? descriptionAttributes[0].Name 
                : @enum.ToString();
        }

        private static string LookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }

            return resourceKey; // Fallback with the key name
        }
    }
}