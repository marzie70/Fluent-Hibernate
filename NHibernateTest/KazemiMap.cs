using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibernate.Mapping;

namespace NHibernateTest
{
    public class KazemiMap : IAutoMappingOverride<Kazemi>
    {
        public void Override(AutoMapping<Kazemi> mapping)
        {
            mapping.Id(c => c.Id);
            mapping.Map(c => c.Name);

        }
    }
}
