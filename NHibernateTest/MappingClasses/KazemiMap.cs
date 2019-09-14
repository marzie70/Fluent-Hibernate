using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibernateTest.DomainClasses;

namespace NHibernateTest.MappingClasses
{
    class KazemiMap : IAutoMappingOverride<Kazemi>
    {
        public void Override(AutoMapping<Kazemi> mapping)
        {
            mapping.Id(m => m.Id);
            mapping.Map(m => m.Name);

        }
    }
}
