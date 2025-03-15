using System.Runtime.Serialization;

namespace api.Helpers.Enum
{
    public class Constants
    {
        public enum ActivityType
        //the actvityType enum represents a set of named constants representing different types of activities
        //each enum is associated with a string value using the [EnumMember] attribute
        {
            [EnumMember(Value = "VIEW")] Read, // here Read is associated with the string VIEW
            [EnumMember(Value = "CREATE")] Create,
            [EnumMember(Value = "UPDATE")] Update,
            [EnumMember(Value = "DELETE")] Delete,
            [EnumMember(Value = "LOGIN")] Login,
            [EnumMember(Value = "LOGOUT")] Logout,
            [EnumMember(Value = "UPLOAD")] Upload,
            [EnumMember(Value = "DOWNLOAD")] Download,
            [EnumMember(Value = "ARCHIVE")] Archive,
            [EnumMember(Value = "RESTORE")] Restore,
        }

        // this method is a utility method that retreives the string value associated with an ActivityType enummember
        public static string GetEnumMemberValue(ActivityType activityType)
        {
            //get the type of the enum
            var type = typeof(ActivityType);

            // this retrieves an array of MemberInfo objects for the specific enum members eg Read, Create
            //since enums are constants there will only be one member in the array so we uer memberInfo[0]
            var memberInfo = type.GetMember(activityType.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false); // here we retrive the custome attribute applied to the enum member

            // this represents the value property associated with the enum member ie. VIEW for Read
            var enumValue = ((EnumMemberAttribute)attributes[0]).Value;

            return enumValue;
        }
    }
}
