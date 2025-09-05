using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRaptor.Mediator.Abstractions
{
    /// <summary>
    /// Mediator interface
    /// </summary>
    public interface IMediator : ISender, IPublisher
    {
    }
}
