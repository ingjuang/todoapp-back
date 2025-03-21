
using MediatR;
using TodoApp_Back.Domain.Entities;
using TodoApp_Back.Util.Responses;

namespace TodoApp_Back.Application.Commands
{
    public record CreateTaskCommand(TaskEntity Task) : IRequest<PetitionResponse>;

}
