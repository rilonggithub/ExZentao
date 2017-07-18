namespace Model
{
    using System;
    public class ZT_Bug
    {
        public ZT_Bug(string projectName,
        int bugId,
        int count,
        string actor,
        string bugName,
        string comment,
        DateTime date)
        {
            this.ProjectName=projectName;
            this.BugId=bugId;
            this.Actor=actor;
            this.BugName=bugName;
            this.Date=date;
            this.GroupByCount=count;
            this.Comment=comment;
        }
        public ZT_Bug(){}
        public int BugId {get;set;}
        public int GroupByCount {get;set;}
        public string ProjectName{get;set;}
        public string Action{get;set;}
        public string Actor{get;set;}
        public string BugName{get;set;}
        public DateTime Date{get;set;}
        public string Comment{get;set;}
    }
}