namespace QuizMG.Models.DTOs
{
    public class QuestionDto
    {
        public string QuestionText { get; set; }
        public int? QstNmb { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Answer { get; set; }
        public string ErrorMessage { get; set; } = "Choose right option";
        public bool AfterAnswer { get; set; } = false;
        public bool GoodAnswer { get; set; } = false;
        

    }
}
