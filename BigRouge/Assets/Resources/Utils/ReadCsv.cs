﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;


namespace BigRogue.Util {


    /// <summary>
    /// 逗号分隔的行列表,会忽略//开头的行,字符串中间的//往后的内容也会被忽略
    /// </summary>
    public static class SimpleCsv {


        const string pattern = @"[\r\n]|//+.*[\r\n]";


        static SimpleCsv(){}

        /// <summary>
        /// 根据一个res名字载入资源
        /// </summary>
        /// <returns></returns>
        public static string[] OpenCsv(string path) {
            TextAsset text = Resources.Load<TextAsset>(path);
            
            if (text != null)
                return OpenCsv(text);
            else
                throw new UnityException($"读取文件错误:{path}");
        }


        /// <summary>
        /// 获取csv的所有数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string[] OpenCsv(TextAsset text) {
            Regex reg = new Regex(pattern);
            string[] lines = reg.Split(text.text);
            return lines.Where((x) => !string.IsNullOrEmpty(x)).ToArray<string>();
        }





    }
}