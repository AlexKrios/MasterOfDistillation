﻿using System;

namespace Assets.Scripts.Utils
{
    public class EnumParse
    {
        public static T ParseStringToEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
