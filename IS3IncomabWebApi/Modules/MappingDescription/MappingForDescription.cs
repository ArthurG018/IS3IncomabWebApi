using Dapper;
using IS3IncomabWebApi.DomainLayer.Entity;
using System.ComponentModel;
using System.Reflection;

namespace IS3IncomabWebApi.Modules.MappingDescription
{
    public class MappingForDescription
    {
        public static String GetDescriptionFromAttribute(MemberInfo member)
        {
            if (member == null) return null;

            var attrib = Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute), false) as DescriptionAttribute;
            return (attrib?.Description ?? member.Name).ToLower();
        }

        public static void MapCylinder()
        {
            var map = new CustomPropertyTypeMap(typeof(Cylinder), (type, columnName) => type.GetProperties().FirstOrDefault(prop => GetDescriptionFromAttribute(prop) == columnName.ToLower()));
            Dapper.SqlMapper.SetTypeMap(typeof(Cylinder), map);
        }
    }
}
