using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            }
        }

        private QuestTracker()
        {

        }
    }
}