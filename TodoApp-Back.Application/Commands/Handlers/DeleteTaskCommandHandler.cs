using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp_Back.Application.Services.Interfaces;
using TodoApp_Back.Util.Responses;

namespace TodoApp_Back.Application.Commands.Handlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, PetitionResponse>
    {
        private readonly ITaskService _taskService;

        public DeleteTaskCommandHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<PetitionResponse> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            return await _taskService.DeleteAsync(request.Id);
        }
    }
}
