using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernateTest.DomainClasses;

namespace NHibernateTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var kazemi = new Kazemi
                    {
                        Name = "Marzie"
                    };
                    session.Save(kazemi);
                    transaction.Commit();
                    Console.WriteLine("Kazemi Created: " + kazemi.Name + "\t" +
                                      kazemi.Id);
                }

                Console.ReadKey();
            }

        }
    }
}
