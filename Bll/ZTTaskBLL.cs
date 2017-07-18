using System;
using System.Collections.Generic;

namespace Bll
{
    public class ZTTaskBLL
    {
        public List<Model.ZT_Task> GetAllTask()
        {
            try
            {
                return DataContent.Context().Query<Model.ZT_Task>()
                .Where(t=>t.Deadline > DateTime.Now.AddYears(-10)&& t.AssignedTo.Equals("gujinlong"))
                .ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}