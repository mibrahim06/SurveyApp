using AutoMapper;
using SurveyApp.DataTransferObjects.Incoming;
using SurveyApp.DataTransferObjects.Outgoing;
using SurveyApp.Entities;

namespace SurveyApp.Services.Mappings;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Survey, SurveyDisplayResponse>();
        CreateMap<Survey, UpdateSurveyRequest>();
    }
}