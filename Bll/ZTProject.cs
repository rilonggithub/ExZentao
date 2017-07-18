using System;
using System.Collections.Generic;

namespace Bll
{
    public class ZTProjectBLL
    {
        public List<Model.ZT_Project> GetProjectByProductId(int id)
        {
            try
            {
                var projectIds= DataContent.Context().Query<Model.ZT_ProjectProduct>()
                .Where(p=>p.Product==id).Select(p=>p.project).ToList();

                return DataContent.Context().Query<Model.ZT_Project>()
                .Where(p=>projectIds.Contains(p.Id)).OrderBy(o=>o.Name).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}