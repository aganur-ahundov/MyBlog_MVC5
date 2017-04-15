using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using EpamBlog.Models.QuizModels;



namespace EpamBlog.Models.Context
{
    public class DbInitializer : /*DropCreateDatabaseAlways<BlogContext>*/ DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {

            AddTags(context);

            AddArticles(context);

            AddFeedback(context);

            AddMultipleQuestion(context);

            AddQuizzes(context);

            AddVariables(context);
            
            context.Textboxes.Add(new Textbox { QuizId = 1, Placeholder = "Enter your recommendation here.." });

            base.Seed(context);
        }



        private void AddQuizzes(BlogContext context)
        {
            context.Quiz.Add( new Quiz { Title = "MyQuiz" } );
            context.Quiz.Add( new Quiz { Title = "User Info" } );
        }

        private void AddMultipleQuestion(BlogContext context)
        {
            context.MultupleQuestion.Add(new MultipleChoiceQuestion { QuestionText = "How can you estimate my blog?", QuizId = 1, Type = MultipleQuestionType.Radio });
            context.MultupleQuestion.Add(new MultipleChoiceQuestion { QuestionText = "What topic do you like most of all?", QuizId = 1, Type = MultipleQuestionType.Checkbox });
            context.MultupleQuestion.Add(new MultipleChoiceQuestion { QuestionText = "How can you estimate last article?", QuizId = 1, Type = MultipleQuestionType.Radio });

            context.MultupleQuestion.Add( new MultipleChoiceQuestion { QuestionText = "What you think about site' design?", QuizId = 2, Type = MultipleQuestionType.Checkbox } );
            context.MultupleQuestion.Add( new MultipleChoiceQuestion { QuestionText = "Do you like site' structure?", QuizId = 2, Type = MultipleQuestionType.Radio } );
            context.MultupleQuestion.Add( new MultipleChoiceQuestion { QuestionText = "How often do you visit my blog?", QuizId = 2, Type = MultipleQuestionType.Radio });
            context.MultupleQuestion.Add( new MultipleChoiceQuestion { QuestionText = "How can you estimate blog' content?", QuizId = 2, Type = MultipleQuestionType.Radio });
            
        }

        private void AddVariables(BlogContext context)
        {
            context.Variables.Add(new Variable { QuestionId = 1, Text = "1" });
            context.Variables.Add(new Variable { QuestionId = 1, Text = "2" });
            context.Variables.Add(new Variable { QuestionId = 1, Text = "3" });
            context.Variables.Add(new Variable { QuestionId = 1, Text = "4" });
            context.Variables.Add(new Variable { QuestionId = 1, Text = "5" });


            context.Variables.Add(new Variable { QuestionId = 2, Text = "Programming" });
            context.Variables.Add(new Variable { QuestionId = 2, Text = "Design" });
            context.Variables.Add(new Variable { QuestionId = 2, Text = "Project Architecture" });


            context.Variables.Add(new Variable { QuestionId = 3, Text = "10" });
            context.Variables.Add(new Variable { QuestionId = 3, Text = "9" });
            context.Variables.Add(new Variable { QuestionId = 3, Text = "8" });
            context.Variables.Add(new Variable { QuestionId = 3, Text = "7" });
            context.Variables.Add(new Variable { QuestionId = 3, Text = "6" });


            context.Variables.Add(new Variable { QuestionId = 4, Text = "Serious" });
            context.Variables.Add(new Variable { QuestionId = 4, Text = "Bright" });
            context.Variables.Add(new Variable { QuestionId = 4, Text = "Boring" });
            context.Variables.Add(new Variable { QuestionId = 4, Text = "Creative" });
            context.Variables.Add(new Variable { QuestionId = 4, Text = "Dark" });

            context.Variables.Add(new Variable { QuestionId = 5, Text = "Yes" });
            context.Variables.Add(new Variable { QuestionId = 5, Text = "No" });
            context.Variables.Add(new Variable { QuestionId = 5, Text = "Not in all" });

            context.Variables.Add(new Variable { QuestionId = 6, Text = "First time" });
            context.Variables.Add(new Variable { QuestionId = 6, Text = "Everyday" });
            context.Variables.Add(new Variable { QuestionId = 6, Text = "Sometimes" });

            context.Variables.Add(new Variable { QuestionId = 7, Text = "1" });
            context.Variables.Add(new Variable { QuestionId = 7, Text = "2" });
            context.Variables.Add(new Variable { QuestionId = 7, Text = "3" });
            context.Variables.Add(new Variable { QuestionId = 7, Text = "4" });
            context.Variables.Add(new Variable { QuestionId = 7, Text = "5" });
        }

        private void AddFeedback(BlogContext context)
        {
            context.Feedback.Add(new Feedback { Author = "Anonymous", Text = "Nice blog!", Published = DateTime.UtcNow });
            context.Feedback.Add(new Feedback { Author = "Anonymous", Text = "Too boring..", Published = DateTime.UtcNow });
            context.Feedback.Add(new Feedback { Author = "Anonymous", Text = "More publications!!!", Published = DateTime.UtcNow });
        }

        private void AddArticles(BlogContext context)
        {
            context.Articles.Add(new Article
            {
                Text = "It is the first one article for test my data base. If you can read this - it's mean my application works correct.",
                Title = "Test Article",
                Published = DateTime.UtcNow,
                Tags = context.Tags.OrderBy(x => x.Id).Skip(3).ToList()
            });

            context.Articles.Add(new Article
            {
                Title = "Qt: Embedded World 2017 и roadmap",
                Text = "Большая часть информации по Qt (новости, информация на сайте, статьи, публикации в блоге, аккаунты в соц.сетях) доступна только на английском языке. И хотя каждый разработчик желательно-обязательно должен владеть английским, для многих языковой барьер по-прежнему является проблемой.Я работаю в The Qt Company(в офисе Осло, Норвегия), " +
                "и видя как обделено вниманием весьма немаленькое русскоязычное сообщество," + "я решил написать эту статью на русском и рассказать немного о прошедшей на позапрошлой неделе в Нюрнберге конференции Embedded World 2017," + "а также поделиться планами компании на будущие релизы Qt.Но хотя статья и на русском,"
                + "ссылки всё же ведут на английскую документацию, а также некоторые термины я решил оставить в оригинале.",
                Published = DateTime.UtcNow,
                Tags = context.Tags.Take(3).ToList()
            });

            context.Articles.Add(new Article
            {
                Title = "DevOps на службе человека",
                Text = "Технологии шаг за шагом отнимают наши рабочие места и грозят добраться до самого ценного — Ctr-C из Stack Overflow и Ctrl-V в родной IDE. Но к счастью, ни одна нейронная сеть пока не научилась программировать лучше тебя. Сегодня мы поговорим о том, как можно использовать DevOps, чтобы избавить от рутины целую команду мобильных разработчиков и даже тебя лично.",
                Published = DateTime.UtcNow,
                Tags = context.Tags.Take(3).ToList()
            });
        }

        private void AddTags(BlogContext context)
        {
            context.Tags.Add(new Tag
            {
                Name = "IT",
                Articles = context.Articles.Where(x => x.Id <= 2).ToList()
            });

            context.Tags.Add(new Tag
            {
                Name = "Computing",
                Articles = context.Articles.Where(x => x.Id <= 2).ToList()
            });

            context.Tags.Add(new Tag
            {
                Name = "Developing",
                Articles = context.Articles.Where(x => x.Id <= 2).ToList()
            });

            context.Tags.Add( new Tag
            {
                Name = "Author",
                Articles = context.Articles.Where(x => x.Id <= 2).ToList()
            });

            context.SaveChanges();
        }
    }
}