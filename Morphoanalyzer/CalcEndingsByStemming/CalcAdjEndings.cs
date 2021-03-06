﻿using GenerationN.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Morphoanalyzer.EndingsBase;
using Morphoanalyzer.ExceptionsAndWords;
using Morphoanalyzer.Exceptions;
using Morphoanalyzer.Features;

namespace Morphoanalyzer.CalcEndingsByStemming
{
    public class CalcAdjEndings : CalcEndingsGeneral, IGetEndings
    {
        private string word;

        AdjEndings adjEndings;

        private ExceptionAdjectives exAdjectives;
         
        public CalcAdjEndings(string word)
        {
            this.word = word;
            adjEndings = new AdjEndings();
            TmpDict = new Dictionary<string, string>();
            exAdjectives = new ExceptionAdjectives();
            ExceptionDict = new Dictionary<string, Dictionary<string, string>>(exAdjectives.Dict);
        }

        public Dictionary<string, string> GetEndings()
        {
            int res = SearchWordFromExSet(this.word);
            if (res == 1)
            {
                CalcEndingsGeneral.exceptionWordInt = 2;//for adj this is 2
                return this.TmpDict;
            }
            else
            {
                Dictionary<string, string> Dict = new Dictionary<string, string>();

                //if mode is 1, it means that algorithm will stem from right to left
                //if mode is 0, the stemming algorithm will stem from left to right
                int mode = 1;

                //Данный счётчик нужен для того, чтобы определить, было ли добавлено 
                //окончание существительного
                int processed = 0;

                //This string is used for storing root of the word
                //1-noun, 2-adj, 3-verb, 4-adverbs
                string rootOfWord = string.Empty;

                for (int i = adjEndings.Dict.Count; i > 0; i--)
                {
                    string strKey = string.Empty;
                    string strValue = string.Empty;
                    string key = string.Empty;
                    string value = string.Empty;


                    if (i == 1)
                    {
                        mode = 0;
                    }

                    foreach (KeyValuePair<string, string> kvp in adjEndings.Dict[i])
                    {
                        if (KeyValue(kvp.Key, strKey, mode, this.word))
                        {
                            strKey = kvp.Key;
                            strValue = kvp.Value;
                        }
                        if (strKey.Length > key.Length)
                        {
                            key = new string(strKey);
                            value = new string(strValue);
                        }
                    }

                    if (string.IsNullOrEmpty(key) == false)
                    {
                        processed++;
                        Dict.Add(key, value);
                        rootOfWord = CalcTypeofRoot.TypeOfRoot(i, 1);
                        if (mode == 0)
                        {
                            //это нулевой dict, где мы удаляем не окончание, а приставку
                            this.word = this.word.Remove(0, key.Length);
                        }
                        else
                        {
                            this.word = this.word.Remove(this.word.Length - key.Length);
                        }
                    }

                }

                if (processed > 0)
                {
                    Dict.Add(this.word, rootOfWord);
                }

                return Dict;
            }
        }

    }
}
