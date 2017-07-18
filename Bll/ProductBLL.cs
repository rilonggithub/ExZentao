using System;
using System.Collections.Generic;

namespace Bll
{
    public class ZTProductBLL
    {
        public List<Model.ZT_Product> GetAllProduct()
        {
            try
            {
                return DataContent.Context().Query<Model.ZT_Product>().OrderBy(p=>p.Name).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}