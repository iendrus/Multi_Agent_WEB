using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.Mapping
{
    internal interface IMapFrom<T>
    {
        //metoda Mapping będzie przekazywac jako parametr obiekt klasy Profile, który będzie tworzył mapowania
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
