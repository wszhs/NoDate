using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

/// <summary>
/// Xml序列化与反序列化
/// </summary>
public class XmlUtil
{
    #region 反序列化
    /// <summary>
    /// 反序列化
    /// </summary>
    /// <param name="type">类型</param>
    /// <param name="xml">XML内容的字符串</param>
    /// <returns></returns>
    public static T Deserialize<T>(string xml)
    {
        try
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xmldes = new XmlSerializer(typeof(T));
                return (T)xmldes.Deserialize(sr);
            }
        }
        catch (Exception e)
        {

            throw;
        }



    }
    /// <summary>
    /// 反序列化
    /// </summary>
    /// <param name="type"></param>
    /// <param name="xml"></param>
    /// <returns></returns>
    public static T Deserialize<T>(Stream stream)
    {
        XmlSerializer xmldes = new XmlSerializer(typeof(T));
        return (T)xmldes.Deserialize(stream);
    }
    #endregion

    #region 序列化
    /// <summary>
    /// 实体类转化成xml的字符串
    /// </summary>
    /// <param name="type">类型</param>
    /// <param name="obj">对象</param>
    /// <returns></returns>
    public static string EntityToXMLStr(object obj)
    {
        MemoryStream Stream = new MemoryStream();
        XmlSerializer xml = new XmlSerializer(obj.GetType());
        try
        {
            //序列化对象
            xml.Serialize(Stream, obj);
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        Stream.Position = 0;
        StreamReader sr = new StreamReader(Stream,Encoding.UTF8);
        string str = sr.ReadToEnd();

        sr.Dispose();
        Stream.Dispose();

        return str;
    }

    #endregion

    public static string XML2String(string xmlPath)
    {
        try
        {

            using (FileStream fs = File.Open(xmlPath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string line = sr.ReadToEnd();
                    return line;
                }
            }


        }
        catch (Exception e)
        {

            throw (e);
        }
    }
    public static T GetXML2Entity<T>(string filePath_Name)
    {

        string xmlValue = XML2String(filePath_Name);
        T tt = Deserialize<T>(xmlValue);
        return tt;
    }
    /// <summary>
    /// 保存字符串到xml中
    /// </summary>
    public static void SaveStr2XML(string filePath, string writeValue)
    {
        try
        {
            string old = "encoding=\"gb2312\"";
            writeValue = writeValue.Replace(old, "");
            using (FileStream fsFile = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter swWriter = new StreamWriter(fsFile,Encoding.UTF8))
                {
                    swWriter.WriteLine(writeValue);
                    swWriter.Close();
                }
            }
        }
        catch (Exception e)
        {

            // MessageBox.Show("SaveStr2XML=" + e.Message);
        }
    }
   
}

