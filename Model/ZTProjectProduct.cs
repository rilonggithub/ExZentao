namespace Model
{
    using System;
    public class ZT_ProjectProduct
    {
        public ZT_ProjectProduct(int productId,int projectId)
        {
            this.Product=productId;
            this.project=projectId;
        }
        public ZT_ProjectProduct(){}
        public int Product {get;set;}
        public int project{get;set;}
    }
}