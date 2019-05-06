using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;

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
            string[] questFiles = Directory.GetFiles("C:/YGOPRO/DnD/Quests", "*.xml");
            quests = new Quest[questFiles.Length];

            for(int i = 0; i < questFiles[i].Length; i++)
            {
            }
        }
    }
}