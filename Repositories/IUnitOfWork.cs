using System;
using Microsoft.EntityFrameworkCore;

namespace DotNetVueBlog.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get;  }
        void Commit();
    }
}
