namespace Model
{
    using System;
    public class ZT_Project
    {
        public ZT_Project(int projectId,string projectName)
        {
            this.Id=projectId;
            this.Name=projectName;
        }
        public ZT_Project(){}
        public int Id {get;set;}
        public string Name{get;set;}
    }
}