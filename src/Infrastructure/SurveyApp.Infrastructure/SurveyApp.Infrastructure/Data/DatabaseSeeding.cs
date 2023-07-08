using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Data;

public static class DatabaseSeeding
{
    public static void Seed(SurveyDbContext dbContext)
    {
        SeedUsers(dbContext);
        SeedSurveys(dbContext);
        SeedQuestions(dbContext);
        SeedOptions(dbContext);
        SeedAnswers(dbContext);
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
                Title = "Hangi programlama dillerini kullandiniz?",
                SurveyId = 1,
                OptionType = OptionType.MultipleChoice
            };
            var questions2 = new Question()
            {
                Title = "En iyi kulladiginiz programlama dili?",
                SurveyId = 1,
                OptionType = OptionType.SingleChoice
            };
            var questions3 = new Question()
            {
                Title = "Question 3?",
                SurveyId = 2,
                OptionType = OptionType.Rating
            };
            var questions4 = new Question()
            {
                Title = "Python programlama dilini hangi derecede biliyorsunuz?",
                SurveyId = 1,
                OptionType = OptionType.Rating
            };
            var questions5 = new Question()
            {
                Title = "Eklemek istedikleriniz?",
                SurveyId = 1,
                OptionType = OptionType.Text
            };
            
            var questions = new List<Question> {questions1, questions2, questions3, questions4, questions5};
            dbContext.Questions.AddRange(questions);
            dbContext.SaveChanges();
        }
    }
    
    private static void SeedOptions(SurveyDbContext dbContext)
    {
        if (!dbContext.Options.Any())
        {
            var option1 = new Option()
            {
                QuestionId = 1,
                Text = "java"
            };
            var option2 = new Option()
            {
                QuestionId = 1,
                Text = "python"
            };
            
            var option3 = new Option()
            {
                QuestionId = 2,
                Text = "python"
            };
            
            var option4 = new Option()
            {
                QuestionId = 2,
                Text = "java"
            };
            
            var answers = new List<Option> {option1, option2, option3, option4};
            
            dbContext.Options.AddRange(answers);
            dbContext.SaveChanges();
        }
    }

    private static void SeedAnswers(SurveyDbContext dbContext)
    {
        if (!dbContext.Answers.Any())
        {
            var answer1 = new Answer()
            {
                QuestionId = 1,
                Text = "java"
            };
            var answer5 = new Answer()
            {
                QuestionId = 1,
                Text = "python"
            };

            var answer2 = new Answer()
            {
                QuestionId = 2,
                Text = "python"
            };
            var answer3 = new Answer()
            {
                QuestionId = 4,
                Text = "5"
                
            };
            var answer4 = new Answer()
            {
                QuestionId = 5,
                Text = "test"
            };

            var answers = new List<Answer> { answer1, answer2, answer3, answer4, answer5};

            dbContext.Answers.AddRange(answers);
            dbContext.SaveChanges();
        }
    }
}