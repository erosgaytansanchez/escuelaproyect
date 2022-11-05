using AutoMapper;
using WebApiAutoresClase.DTOs;
using WebApiAutoresClase.Models;

namespace WebApiAutoresClase.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProfesorCreacionDTO, Profesor>();
            CreateMap<Profesor, ProfesorDTO>();
               
        }
       
    }
}