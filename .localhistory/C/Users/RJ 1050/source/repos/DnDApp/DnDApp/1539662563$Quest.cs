using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Linq;
using System.Text;

public class Quest
{
    public string questName = "";
    public string visableName = "";
    public bool active = true;
    public bool debugActive = false;
    public bool complete = false;
    public bool IsActive
    {
        get
        {
            if(currentPhase < 0)
                return false;
            return active;
        }
    }
    public int currentPhase = -1;

    public List<QuestPhase> phases = new List<QuestPhase>();

    public string GetHTML(bool isLocalHost = false)
    {
        if(!IsActive && !(isLocalHost && debugActive))
            return "<!--" + questName + " is hidden-->";
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!--" + questName + "-->");
            sb.AppendLine("<h1 style=\"color:#8B0000\">" + visableName + "</h1>");
            //sb.Append("<button style=\"line-height:5px; text-indent:5%; margin-left:4%; background-color:#974502; "
            sb.AppendLine("<button style=\"line-height:5px;\ntext-indent:5%;\nmargin-left:4%;\nbackground-color:#8B0000;\n "
                + "border-bottom-color:#7e3a02;\nborder-left-color:#7e3a02;\nborder-top-color:#7e3a02;\nborder-right-color:#7e3a02;\"\n"
                + "type=\"button\"\nclass=\"btn btn-info\"\ndata-toggle=\"collapse\"\ndata-target=\"#"
                + questName
                + "\">Show/Hide</button>");
            sb.AppendLine("<p>");
            sb.AppendLine("<div id=\"" + questName + "\" class=\"collapse\">");
            phases.Sort((x, y) => x.sortingID.CompareTo(y.sortingID));
            foreach(var phase in phases)
            {
                if(!EvaluatePhase(phase))
                    continue;
                sb.AppendLine("<h3 style=\"color:#8B0000\">∗ " + phase.objective + " ∗</h3>");
                var des = phase.description;
                des = des.Replace("\n", "</p><p>");
                sb.AppendLine("<p>" + des + "</p><br/>");
            }
            sb.AppendLine("</div>");
            sb.AppendLine("</p>");
            return sb.ToString();
        }
    }

    public bool EvaluatePhase(QuestPhase phase)
    {
        if(phase.invisable)
            return false;
        if(phase.forceActive)
            return true;
        if(currentPhase == 0 && phase.phaseID == 0)
            return true;
        return phase.phaseID > 0 && currentPhase >= phase.phaseID;
    }
}