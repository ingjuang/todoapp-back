using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp_Back.Util.Responses;

namespace TodoApp_Back.Application.Commands
{
    public record DeleteTaskCommand(Guid Id) : IRequest<PetitionResponse>;

}
