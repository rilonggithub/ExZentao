namespace Model
{
    using System;
    public class ZT_Task
    {
        public ZT_Task(string project,string status,string assignedTo,string name,DateTime deadline)
        {
            this.Project=project;
            this.Status=status;
            this.AssignedTo=assignedTo;
            this.Name=name;
            this.Deadline=deadline;
        }
        public ZT_Task(){}
        public int id {get;set;}
        public string Project{get;set;}
        public string Status{get;set;}
        public string AssignedTo{get;set;}
        public string Name{get;set;}
        public DateTime Deadline{get;set;}
    }
}