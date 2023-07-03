using System.Security.AccessControl;
using AutoMapper;
using SurveyApp.DataTransferObjects.Incoming;
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
    
    public IEnumerable<SurveyDisplayResponse> GetSurveyDisplayResponsebByUserId(int userId)
    {
        var surveys = _surveyRepository.GetSurveysByUserId(userId).Result;
        var surveyDisplayResponses = _mapper.Map<IEnumerable<SurveyDisplayResponse>>(surveys);
        return surveyDisplayResponses;
    }

    public UpdateSurveyRequest GetUpdateSurveyRequestById(int id)
    {
        var survey =  _surveyRepository.GetByIdAsync(id).Result;
        var updateSurveyRequest = _mapper.Map<UpdateSurveyRequest>(survey);
        return updateSurveyRequest;
    }

    public async Task<IList<Survey>> GetSurveysByUsername(string username)
    {
        var surveys = await _surveyRepository.GetAllAsync();
        var surveysByUsername =  surveys.Where(x => x.User.UserName == username).ToList();
        return surveysByUsername;
    }

    public async Task<List<Question>> GetQuestionsBySurveyId(int surveyId)
    {
        var questions = await _surveyRepository.GetQuestionsBySurveyId(surveyId);
        return questions;
    }

    public async Task<Survey> GetSurveyById(int id)
    {
        var survey = await _surveyRepository.GetByIdAsync(id);
        return survey;
    }
}