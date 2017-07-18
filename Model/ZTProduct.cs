namespace Model
{
    using System;
    public class ZT_Product
    {
        public ZT_Product(int productId,string productName)
        {
            this.Id=productId;
            this.Name=productName;
        }
        public ZT_Product(){}
        public int Id {get;set;}
        public string Name{get;set;}
    }
}