using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bll;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new Bll.ZTProductBLL().GetAllProduct();
            var project=new Bll.ZTProjectBLL().GetProjectByProductId(products.FirstOrDefault().Id);
            
            ViewBag.BugList=new Bll.ZTBugBLL().GetAllBug(project.FirstOrDefault().Id,"closed",1);
            ViewBag.Products=InitialProductSelItem(products);
            ViewBag.Projects=InitialProjectSelItem(products.FirstOrDefault().Id,project);
            ViewBag.Action=InitialActionSelItem();
            ViewBag.ActionCount=InitialActionCount();
            return View();
        }

        private List<SelectListItem> InitialProductSelItem(List<Model.ZT_Product> products)
        {
            List<SelectListItem> ProductSelItem = new List<SelectListItem>();
            foreach( var pro in products )
            {
                ProductSelItem.Add( new SelectListItem { Selected = false , Text = pro.Name , Value = pro.Id.ToString() } );
            }
            return ProductSelItem;
        }

        private List<SelectListItem> InitialActionSelItem()
        {
            List<SelectListItem> ActionSelItem = new List<SelectListItem>();
            
            ActionSelItem.Add( new SelectListItem { Selected = false , Text = "关闭" , Value = "closed" } );
            ActionSelItem.Add( new SelectListItem { Selected = false , Text = "解决" , Value = "resolved" } );
            
            return ActionSelItem;
        }
        private List<SelectListItem> InitialActionCount()
        {
            List<SelectListItem> ActionSelItem = new List<SelectListItem>();
            
            ActionSelItem.Add( new SelectListItem { Selected = false , Text = "等于1次" , Value = "1" } );
            ActionSelItem.Add( new SelectListItem { Selected = false , Text = "等于2次" , Value = "2" } );
            ActionSelItem.Add( new SelectListItem { Selected = false , Text = "等于3次" , Value = "3" } );
            
            return ActionSelItem;
        }


        private List<SelectListItem> InitialProjectSelItem(int product,List<Model.ZT_Project> projects)
        {
            List<SelectListItem> ProjectSelItem = new List<SelectListItem>();
            foreach( var pro in projects )
            {
                ProjectSelItem.Add( new SelectListItem { Selected = false , Text = pro.Name , Value = pro.Id.ToString() } );
            }
            return ProjectSelItem;
        }
        
         public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

         [HttpGet]
        public JsonResult GetProjectDataByProductId(int product)
        {
            var projects = new Bll.ZTProjectBLL().GetProjectByProductId(product);
            return Json(new{success=true,Json=projects}) ;
        }

        [HttpGet]
        public JsonResult GetBugDataByQuery(int project,string act,int count)
        {
            var bugs = new Bll.ZTBugBLL().GetAllBug(project,act,count);
            return Json(new{success=true,Json=bugs}) ;
        }

        [HttpGet]
        public JsonResult GetBugDataByChart(int project,string act)
        {
            int[] count=new int [3];
            if(act.ToLower().Equals("closed")){
                count[0]=new Bll.ZTBugBLL().GetBugCountByOneClosed(project);
                count[1]=new Bll.ZTBugBLL().GetBugCountByTwoClosed(project);
                count[2]=new Bll.ZTBugBLL().GetBugCountByThreeAndMoreClosed(project);
            }else if(act.ToLower().Equals("resolved")){
                count[0]=new Bll.ZTBugBLL().GetBugCountByOneResolved(project);
                count[1]=new Bll.ZTBugBLL().GetBugCountByTwoResolved(project);
                count[2]=new Bll.ZTBugBLL().GetBugCountByThreeAndMoreResolved(project);
            }
            return Json(new{success=true,Json=count}) ;
        }
    }
}