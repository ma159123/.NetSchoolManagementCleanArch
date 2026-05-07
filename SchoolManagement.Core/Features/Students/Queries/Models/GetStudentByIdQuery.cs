using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery :IRequest<Response<GetStudentResponse>>
    {
       public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
