﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.SceneManagement;
using System.IO.Compression;
using Common;
using ICSharpCode.SharpZipLib.BZip2;

[SLua.CustomLuaClass]
public class GameUtil : MonoBehaviour
{
    #region MD5
    /// <summary>
    /// 计算字符串的MD5值
    /// </summary>
    public static string MD5(string source)
    {
        string str = "";
        byte[] data = Encoding.GetEncoding("utf-8").GetBytes(str);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] bytes = md5.ComputeHash(data);
        for (int i = 0; i < bytes.Length; i++)
        {
            str += bytes[i].ToString("x2");
        }
        return str.ToLower();
    }

    /// <summary>
    /// 计算文件的MD5值
    /// </summary>
    public static string MD5File(string filePath)
    {
        try
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash_byte = md5.ComputeHash(file);
            string str = System.BitConverter.ToString(hash_byte);
            str = str.Replace("-", "");
            return str.ToLower();
        }
        catch (Exception ex)
        {
            throw new Exception("md5file() fail, error:" + ex.Message);
        }
    }
    #endregion

    #region 加密解密字符串

    private static string encryptKey = "Oyea";    //定义密钥  

    /// <summary> /// 加密字符串   
    /// </summary>  
    /// <param name="str">要加密的字符串</param>  
    /// <returns>加密后的字符串</returns>  
    public static string EncryptString(string str)
    {
        DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   

        byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

        byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串  

        MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

        //使用内存流实例化加密流对象   
        CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);

        CStream.Write(data, 0, data.Length);  //向加密流中写入数据      

        CStream.FlushFinalBlock();              //释放加密流      

        return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串  
    }

    /// <summary>  
    /// 解密字符串   
    /// </summary>  
    /// <param name="str">要解密的字符串</param>  
    /// <returns>解密后的字符串</returns>  
    public static string DecryptString(string str)
    {
        DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象    

        byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

        byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串  

        MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

        //使用内存流实例化解密流对象       
        CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);

        CStream.Write(data, 0, data.Length);      //向解密流中写入数据     

        CStream.FlushFinalBlock();               //释放解密流      

        return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串  
    }

    #endregion

    #region 字符串简单加密解密

    /// <summary>
    /// 简单加密
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string Encode(string text)
    {
        char[] words = text.ToCharArray();
        for (int i = 0; i < words.Length; i++)
        {
            int a = (int)words[i];
            if (a >= 48 && a <= 57)//数字0-9
            {
                a = a + 3;
                if (a > 57)
                    a = a - 10;
            }

            if (a >= 65 && a <= 90)//字母A-Z
            {
                a = a + 3;
                if (a > 90)
                    a = a - 26;
            }

            if (a >= 97 && a <= 122)//字母a-z
            {
                a = a + 3;
                if (a > 122)
                    a = a - 26;
            }
            words[i] = (char)(a);

        }
        return new string(words);
    }

    /// <summary>
    /// 简单解密
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string Decode(string text)
    {
        char[] words = text.ToCharArray();
        for (int i = 0; i < words.Length; i++)
        {
            int a = (int)words[i];
            if (a >= 48 && a <= 57)//数字0-9
            {
                a = a - 3;
                if (a < 48)
                    a = a + 10;
            }

            if (a >= 65 && a <= 90)//字母A-Z
            {
                a = a - 3;
                if (a < 65)
                    a = a + 26;
            }

            if (a >= 97 && a <= 122)//字母a-z
            {
                a = a - 3;
                if (a < 97)
                    a = a + 26;
            }
            words[i] = (char)(a);
        }
        return new string(words);
    }

    #endregion

    #region 字节数组压缩解压

    /// <summary>
    /// 压缩字节数组
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static byte[] CompressBytes(byte[] data)
    {
        //方法一、
        //using (MemoryStream outs = new MemoryStream())
        //{
        //    using (GZipStream zipStream = new GZipStream(outs, CompressionMode.Compress))
        //    {
        //        zipStream.Write(data, 0, data.Length);
        //        return outs.GetBuffer();
        //    }
        //}
        //方法二、
        using (MemoryStream ms = new MemoryStream())
        {
            using (BZip2OutputStream outStream = new BZip2OutputStream(ms))
            {
                outStream.Write(data, 0, data.Length);
                outStream.Close();
                return ms.ToArray();
            }
        }
    }

    /// <summary>
    /// 解压字节数组
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static byte[] DecompressBytes(byte[] data)
    {
        //方法一、
        //using (MemoryStream ins = new MemoryStream(data))
        //{
        //    using (MemoryStream outs = new MemoryStream())
        //    {
        //        using (GZipStream zipStream = new GZipStream(ins, CompressionMode.Decompress))
        //        {
        //            byte[] buffer = new byte[1024 * 1024];
        //            int len = 0;
        //            while (true)
        //            {
        //                len = zipStream.Read(buffer, 0, buffer.Length);
        //                if (len <= 0) break;
        //                outs.Write(buffer, 0, len);
        //            }
        //            return outs.GetBuffer();
        //        }
        //    }
        //}
        //方法二、
        using (MemoryStream ins = new MemoryStream(data))
        {
            using (MemoryStream outs = new MemoryStream())
            {
                using (BZip2InputStream inStream = new BZip2InputStream(ins))
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int len = 0;
                    while (true)
                    {
                        len = inStream.Read(buffer, 0, buffer.Length);
                        inStream.Close();
                        if (len <= 0) break;
                        outs.Write(buffer, 0, len);
                    }
                    return outs.ToArray();
                }
            }
        }
    }

    #endregion

    /// <summary>
    /// 生成AssetBundle的标签
    /// 路径以Assets/开头
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string GetAssetBundleTag(string path)
    {
        string tag = "";
        string fileName = Path.GetFileName(path);
#if PerFile
        tag = path.Replace("Assets/", "").Replace(fileName, "") + Path.GetFileNameWithoutExtension(path) + ".bytes";
#else
        tag = path.Replace("Assets/", "").Replace("/" + fileName, "") + ".bytes";
#endif
        return tag.ToLower();
    }

    /// <summary>
    /// 获取资源类型
    /// </summary>
    /// <param name="at"></param>
    /// <returns></returns>
    public static Type GetAssetType(AssetType at)
    {
        Type t = typeof(object);
        switch (at)
        {
            case AssetType.Sprite:
                t = typeof(Sprite);
                break;
            case AssetType.Texture2D:
                t = typeof(Texture2D);
                break;
            case AssetType.TextAsset:
                t = typeof(TextAsset);
                break;
            case AssetType.AudioClip:
                t = typeof(AudioClip);
                break;
            case AssetType.AnimationClip:
                t = typeof(AnimationClip);
                break;
            case AssetType.Font:
                t = typeof(Font);
                break;
            case AssetType.Material:
                t = typeof(Material);
                break;
            case AssetType.Prefab:
                t = typeof(GameObject);
                break;
            default:
                t = typeof(object);
                break;
        }
        return t;
    }

    /// <summary>
    /// 创建路径
    /// </summary>
    /// <param name="path"></param>
    public static void CreateDirectory(string path)
    {
        string dirName = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(dirName)) if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);
    }
}
