
using AutoMapper;
using Library.BLL.DTOs.AddDto;
using Library.BLL.DTOs.AuthDto;
using Library.BLL.DTOs.GetDto;
using Library.BLL.DTOs.UpdateDto;
using Library.DAL.Models;

namespace Library.BLL.Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<User, AddUserDto>();
        CreateMap<AddUserDto, User>();
        CreateMap<SignInDto, User>();
        CreateMap<User, SignInDto>();
        CreateMap<Book, AddBookDto>();
        CreateMap<AddBookDto, Book>();
        CreateMap<Book, GetBookDto>();
        CreateMap<GetBookDto, Book>();
        CreateMap<Book, UpdateBookDto>();
        CreateMap<UpdateBookDto, Book>();

    }
}
