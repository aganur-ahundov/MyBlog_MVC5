using System;
using System.Linq;
using System.Collections.Generic;
using EpamBlog.Models.Repository;
using EpamBlog.Models.QuizModels;

namespace EpamBlog.SiteLogic
{
    public class StatisticManager
    {
        private Repository repository = new Repository();


        public StatisticViewModel GetQuestionStatistic(MultipleChoiceQuestion _question)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            double totalCount = 0;
            foreach (Variable var in _question.Variables)
            {
                int count = repository.MultipleChoiseAnswers.Where(a => a.Answer == var.Text).Count();
                result[var.Text] = count;
                totalCount += count;
            }

            return new StatisticViewModel { Title = _question.QuestionText, Data = result, PersentPerPoint = (100.0 / totalCount) };

        }
    }
}