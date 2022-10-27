using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

using static Application.Activities.Detail;

namespace Application.Activities
{
    public class Detail
    {
        public class Query : IRequest<Result<ActivityDto>>
        {
            public Guid Id {get; set; }
        }
    }

    public class Handler : IRequestHandler<Query, Result<ActivityDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities
            .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x=> x.Id ==request.Id);

            // if(activity == null) throw new Exception("Activity not found");

            return Result<ActivityDto>.Success(activity);
        }
    }
}
