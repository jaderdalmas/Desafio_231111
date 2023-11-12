using API.Controllers;
using API.Models;
using AutoMapper;
namespace API.Configs;

public class MapperConfig
{
	public static Mapper InitializeAutomapper()
	{
		var config = new MapperConfiguration(cfg =>
		{
			cfg.CreateMap<CardModelRequest, CardModel>();
		});

		return new Mapper(config);
	}
}