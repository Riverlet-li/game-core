using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameCore
{
    public class TableExtracter
    {
        public static string ExtractString(TableRowBuffer node, string nodeName, string defaultVal)
        {
            string result = defaultVal;
            if (node == null || !node.HasFields || node.GetDataByName(nodeName) == null) {
                return result;
            }
            string nodeText = node.GetDataByName(nodeName);
            if (!string.IsNullOrEmpty(nodeText)) {
                result = nodeText;
            }
            return result;
        }
        public static List<string> ExtractStringList(TableRowBuffer node, string nodeName, string[] defaultVal)
        {
            List<string> result = new List<string>();
            if (node == null || !node.HasFields) {
                return result;
            }
            string nodeText = node.GetDataByName(nodeName);
            if (!string.IsNullOrEmpty(nodeText)) {
                result = Converter.ConvertStringList(nodeText);
            } else if (null != defaultVal) {
                result.AddRange(defaultVal);
            }
            return result;
        }
        public static string[] ExtractStringArray(TableRowBuffer node, string nodeName, string[] defaultVal)
        {
            List<string> list = ExtractStringList(node, nodeName, defaultVal);
            if (null != list) {
                return list.ToArray();
            } else {
                return null;
            }
        }
        public static bool ExtractBool(TableRowBuffer node, string nodeName, bool defaultVal)
        {
            bool result = defaultVal;
            if (node == null || !node.HasFields || node.GetDataByName(nodeName) == null) {
                return result;
            }
            string nodeText = node.GetDataByName(nodeName);
            if (!string.IsNullOrEmpty(nodeText)) {
                if (nodeText.Trim().ToLower() == "true" || nodeText.Trim().ToLower() == "1") {
                    result = true;
                }
                if (nodeText.Trim().ToLower() == "false" || nodeText.Trim().ToLower() == "0") {
                    result = false;
                }
            }
            return result;
        }
        public static T ExtractNumeric<T>(TableRowBuffer node, string nodeName, T defaultVal)
        {
            T result = defaultVal;
            if (node == null || !node.HasFields || node.GetDataByName(nodeName) == null) {
                return result;
            }
            string nodeText = node.GetDataByName(nodeName);
            if (!string.IsNullOrEmpty(nodeText)) {
                try {
                    result = (T)Convert.ChangeType(nodeText, typeof(T));
                } catch (System.Exception ex) {
                    GameLog.Error("ExtractNumeric {0} {1} Exception:{2}/{3}", nodeName, nodeText, ex.Message, ex.StackTrace);
                    throw;
                }
            }
            return result;
        }
        public static List<T> ExtractNumericList<T>(TableRowBuffer node, string nodeName, T[] defaultVal)
        {
            List<T> result = new List<T>();
            if (node == null || !node.HasFields || node.GetDataByName(nodeName) == null) {
                return result;
            }
            string nodeText = node.GetDataByName(nodeName);
            if (!string.IsNullOrEmpty(nodeText)) {
                result = Converter.ConvertNumericList<T>(nodeText);
            } else if (null != defaultVal) {
                result.AddRange(defaultVal);
            }
            return result;
        }
        public static T[] ExtractNumericArray<T>(TableRowBuffer node, string nodeName, T[] defaultVal)
        {
            List<T> list = ExtractNumericList<T>(node, nodeName, defaultVal);
            if (null != list) {
                return list.ToArray();
            } else {
                return null;
            }
        }

        public static string ExtractString(TableRowBuffer node, string nodeName, string defaultVal, bool isMust)
        {
            return ExtractString(node, nodeName, defaultVal);
        }

        public static List<string> ExtractStringList(TableRowBuffer node, string nodeName, string defaultVal, bool isMust)
        {
            List<string> result = new List<string>();
            if (node == null || !node.HasFields) {
                return result;
            }
            string nodeText = node.GetDataByName(nodeName);
            if (!string.IsNullOrEmpty(nodeText)) {
                result = Converter.ConvertStringList(nodeText);
            }
            return result;
        }
        public static bool ExtractBool(TableRowBuffer node, string nodeName, bool defaultVal, bool isMust)
        {
            return ExtractBool(node, nodeName, defaultVal);
        }
        public static T ExtractNumeric<T>(TableRowBuffer node, string nodeName, T defaultVal, bool isMust)
        {
            return ExtractNumeric<T>(node, nodeName, defaultVal);
        }
        public static List<T> ExtractNumericList<T>(TableRowBuffer node, string nodeName, T defaultVal, bool isMust)
        {
            List<T> result = new List<T>();
            if (node == null || !node.HasFields || node.GetDataByName(nodeName) == null) {
                return result;
            }
            string nodeText = node.GetDataByName(nodeName);
            if (!string.IsNullOrEmpty(nodeText)) {
                result = Converter.ConvertNumericList<T>(nodeText);
            }
            return result;
        }

        public static T ExtractEnum<T>(TableRowBuffer node, string nodeName, T defaultVal)
        {
            return (T)(object)(ExtractNumeric<int>(node, nodeName, (int)(object)(defaultVal)));
        }

        public static void ExtractValues<T>(IList<T> list, int ct, params T[] vals)
        {
            for (int i = 0; i < ct && i < vals.Length; ++i) {
                list.Add(vals[i]);
            }
        }
        public static void ExtractValues<T>(T[] list, int ct, params T[] vals)
        {
            for (int i = 0; i < list.Length && i < ct && i < vals.Length; ++i) {
                list[i] = vals[i];
            }
        }
        public static T CloneValue<T>(T ins)
        {
            return ins;
        }
        public static List<T> CloneList<T>(List<T> ins)
        {
            List<T> clone = new List<T>();
            foreach (T item in ins) {
                clone.Add(item);
            }
            return clone;
        }
        public static T[] CloneArray<T>(T[] ins)
        {
            T[] clone = new T[ins.Length];
            for (int idx = 0; idx < ins.Length; idx++) {
                clone[idx] = ins[idx];
            }
            return clone;
        }

        private static bool IsEqual(IList<int> a, IList<int> b)
        {
            if (null == a && null != b || null != a && null == b)
                return false;
            if (a.Count != b.Count)
                return false;
            for (int i = 0; i < a.Count; ++i) {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }
        private static bool IsEqual(IList<float> a, IList<float> b)
        {
            if (null == a && null != b || null != a && null == b)
                return false;
            if (a.Count != b.Count)
                return false;
            for (int i = 0; i < a.Count; ++i) {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }
        private static bool IsEqual(IList<string> a, IList<string> b)
        {
            if (null == a && null != b || null != a && null == b)
                return false;
            if (a.Count != b.Count)
                return false;
            for (int i = 0; i < a.Count; ++i) {
                if (0 != a[i].CompareTo(b[i]))
                    return false;
            }
            return true;
        }
    }
}
