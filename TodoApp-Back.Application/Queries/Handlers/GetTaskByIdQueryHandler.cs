using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp_Back.Application.Services.Interfaces;
using TodoApp_Back.Util.Responses;

namespace TodoApp_Back.Application.Queries.Handlers
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, PetitionResponse>
    {
        private readonly ITaskService _taskService;

        public GetTaskByIdQueryHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<PetitionResponse> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _taskService.GetByIdAsync(request.Id);
        }
    }
}
