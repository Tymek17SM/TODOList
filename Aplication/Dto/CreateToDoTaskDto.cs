using Aplication.Mappings;
using AutoMapper;
using Domain.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dto
{
    public class CreateToDoTaskDto : IMap
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DeadLine { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateToDoTaskDto, ToDoTask>();
        }
    }
}
