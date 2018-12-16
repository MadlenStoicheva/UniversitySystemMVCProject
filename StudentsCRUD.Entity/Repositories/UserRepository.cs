using StudentsCRUD.Entity.Context;
using StudentsCRUD.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCRUD.Entity.Repositories
{
    public class UserRepository :Repository<Person>
    {
        //private System.Data.Entity.DbContext db;

        //private System.Data.Entity.DbSet<T> dbSet;

        //public UserRepository()
        //{
        //    db = new SchoolDBContext();
        //    dbSet = db.Set<T>();
        //}

        //public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
        //{
        //    List<T> objects = new List<T>();
        //    foreach (Type type in
        //        Assembly.GetAssembly(typeof(T)).GetTypes()
        //        .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
        //    {
        //        objects.Add((T)Activator.CreateInstance(type, constructorArgs));
        //    }
        //    objects.Sort();
        //    return objects;
        //}

        //IEnumerable<Person> lis = db.Database..Select(x => x.CodeProductParamId).ToList();
        //var q = Products.Select(
        //        x => new daoClass
        //        {
        //            p = x,
        //            cs = x.ProductParams.Where(y => lis.Contains(y.Id))
        //        }
        //    ).Where(y => y.cs.Count() == lis.Count()).
        //    SelectMany(y => y.p).
        //    ToList();

        // List<Person> people = new List<Person>();
        //public List<Person> GetAll(Person person)
        // {
        //     return dbSet.Select(
        // }
    }
}
