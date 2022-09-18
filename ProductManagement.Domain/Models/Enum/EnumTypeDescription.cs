﻿using System.ComponentModel;

namespace ProductManagementDomain.Models.Enum
{
    public static class EnumTypeDescription
    {
        public static string GetEnumDescription(this System.Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo == null) return enumValue.ToString();

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0   ? descriptionAttributes[0].Description : enumValue.ToString();

        }
    }
}

 