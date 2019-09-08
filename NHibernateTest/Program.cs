using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine("Kazemi Created: " + kazemi.Name);
                }

                Console.ReadKey();
            }

        }
    }
}
