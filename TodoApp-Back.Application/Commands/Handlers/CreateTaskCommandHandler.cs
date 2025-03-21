using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp_Back.Application.Services.Interfaces;
using TodoApp_Back.Domain.Entities;
using TodoApp_Back.Domain.Repositories;
using TodoApp_Back.Util.Responses;

namespace TodoApp_Back.Application.Commands.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, PetitionResponse>
    {
        private readonly ITaskService _taskService;

        public CreateTaskCommandHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<PetitionResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _taskService.CreateAsync(request.Task);
        }
    }
}
