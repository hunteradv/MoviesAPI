﻿using AutoMapper;
using MoviesAPI.Data.Dtos.Addresses;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>();
            CreateMap<Address, ReadAddressDto>();
        }
    }
}
