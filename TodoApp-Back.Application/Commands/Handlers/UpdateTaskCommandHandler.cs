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
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, PetitionResponse>
    {
        private readonly ITaskService _taskService;

        public UpdateTaskCommandHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<PetitionResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _taskService.UpdateAsync(request.Task);
        }
    }
}
