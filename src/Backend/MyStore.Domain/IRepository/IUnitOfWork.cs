using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository
{
    public interface IUnitOfWork
    {
        public Task Commit(); 
    }
}
