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
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, PetitionResponse>
    {
        private readonly ITaskService _taskService;

        public GetAllTasksQueryHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<PetitionResponse> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _taskService.GetAllAsync();
        }
    }
}
