
using Mock2.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Mock2.Server.IRepository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Mock2.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Mtask> Mtasks { get; }
    }
}