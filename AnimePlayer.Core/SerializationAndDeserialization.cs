﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace AnimePlayer.Core
{
    public static class SerializationAndDeserialization
    {
        public static object Deserialization(string path)
        {

            try
            {
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                IFormatter formattter = new BinaryFormatter();
                object obj = formattter.Deserialize(stream);
                stream.Close();
                stream.Dispose();
                return obj;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Console.Error.WriteLineAsync(ex.ToString());
                return null;
            }
        }

        public static void Serialization(object obj, string path)
        {

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, obj);
            stream.Close();
            stream.Dispose();
        }
        public static object DeserializationJson(string path, Type type)
        {

            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            System.Runtime.Serialization.Json.DataContractJsonSerializer dataContractJsonSerializer = new(type);
            object obj = dataContractJsonSerializer.ReadObject(stream);
            stream.Close();
            stream.Dispose();
            return obj;
        }
        public static object DeserializationJsonFromString(string text, Type type)
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer dataContractJsonSerializer = new(type);
            object obj = dataContractJsonSerializer.ReadObject(XmlReader.Create(new StringReader(text)));
            return obj;
        }

        public static void SerializationJson(object obj, string path, Type type)
        {
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            DataContractJsonSerializer dataContractJsonSerializer = new(type);
            dataContractJsonSerializer.WriteObject(stream, obj);
            stream.Close();
            stream.Dispose();
        }

        public static string SerializationJsonGetString(object obj, Type type)
        {
            string str = null;
            str = JsonSerializer.Serialize(obj, type);
            return str;
        }
        public static string SerializationJsonEx(object obj, Type type)
        {
            string str = null;

            JsonSerializerOptions jsonSerializerOptions= new JsonSerializerOptions();
            jsonSerializerOptions.WriteIndented= true;
            str = JsonSerializer.Serialize(obj,type,jsonSerializerOptions);
            return str;
        }
        public static object DeserializationJsonEx(string path, Type type)
        {
            try
            {
                object obj = null;
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
                jsonSerializerOptions.WriteIndented = true;
                string txt = File.ReadAllText(path);
                obj = JsonSerializer.Deserialize(txt, type, jsonSerializerOptions);
                return obj;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

        public static object DeserializationJsonFromStringEx(string text, Type type)
        {
            object obj = JsonSerializer.Deserialize(text, type);
            return obj;
        }
    }
}
