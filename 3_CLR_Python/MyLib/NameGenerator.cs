﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLib
{
    public class NameGenerator
    {
        private Random mRand = new Random();

        private readonly IEnumerable<string> mNames = new string[] {"James",
"Mary",
"Robert",
"Patricia",
"John",
"Jennifer",
"Michael",
"Linda",
"David",
"Elizabeth",
"William",
"Barbara",
"Richard",
"Susan",
"Joseph",
"Jessica",
"Thomas",
"Sarah",
"Christopher",
"Karen",
"Charles",
"Lisa",
"Daniel",
"Nancy",
"Matthew",
"Betty",
"Anthony",
"Sandra",
"Mark",
"Margaret",
"Donald",
"Ashley",
"Steven",
"Kimberly",
"Andrew",
"Emily",
"Paul",
"Donna",
"Joshua",
"Michelle",
"Kenneth",
"Carol",
"Kevin",
"Amanda",
"Brian",
"Melissa",
"George",
"Deborah",
"Timothy",
"Stephanie",
"Ronald",
"Dorothy",
"Jason",
"Rebecca",
"Edward",
"Sharon",
"Jeffrey",
"Laura",
"Ryan",
"Cynthia",
"Jacob",
"Amy",
"Gary",
"Kathleen",
"Nicholas",
"Angela",
"Eric",
"Shirley",
"Jonathan",
"Brenda",
"Stephen",
"Emma",
"Larry",
"Anna",
"Justin",
"Pamela",
"Scott",
"Nicole",
"Brandon",
"Samantha",
"Benjamin",
"Katherine",
"Samuel",
"Christine",
"Gregory",
"Helen",
"Alexander",
"Debra",
"Patrick",
"Rachel",
"Frank",
"Carolyn",
"Raymond",
"Janet",
"Jack",
"Maria",
"Dennis",
"Catherine",
"Jerry",
"Heather"};

        public string GenerateName()
        {
            var randInd = mRand.Next(0, mNames.Count());

            return mNames.ElementAt(randInd);
        }
    }
}