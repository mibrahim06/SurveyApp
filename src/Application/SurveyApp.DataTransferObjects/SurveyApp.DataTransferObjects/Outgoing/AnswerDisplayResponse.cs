namespace SurveyApp.DataTransferObjects.Outgoing;

public class AnswerDisplayResponse
{
    public string Text { get; set; } = default!;
    public int Rating { get; set; }
    public List<int> MultipleChoice { get; set; }
    public int SingleChoice { get; set; }

}