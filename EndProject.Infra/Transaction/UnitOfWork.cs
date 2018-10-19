using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndProject.Infra.Persistence;

namespace EndProject.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EndProjectContext _context;

        public UnitOfWork(EndProjectContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
