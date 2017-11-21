using System.Collections.Generic;
using System.Data;

public class clsReport
{
    public string Fname { get; set; }
    public string Lname { get; set; }
    public string Tname { get; set; }
    public string Room { get; set; }
    public string Ginfo { get; set; }
    public string RptDate { get; set; }
    public string AbsDate { get; set; }
    public string Reason { get; set; }

    public clsRept(){ }
    
    public clsReport(string fname, string lname, string tname, string room, string ginfo, string rptdate, string absdate, string reason)
    {
        Fname = fname;
        Lname = lname;
        Tname = tname;
        Room = room;
        Ginfo = ginfo;
        RptDate = rptdate;
        AbsDate = absdate;
        Reason = reason;
    }

    //This method returns today's absentee information
    public List<clsRept> getAbsenteeToday(string room)
    {
        List<clsRept> rptInfo = new List<clsRept>();

        IStorageAgent agt = new clsStorageAgent();
        var con = agt.GetStorageConnection();
        DataTable dtAbsentee = agt.GetData(con, "sp_select_absentee_today");


        if (dtAbsentee != null)
        {
            foreach (DataRow r in dtAbsentee.Rows)
            {
                string fname = r[1].ToString();
                string lname = r[2].ToString();
                string tname = r[3].ToString();
                string rm = r[4].ToString();
                string ginfo = r[5].ToString();
                string rptDate = r[6].ToString();
                string absDate = r[7].ToString();
                string reason = r[8].ToString();

                clsRept rpt = new clsRept(fname, lname, tname, rm, ginfo, rptDate, absDate, reason);
                rptInfo.Add(rpt);

            }

            dtAbsentee.Clear();
            dtAbsentee.Dispose();
        }

        else
        {
            rptInfo = null;
        }

        agt.CloseStorageConnection(con);
        return rptInfo;
    }

}
