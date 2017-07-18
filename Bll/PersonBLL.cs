using System;
using System.Collections.Generic;

namespace Bll
{
    public class Person
    {
        public List<Model.Person> GetAllPerson()
        {
            return DataContent.Context().Query<Model.Person>().ToList();
        }
        public int AddPerson()
        {
            Random r=new Random(100);
            Model.Person p=new Model.Person(Guid.NewGuid().ToString(),r.Next(),Guid.NewGuid().ToString(),Guid.NewGuid().ToString());
            Model.Person presult = DataContent.Context().Insert<Model.Person>(p);
            return presult.id;
        }
        public int DelPerson(int id)
        {
            return DataContent.Context().Delete<Model.Person>((x)=>x.id==id);
        }
    }
}