﻿using Rhisis.Core.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hellion.Core.Resources
{
    /// <summary>
    /// Represents a C/C++ define file.
    /// </summary>
    public sealed class DefineFile : IDisposable
    {
        public static readonly string[] Extensions = new string[] { ".h", ".hh", ".hpp" };
        private const string DefineDirective = "#define";
        private const string DwordCast = "(DWORD)";
        private const string WordCast = "(WORD)";
        private const string ByteCast = "(BYTE)";

        private TokenScanner _scanner;
        private IDictionary<string, object> _defines;

        /// <summary>
        /// Gets the value of a define directive.
        /// </summary>
        /// <param name="define"></param>
        /// <returns></returns>
        public object this[string define] => this._defines.ContainsKey(define) ? this._defines[define] : null;

        /// <summary>
        /// Gets the define directive.
        /// </summary>
        public IReadOnlyDictionary<string, object> Defines => this._defines as IReadOnlyDictionary<string, object>;

        /// <summary>
        /// Creates a new DefineFile instance.
        /// </summary>
        /// <param name="filePath">Define file path</param>
        public DefineFile(string filePath)
        {
            this._scanner = new TokenScanner(filePath, @"([\t# ])");
            this._defines = new Dictionary<string, object>();

            this.Read();
        }

        /// <summary>
        /// Reads the define file.
        /// </summary>
        private void Read()
        {
            this._scanner.Read();

            string token = null;
            while ((token = this._scanner.GetToken()) != null)
            {
                if (token == "#" && this._scanner.GetToken() == "define")
                {
                    string defineName = this._scanner.GetToken();

                    if (this._scanner.CurrentTokenIs("#"))
                        continue;

                    object defineValue = this.ParseDefineValue(this._scanner.GetToken());

                    if (this._defines.ContainsKey(defineName))
                        this._defines[defineName] = defineValue;
                    else
                        this._defines.Add(defineName, defineValue);
                }
            }
        }

        /// <summary>
        /// Dispose the define file resources.
        /// </summary>
        public void Dispose()
        {
            if (this._defines.Any())
                this._defines.Clear();

            this._defines = null;
        }

        /// <summary>
        /// Parse the define value.
        /// </summary>
        /// <param name="defineValue">string define value</param>
        /// <returns></returns>
        private object ParseDefineValue(string defineValue)
        {
            object newDefineValue = null;

            try
            {
                if (defineValue.StartsWith(DwordCast))
                {
                    defineValue = defineValue.Replace(DwordCast, string.Empty);
                    newDefineValue = Convert.ToUInt32(defineValue, defineValue.StartsWith("0x") ? 16 : 10);
                }
                else if (defineValue.StartsWith(WordCast))
                {
                    defineValue = defineValue.Replace(WordCast, string.Empty);
                    newDefineValue = Convert.ToUInt16(defineValue, defineValue.StartsWith("0x") ? 16 : 10);
                }
                else if (defineValue.StartsWith(ByteCast))
                {
                    defineValue = defineValue.Replace(ByteCast, string.Empty);
                    newDefineValue = Convert.ToByte(defineValue, defineValue.StartsWith("0x") ? 16 : 10);
                }
                else if (defineValue.EndsWith("L"))
                {
                    defineValue = defineValue.Replace("L", string.Empty);
                    newDefineValue = Convert.ToInt64(defineValue, defineValue.StartsWith("0x") ? 16 : 10);
                }
                else
                {
                    newDefineValue = Convert.ToInt32(defineValue, defineValue.StartsWith("0x") ? 16 : 10);
                }
            }
            catch
            {
                newDefineValue = 0;
            }

            return newDefineValue;
        }
    }
}