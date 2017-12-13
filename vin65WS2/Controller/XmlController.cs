using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace vin65WS2.Controller
{
    //DEAN JONES
    //MAY 31, 2017
    //XmlController.cs
    //handles all the METHODS for generating STRINGS and FILES for XML
    //STATIC class


    public static class XmlController
    {
        //SERIALIZE XML TO STRING
        public static string Serialize(object obj)
        {
            //end process if object is NULL
            if (obj == null)
                return null;

            XmlSerializer ser = new XmlSerializer(obj.GetType());

            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamReader sr = new StreamReader(ms))
                {
                    ser.Serialize(ms, obj);
                    ms.Seek(0, 0);                  //start at beginning
                    return sr.ReadToEnd();
                }
            }

        }

        //WRITE XML TO FILE 
        public static void WriteXMLToFile(string xml, string path)
        {
            //DATE 
            DateTime date = DateTime.Now;
            string date_format = "yyyyMMdd_hhmm";   //DATE: year/month/day_hours/seconds
            string fullpath = @"" + path + "\\vin65response" + date.ToString(date_format) + ".xml";

            try
            {
                //XML ALREADY CORRECT (just write it to file)
                File.WriteAllText(fullpath, xml);
            }
            catch (System.IO.DirectoryNotFoundException ex1)
            {
                Console.WriteLine(ex1.Message);
                Console.WriteLine(ex1.StackTrace);
                throw ex1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }

        }

        //WRITE XML TO FILE
        //public static void WriteXMLToFile(string xml, string path)
        //public static void WriteXMLToFile3(object xml, string path)
        //{
        //    //result (bool)
        //    //bool result = false;

        //    XmlWriterSettings settings = new XmlWriterSettings();
        //    settings.CheckCharacters = true;
        //    settings.DoNotEscapeUriAttributes = true;

        //    XmlSerializer xs = new XmlSerializer(xml.GetType());        

        //    //DATE 
        //    DateTime date = DateTime.Now;
        //    //string date_format = "yyyyMMdd";
        //    string date_format = "yyyyMMdd_hhmm";   //DATE: year/month/day_hours/seconds
        //                                            //XML PATH

        //    //string fullpath = @"c:\_temp\response" + date.ToString(date_format) + ".xml";
        //    //C:\_temp      (path needs '\' at end)
        //    string fullpath = @"" + path + "\\vin65response" + date.ToString(date_format) + ".xml";

        //    try
        //    {
        //        //TextWriter tw = new StreamWriter(fullpath);
        //        StreamWriter sw = new StreamWriter(fullpath);
        //        xs.Serialize(sw, xml);
        //        //return result = true;
        //    }
        //    catch(Exception ex)         
        //    {
        //        throw ex;
        //    }

        //    //TEST IF WRITE IS TRUE (did it work?)
        //    //output (lt;)(gt;) symbols?
        //    //STRING vs XDOCUMENT or XML?
        //}

        //*** THIS WORKS, BUT IS THE SAME AS (Serialize METHOD) so it's redundant ***
        //XML FROM OBJECT (returns a string)
        //public static string GetXMLFromObject(object obj)
        //{
        //    StringWriter sw = new StringWriter();
        //    XmlTextWriter xtw = null;
        //    try
        //    {
        //        XmlSerializer serializer = new XmlSerializer(obj.GetType());    //same as typeof(PS_Product1)
        //        xtw = new XmlTextWriter(sw);
        //        serializer.Serialize(xtw, obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        sw.Close();
        //        if (xtw != null)
        //        {
        //            xtw.Close();
        //        }
        //    }
        //    return sw.ToString();
        //}
    }
}
