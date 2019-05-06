using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Serialization;

namespace DnDApp
{
    public class QuestTracker
    {
        private static QuestTracker instance;
        private static QuestTracker Instance
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
            string[] questFiles = Directory.GetFiles("C:/YGOPRO/DnD/Quest", "*.xml");
            quests = new Quest[questFiles.Length];
            XmlSerializer ser = new XmlSerializer(typeof(Quest));
            for(int i = 0; i < questFiles.Length; i++)
            {
                using(var stream = File.Open(questFiles[i], FileMode.Open))
                {
                    quests[i] = ser.Deserialize(stream) as Quest;
                }
            }
        }

        public static Quest[] GetQuests()
        {
            return Instance.quests;
        }
    }
}