using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
  public class Converter
  {
    private static string[] _split = new string[] { ",", " ", ", ", "|" };

    public static Vector2 ConvertVector2D(string vec)
    {
      try {
        string strPos = vec;
        string[] resut = strPos.Split(_split, StringSplitOptions.RemoveEmptyEntries);
        if (resut.Length < 2) {
          GameLog.Warn("ConvertVector2D faild.");
          return Vector2.zero;
        }
        Vector2 vector = new Vector2(Convert.ToSingle(resut[0]), Convert.ToSingle(resut[1]));
        return vector;
      } catch (System.Exception ex) {
        GameLog.Error("ConvertVector2D {0} Exception:{1}/{2}", vec, ex.Message, ex.StackTrace);
        throw;
      }
    }
    public static List<string> ConvertStringList(string vec)
    {
      List<string> list = new List<string>();
      try {
        string[] resut = vec.Split(_split, StringSplitOptions.RemoveEmptyEntries);
        foreach (string str in resut) {
          list.Add(str);
        }
      } catch (System.Exception ex) {
        GameLog.Error("ConvertStringList {0} Exception:{1}/{2}", vec, ex.Message, ex.StackTrace);
        throw;
      }
      return list;
    }
    public static List<int> ConvertIntList(string vec)
    {
      List<int> list = new List<int>();
      try {
        string[] resut = vec.Split(_split, StringSplitOptions.RemoveEmptyEntries);
        foreach (string str in resut) {
          list.Add(int.Parse(str));
        }
      } catch (System.Exception ex) {
        GameLog.Error("ConvertStringList {0} Exception:{1}/{2}", vec, ex.Message, ex.StackTrace);
        throw;
      }
      return list;
    }
    public static Vector3 ConvertVector3D(string vec)
    {
      try {
        string strPos = vec;
        string[] resut = strPos.Split(_split, StringSplitOptions.RemoveEmptyEntries);
        Vector3 vector = new Vector3(
          Convert.ToSingle(resut[0]), Convert.ToSingle(resut[1]), Convert.ToSingle(resut[2]));
        return vector;
      } catch (System.Exception ex) {
        GameLog.Error("ConvertVector3D {0} Exception:{1}/{2}", vec, ex.Message, ex.StackTrace);
        throw;
      }
    }
    public static Vector4 ConvertVector4D(string vec)
    {
      try {
        string strPos = vec;
        string[] resut = strPos.Split(_split, StringSplitOptions.RemoveEmptyEntries);
        Vector4 vector = new Vector4(
          Convert.ToSingle(resut[0]), Convert.ToSingle(resut[1]), Convert.ToSingle(resut[2]), Convert.ToSingle(resut[3]));
        return vector;
      } catch (System.Exception ex) {
        GameLog.Error("ConvertVector4D {0} Exception:{1}/{2}", vec, ex.Message, ex.StackTrace);
        throw;
      }
    }
    public static List<T> ConvertNumericList<T>(string vec)
    {
      List<T> list = new List<T>();
      try {
        string strPos = vec;
        string[] resut = strPos.Split(_split, StringSplitOptions.RemoveEmptyEntries);
        if (resut != null && resut.Length > 0 && resut[0] != "") {
          for (int index = 0; index < resut.Length; index++) {
            list.Add((T)Convert.ChangeType(resut[index], typeof(T)));
          }
        }
      } catch (System.Exception ex) {
        list.Clear();
        GameLog.Error("ConvertNumericList {0} Exception:{1}/{2}", vec, ex.Message, ex.StackTrace);
        throw;
      }

      return list;
    }
    public static List<Vector2> ConvertVector2DList(string vec)
    {
      List<Vector2> list = new List<Vector2>();
      try {
        string strPos = vec;
        string[] resut = strPos.Split(_split, StringSplitOptions.RemoveEmptyEntries);
        if (resut != null && resut.Length > 0 && resut[0] != "") {
          for (int index = 0; index < resut.Length; ) {
            list.Add(new Vector2(Convert.ToSingle(resut[index]), Convert.ToSingle(resut[index + 1])));
            index += 2;
          }
        }
      } catch (System.Exception ex) {
        list.Clear();
        GameLog.Error("ConvertVector2DList {0} Exception:{1}/{2}", vec, ex.Message, ex.StackTrace);
        throw;
      }
      return list;
    }
    public static List<Vector3> ConvertVector3DList(string vec)
    {
      List<Vector3> list = new List<Vector3>();
      try {
        string strPos = vec;
        string[] resut = strPos.Split(_split, StringSplitOptions.RemoveEmptyEntries);
        if (resut != null && resut.Length > 0 && resut[0] != "") {
          for (int index = 0; index < resut.Length; ) {
            list.Add(new Vector3(Convert.ToSingle(resut[index]),
                  Convert.ToSingle(resut[index + 1]),
                  Convert.ToSingle(resut[index + 2])));
            index += 3;
          }
        }
      } catch (System.Exception ex) {
        list.Clear();
        GameLog.Error("ConvertVector3DList {0} Exception:{1}/{2}", vec, ex.Message, ex.StackTrace);
        throw;
      }
      return list;
    }
    public static T ConvertStrToEnum<T>(string name)
    {
      try {
        return (T)(Enum.Parse(typeof(T), name));
      } catch (System.Exception ex) {
        GameLog.Error("ConvertStrToEnum {0} Exception:{1}/{2}", name, ex.Message, ex.StackTrace);
        throw;
      }
    }
    public static string ConvertEnumToStr<T>(T tVal)
    {
      try {
        return Enum.GetName(typeof(T), tVal);
      } catch (System.Exception ex) {
        GameLog.Error("ConvertEnumToStr {0} Exception:{1}/{2}", tVal, ex.Message, ex.StackTrace);
        throw;
      }
    }
  }
}
