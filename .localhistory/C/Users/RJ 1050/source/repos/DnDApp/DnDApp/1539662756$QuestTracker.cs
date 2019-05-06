using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace DnDApp
{
    public class QuestTracker
    {
        private QuestTracker instance;
        private QuestTracker Instance
        {
            get
            {
                if(instance == null)
                    instance = new QuestTracker();
                return instance;
            }
        }

        Quest[] quests;

        private QuestTracker()
        {
            string[] questFiles = Directory.GetFiles("C:/YGOPRO/Quests")
        }
    }
}