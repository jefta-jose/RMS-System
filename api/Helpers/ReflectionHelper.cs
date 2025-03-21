using Humanizer;
using NPOI.Util.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace api.Helpers
{
    public class ReflectionHelper
    {
        //IReadOnlyList<PropertyInfo>: Returns a read-only list of PropertyInfo objects,
        //where each PropertyInfo represents a property of type T.
        public static IReadOnlyList<PropertyInfo> GetProperties<T>()
        {
            return typeof(T).GetProperties().AsReadOnly();
            //typeof(T): Retrieves the Type object representing T.
            //.GetProperties(): Fetches all public properties of T as an array of PropertyInfo objects.
            //.AsReadOnly(): Converts the array into a read-only list to prevent modifications.
        }
    }
}
