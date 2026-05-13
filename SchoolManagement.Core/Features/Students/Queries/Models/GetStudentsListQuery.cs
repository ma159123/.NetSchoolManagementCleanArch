using SchoolManagement.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Students.Queries.Models
{
    public class GetStudentsListQuery: IRequest<Response<List<GetStudentsListResponse>>>
    {

    }
}
