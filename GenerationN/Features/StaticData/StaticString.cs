﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenerationN.StaticData
{
    public class StaticString
    {
        public static int KindsOfEndings = 4;
        public static int LevelOfEndings = 3;
        public static string NotFounded =
            "Не удалось распознать слово, попробуйте проверить правильно написания";
        public static string MainString = "Основа слова";
        /*
          Dictionary<string, Person> peopleA = new Dictionary<string, Person>();
          peopleA.Add("Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 }); 
          
          Dictionary<string, Person> peopleB = new Dictionary<string, Person>()
          {
          { "Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 } },
          { "Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 } }
           };

        Dictionary<string, Person> peopleC = new Dictionary<string, Person>()
        {
         ["Homer"] = new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
         .. };
         */


    }
}
