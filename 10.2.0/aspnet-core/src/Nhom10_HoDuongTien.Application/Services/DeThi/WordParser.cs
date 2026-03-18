using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.Linq;

namespace Nhom10_HoDuongTien.Application.Services.DeThi
{
    public class WordParser
    {
        public List<QuestionDto> Parse(string filePath)
        {
            var lines = ReadAllLines(filePath);
            var questions = new List<QuestionDto>();

            QuestionDto current = null;

            foreach (var raw in lines)
            {
                var line = raw.Trim();

                if (string.IsNullOrEmpty(line))
                    continue;

                if (line.StartsWith("[Q:"))
                {
                    current = new QuestionDto
                    {
                        Content = "",
                        Answers = new List<AnswerDto>()
                    };

                    questions.Add(current);
                    continue;
                }

                if (current == null)
                    continue;

                if (line.StartsWith("[A]"))
                {
                    current.Answers.Add(new AnswerDto
                    {
                        Key = "A",
                        Content = line.Substring(3).Trim()
                    });
                }
                else if (line.StartsWith("[B]"))
                {
                    current.Answers.Add(new AnswerDto
                    {
                        Key = "B",
                        Content = line.Substring(3).Trim()
                    });
                }
                else if (line.StartsWith("[C]"))
                {
                    current.Answers.Add(new AnswerDto
                    {
                        Key = "C",
                        Content = line.Substring(3).Trim()
                    });
                }
                else if (line.StartsWith("[D]"))
                {
                    current.Answers.Add(new AnswerDto
                    {
                        Key = "D",
                        Content = line.Substring(3).Trim()
                    });
                }
                else if (line.StartsWith("[KEY:"))
                {
                    current.CorrectAnswer = line
                        .Replace("[KEY:", "")
                        .Replace("]", "")
                        .Trim();
                }
                else
                {
                    current.Content += line + "\n";
                }
            }

            return questions;
        }

        public List<string> ReadAllLines(string filePath)
        {
            var result = new List<string>();

            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
            {
                var paragraphs = doc.MainDocumentPart.Document.Body.Elements<Paragraph>();

                foreach (var para in paragraphs)
                {
                    var text = para.InnerText;

                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        result.Add(text.Trim());
                    }
                }
            }

            return result;
        }
    }
}