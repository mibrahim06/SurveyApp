using System.Security.AccessControl;
using AutoMapper;
using SurveyApp.DataTransferObjects.Outgoing;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services;

public class SurveyService : ISurveyService
{
    private readonly IMapper _mapper;
    private readonly ISurveyRepository _surveyRepository;
    public SurveyService(IMapper mapper, ISurveyRepository surveyRepository)
    {
        _mapper = mapper;
        _surveyRepository = surveyRepository;
    }
    public IEnumerable<SurveyDisplayResponse> GetSurveyDisplayResponses()
    {
        var surveys = _surveyRepository.GetAllAsync().Result;
        var surveyDisplayResponses = _mapper.Map<IEnumerable<SurveyDisplayResponse>>(surveys);
        return surveyDisplayResponses;
    }
}