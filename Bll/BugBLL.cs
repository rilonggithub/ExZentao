using System;
using System.Collections.Generic;
using System.Linq;
using Chloe;
using Model;

namespace Bll
{
    public class ZTBugBLL
    {
        public List<Model.ZT_Bug> GetAllBug(int project,string action,int count)
        {
            try
            {
                var list= DataContent.Context().SqlQuery<ZT_Bug>(
                        "select ac.objectID as BugId, p.`name` as ProjectName,case when ac.action='opened' THEN '创建'  when ac.action='assigned' THEN concat('分配给:',u2.realname)  when ac.action='resolved' THEN concat('解决为:',ac.extra)  when ac.action='activated' THEN '激活' when ac.action='closed' THEN '关闭' when ac.action='bugconfirmed' THEN '确认' when ac.action='edited' THEN '编辑'  END as Action,b.title as BugName,ac.date as Date,u.realname as Actor,ac.Comment from zt_action ac "+
                        "join zt_bug b on ac.objectID=b.id "+
                        "join zt_project p on ac.project=p.id "+
                        "join zt_user u on ac.actor=u.account left join zt_user u2 on ac.extra=u2.account "+
                        "where objectID in  ("+
                        "select a.objectID from zt_action a "+
                        "where a.project= @project "+
                        "and a.objectType='bug' "+
                        "and a.action= @action "+
                        "GROUP BY a.objectID,a.action "+
                        "HAVING count(a.action)> @count "+
                        "ORDER BY a.objectID) "+ 
                        "order by objectID,date;", 
                        new DbParam[] {
                        DbParam.Create("@project", project.ToString()),
                        DbParam.Create("@action", action),
                        DbParam.Create("@count", count.ToString())
                    }).ToList();
                //补充分组记录数
                foreach(var b in list)
                {
                    b.GroupByCount = list.Where(g=>g.BugId==b.BugId).Count();
                }

                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}