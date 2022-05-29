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
    public class UpdateToDoTaskDto : IMap
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DeadLine { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateToDoTaskDto, ToDoTask>();
        }
    }
}
