using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace api.Helpers
{
    public class ObjectComparer
    {
        public static Dictionary<string , string> GetChangedFields<T>(T oldObject, T newObject, List<string> fieldNames)
        {
            Dictionary<string, string> changedFields = [];

            //default(T) represents the default value of the object 
            // if its a reference type string, class, object, array default is null
            //if its value tyoe int,bool default is false or zero
            if(object.Equals(oldObject, default(T)) || object.Equals(newObject, default(T)))
            {
                throw new ArgumentNullException(nameof(oldObject), "Objects to compare cannot be null");
            }

            StringBuilder sb = new();
            StringBuilder slb = new();

            // represents metadata about the generic type at runtime
            Type type = typeof(T);

            // this represents reflection in c#
            //type.GetProperties -> retrieves all public properties of the generic type ie. Name, UserId, Email.....
            // then we loop over each property
            foreach(PropertyInfo property in type.GetProperties())
            {
                //once we have the properties we then get the vlaues of each property
                var oldValue = property.GetValue(oldObject);
                var newValue = property.GetValue(newObject);

                //two checks here 
                //checks if property.Name should be tracked (should be tracked if it changed)
                //checks if oldvalue and newvalue are diiferent
                if(fieldNames.Contains(property.Name) && !Equals(oldValue, newValue))
                {
                    //check if we are updating the date time property
                    if(property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                    {
                        sb.Append($"{property.Name}: {((DateTime)oldValue).ToString("dd/MM/yyyy")}").Append(' ');
                        slb.Append($"{property.Name}: {((DateTime)newValue).ToString("dd/MM/yyyy")}").Append(' ');
                    } else
                    {
                        sb.Append($"{property.Name}: {oldValue}").Append(' ');
                        slb.Append($"{property.Name}: {newValue}").Append(' ');
                    }
                }
            }

            changedFields.Add("oldValue", sb.ToString());
            changedFields.Add("newValue", slb.ToString());

            //return both the old && new value
            return changedFields;
        }
    }
}
