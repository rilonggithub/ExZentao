namespace Model
{
    public class Person
    {
        public Person(string name,int age,string username,string password)
        {
            this.Name=name;
            this.Age=age;
            this.UserName=username;
            this.PassWord=password;
        }
        public Person(){}
        public int id {get;set;}
        public string Name{get;set;}
        public int Age{get;set;}
        public string UserName{get;set;}
        public string PassWord{get;set;}
    }
}