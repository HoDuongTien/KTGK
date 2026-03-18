using System.Collections.Generic;

namespace Nhom10_HoDuongTien.Application.Services.DeThi
{
    public class QuestionDto
    {
        public string Content { get; set; } = "";
        public string CorrectAnswer { get; set; } = "";
        public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    }

    public class AnswerDto
    {
        public string Key { get; set; } = "";
        public string Content { get; set; } = "";
    }
}