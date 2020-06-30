using System.Collections.Generic;
using System.Linq;

namespace System.Reflection
{
    public static class IEunmerableExtension
    {
        public static IEnumerable<FieldInfo> WithAttribute<T>(this IEnumerable<FieldInfo> list)
        {
            return list.WithAttribute(typeof(T));
        }
        public static  IEnumerable<FieldInfo> WithAttribute(this IEnumerable<FieldInfo>list, Type attributeType)
        {
            return list.Where(f => f.CustomAttributes.Any(a => a.AttributeType == attributeType));
        }

        public static IEnumerable<PropertyInfo> WithAttribute<T>(this IEnumerable<PropertyInfo> list)
        {
            return list.WithAttribute(typeof(T));
        }
        public static IEnumerable<PropertyInfo> WithAttribute(this IEnumerable<PropertyInfo> list, Type attributeType)
        {
            return list.Where(p => p.CustomAttributes.Any(a => a.AttributeType == attributeType));
        }

        public static IEnumerable<Type> AssignableTo<T>(this IEnumerable<Type> list)
        {
            return list.AssignableTo(typeof(T));
        }
        public static IEnumerable<Type> AssignableTo(this IEnumerable<Type> list, Type type)
        {
            Conditions.NotNull(type, nameof(type));
            return list.AssignableToAny(type);
        }
        public static IEnumerable<Type> AssignableToAny(this IEnumerable<Type> list, params Type[] types)
        {
            Conditions.NotNull(types, nameof(types));
            return list.AssignableToAny(types.AsEnumerable());
        }

        public static IEnumerable<Type> AssignableToAny(this IEnumerable<Type> list, IEnumerable<Type> types)
        {
            Conditions.NotNull(types, nameof(types));
            return Where(list, t => types.Any(t.IsAssignableTo));
        }
        public static IEnumerable<Type> WithAttribute<T>(this IEnumerable<Type> list) where T : Attribute
        {
            return list.WithAttribute(typeof(T));
        }

        public static IEnumerable<Type> WithAttribute(this IEnumerable<Type> list, Type attributeType)
        {
            Conditions.NotNull(attributeType, nameof(attributeType));
            return Where(list, t => t.HasAttribute(attributeType));
        }

        public static IEnumerable<Type> WithAttribute<T>(this IEnumerable<Type> list, Func<T, bool> predicate) where T : Attribute
        {
            Conditions.NotNull(predicate, nameof(predicate));
            return Where(list, t => t.HasAttribute(predicate));
        }

        public static IEnumerable<Type> WithoutAttribute<T>(this IEnumerable<Type> list) where T : Attribute
        {
            return WithoutAttribute(list, typeof(T));
        }

        public static IEnumerable<Type> WithoutAttribute(this IEnumerable<Type> list, Type attributeType)
        {
            Conditions.NotNull(attributeType, nameof(attributeType));
            return Where(list, t => !t.HasAttribute(attributeType));
        }

        public static IEnumerable<Type> WithoutAttribute<T>(this IEnumerable<Type> list, Func<T, bool> predicate) where T : Attribute
        {
            Conditions.NotNull(predicate, nameof(predicate));
            return Where(list, t => !t.HasAttribute(predicate));
        }

        public static IEnumerable<Type> InNamespaceOf<T>(this IEnumerable<Type> list)
        {
            return list.InNamespaceOf(typeof(T));
        }

        public static IEnumerable<Type> InNamespaceOf(this IEnumerable<Type> list, params Type[] types)
        {
            Conditions.NotNull(types, nameof(types));
            return list.InNamespaces(types.Select(t => t.Namespace));
        }

        public static IEnumerable<Type> InNamespaces(this IEnumerable<Type> list, params string[] namespaces)
        {
            Conditions.NotNull(namespaces, nameof(namespaces));
            return list.InNamespaces(namespaces.AsEnumerable());
        }

        public static IEnumerable<Type> InExactNamespaceOf<T>(this IEnumerable<Type> list)
        {
            return list.InExactNamespaceOf(typeof(T));
        }

        public static IEnumerable<Type> InExactNamespaceOf(this IEnumerable<Type> list, params Type[] types)
        {
            Conditions.NotNull(types, nameof(types));
            return Where(list, t => types.Any(x => t.IsInExactNamespace(x.Namespace)));
        }

        public static IEnumerable<Type> InExactNamespaces(this IEnumerable<Type> list, params string[] namespaces)
        {
            Conditions.NotNull(namespaces, nameof(namespaces));
            return Where(list, t => namespaces.Any(t.IsInExactNamespace));
        }

        public static IEnumerable<Type> InNamespaces(this IEnumerable<Type> list, IEnumerable<string> namespaces)
        {
            Conditions.NotNull(namespaces, nameof(namespaces));
            return Where(list, t => namespaces.Any(t.IsInNamespace));
        }

        public static IEnumerable<Type> NotInNamespaceOf<T>(this IEnumerable<Type> list)
        {
            return list.NotInNamespaceOf(typeof(T));
        }

        public static IEnumerable<Type> NotInNamespaceOf(this IEnumerable<Type> list, params Type[] types)
        {
            Conditions.NotNull(types, nameof(types));
            return list.NotInNamespaces(types.Select(t => t.Namespace));
        }

        public static IEnumerable<Type> NotInNamespaces(this IEnumerable<Type> list, params string[] namespaces)
        {
            Conditions.NotNull(namespaces, nameof(namespaces));
            return list.NotInNamespaces(namespaces.AsEnumerable());
        }

        public static IEnumerable<Type> NotInNamespaces(this IEnumerable<Type> list, IEnumerable<string> namespaces)
        {
            Conditions.NotNull(namespaces, nameof(namespaces));
            return Where(list, t => namespaces.All(ns => !t.IsInNamespace(ns)));
        }

        public static IEnumerable<Type> Where(IEnumerable<Type> list, Func<Type, bool> predicate)
        {
            Conditions.NotNull(predicate, nameof(predicate));
            return list.Where(predicate);
        }
    }
}
