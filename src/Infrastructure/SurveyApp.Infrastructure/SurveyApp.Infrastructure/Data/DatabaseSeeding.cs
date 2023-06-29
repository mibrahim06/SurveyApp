using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Data;

public static class DatabaseSeeding
{
    public static void Seed(SurveyDbContext dbContext)
    {
        SeedUsers(dbContext);
        SeedSurveys(dbContext);
        SeedQuestions(dbContext);
    }

    private static void SeedUsers(SurveyDbContext dbContext)
    {
        if (!dbContext.Users.Any())
        {
            var user1 = new User
            {
                Name = "Mustafa Ibrahim",
                NameIdentifier = "Mustafa",
                UserName = "musibra",
                Password = "12345zxcv",
                Role = "Admin",
                Provider = "Cookies",
                Email = "test@gmail.com",
                CreatedAt = DateTime.Now
            };

            var user2 = new User
            {
                Name = "Can",
                NameIdentifier = "kaya",
                UserName = "ckaya",
                Password = "123",
                Role = "User",
                Provider = "Cookies",
                Email = "test2@gmail.com",
                CreatedAt = DateTime.Now
            };
        
            var _users = new List<User> {user1, user2};
            dbContext.Users.AddRange(_users);
            dbContext.SaveChanges();
        }
    }

    private static void SeedSurveys(SurveyDbContext dbContext)
    {
        if (!dbContext.Surveys.Any())
        {
            var survey1 = new Survey()
            {
                Name = "Survey 1",
                UserId = 1
            };
            
            var survey2 = new Survey()
            {
                Name = "Survey 2",
                UserId = 2
            };
            
            var survey3 = new Survey()
            {
                Name = "Survey 3",
                UserId = 1
            };
            
            var _surveys = new List<Survey> {survey1, survey2, survey3};
            dbContext.Surveys.AddRange(_surveys);
            dbContext.SaveChanges();
        }
    }

    private static void SeedQuestions(SurveyDbContext dbContext)
    {
        if (!dbContext.Questions.Any())
        {
            var questions1 = new Question()
            {
                Text = "Question 1?",
                SurveyId = 1,
                Type = QuestionType.SingleChoice
            };
            var questions2 = new Question()
            {
                Text = "Question 2?",
                SurveyId = 1,
                Type = QuestionType.SingleChoice
            };
            var questions3 = new Question()
            {
                Text = "Question 3?",
                SurveyId = 2,
                Type = QuestionType.SingleChoice
            };
            var questions = new List<Question> {questions1, questions2, questions3};
            dbContext.Questions.AddRange(questions);
            dbContext.SaveChanges();
        }
    }
}