using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DnDApp
{
    public class QuestPhase
    {
        public bool forceActive = false;
        public bool invisable = false;
        public string phaseName = "Phase";
        public int phaseID = 0;
        public int sortingID = 0;
        public string objective = "Do Something";
        public string description = "Just do the thing";
    }
}