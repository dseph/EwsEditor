using System;
using System.Collections.Generic;
//using System.Management.Automation;
//using System.Management.Automation.Remoting;
//using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections;
using System.Diagnostics;

namespace MeetingAnalyzer
{
    public class MsgData
    {
        // Everything dealing with importing and sorting the PS message data objects is here

        private static DataSet m_DS;
        public static DataSet msgDataSet { get { return m_DS; } }
        private static int tblNum = 0;

        public static string m_GOID = "";

        public MsgData()
        {
            InitializeDataSet();
        }

        //// Grab all the message props and put them in a table. Each table is one message with properties.
        //public static void PopulateDataSet(PSObject message)
        //{
        //    DataTable dt = m_DS.Tables.Add("tblMsg_" + tblNum.ToString());
        //    dt.Columns.Add("PropName");
        //    dt.Columns.Add("PropVal");
        //    dt.Columns.Add("SmartVal");
        //    tblNum++;
        //    string strARHEXFile = Utils.m_AppPath + "ARHEX.txt";
        //    string strARCVTFile = Utils.m_AppPath + "ARCVT.txt";

        //    foreach (PSMemberInfo property in message.Members)
        //    {
        //        DataRow dr = dt.NewRow();
        //        string strPropVal = "";
        //        string strSmartVal = "";

        //        if (property.Value.ToString().Contains("NotFound"))
        //        {
        //            strPropVal = "";
        //        }
        //        else
        //        {
        //            strPropVal = property.Value.ToString();
        //        }

        //        // If the recurBlob then run MrMapi to convert it to useable text
        //        if (property.Name == "AppointmentRecurrenceBlob")
        //        {
        //            if (!(string.IsNullOrEmpty(strPropVal)))
        //            {
        //                // Do MrMapi stuff...
        //                File.WriteAllText(strARHEXFile, strPropVal);
        //                File.WriteAllText(strARCVTFile, "");

        //                Utils.RunMrMAPI(string.Format("-p 2 -i \"{0}\" -o \"{1}\"", strARHEXFile, strARCVTFile));

        //                StreamReader srIn = new StreamReader(strARCVTFile);
        //                string strLine = "";
        //                while ((strLine = srIn.ReadLine()) != null)
        //                {
        //                    strSmartVal += strLine + "\r\n";
        //                }
        //                srIn.Close();
        //            }
        //        }

        //        dr["PropName"] = property.Name;
        //        dr["PropVal"] = strPropVal;
        //        dr["SmartVal"] = strSmartVal;

        //        dt.Rows.Add(dr);

        //        File.Delete(strARHEXFile);
        //        File.Delete(strARCVTFile);
        //    }
        //    // Pull Mod Time for sorting. First try to get OrigLastModTime. 
        //    // This is the one we really want to use for creating the timeline.
        //    DataRow[] modTimeRows = dt.Select("PropName = 'OriginalLastModifiedTime'");
        //    if (modTimeRows.Length > 0)
        //    {
        //        dt.ExtendedProperties.Add("OrigModTime", DateTime.Parse(modTimeRows[0]["PropVal"].ToString()));
        //    }
        //    else // if OrigLastModTime isn't there then use LastModTime - not as good if we must use this.
        //    {
        //        modTimeRows = dt.Select("PropName = 'LastModifiedTime'");
        //        if (modTimeRows.Length > 0)
        //        {
        //            dt.ExtendedProperties.Add("OrigModTime", DateTime.Parse(modTimeRows[0]["PropVal"].ToString()));
        //        }
        //    }

        //    // Pull GOID to ensure there is only one GOID for the meeting being pulled for analysis
        //    DataRow[] GOIDrows = dt.Select("PropName = 'CleanGlobalObjectId'");
        //    if (GOIDrows.Length > 0)
        //    {
        //        if (m_GOID == "") // must be the first one so then add the GOID value to the global
        //        {
        //            m_GOID = GOIDrows[0]["PropVal"].ToString();
        //        }
        //        else if (m_GOID != GOIDrows[0]["PropVal"].ToString()) // now check each one to make sure they are all the same
        //        {
        //            Console.WriteLine("\r\nMultiple CleanGlobalObjectIds detected. There are probably multiple meetings with the same subject being returned.");
        //            Console.WriteLine("Try running this tool again and choose to enter the Meeting ID with one of the IDs below:");
        //            Console.WriteLine(m_GOID);
        //            Console.WriteLine(GOIDrows[0]["PropVal"].ToString());
        //            return;
        //        }
        //    }
        //}

        // Sort the tables (messages) by the Modified Time
        public static DataSet dsSort(DataSet ds, String strSortBy)
        {
            DataSet dsSorted = ds.Clone(); // copy the existing table
            dsSorted.Tables.Clear(); // clear out the values

            // make a new table and put two columns in it for sorting
            DataTable dtSort = new DataTable();
            dtSort.Columns.Add(strSortBy, Type.GetType("System.DateTime"));
            dtSort.Columns.Add("Index", Type.GetType("System.Int32"));

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                dtSort.Rows.Add((DateTime)ds.Tables[i].ExtendedProperties[strSortBy], i);
            }

            dtSort.DefaultView.Sort = strSortBy;

            // Then copy the tables (messages) into the new data set sorted by modified time
            foreach (DataRow drSort in dtSort.DefaultView.ToTable().Rows)
            {
                DataTable dt = ds.Tables[(int)drSort["Index"]];
                dsSorted.Tables.Add(dt.Copy());
            }

            return dsSorted;
        }

        // Get the value for a given property
        public static string GetProp(DataTable dt, string strPropName, string strPropVal = "PropVal")
        {
            DataRow[] drMatch = dt.Select(string.Format("PropName LIKE '%{0}%'", strPropName));
            if (drMatch.Length > 0)
            {
                return drMatch[0][strPropVal].ToString();
            }
            return null;
        }

        // Create the dataset for use
        private void InitializeDataSet()
        {
            m_DS = new DataSet();
        }
    }
}