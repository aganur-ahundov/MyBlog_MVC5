using System;
using System.Web.Mvc;
using EpamBlog.Models.QuizModels;



namespace EpamBlog.Helpers
{
    public static class QuizConstructor
    {

        private static int MultipleQuestionUniqueId = 0;
        private static int TextBoxUniqueId = 0;



        public static MvcHtmlString CreateMultipleChoiceQuestion(this HtmlHelper html, MultipleChoiceQuestion _question)
        {
            TagBuilder header = new TagBuilder("h3"); 
            header.InnerHtml += _question.QuestionText;

            string result = header.ToString();

            result += (_question.Type == MultipleQuestionType.Radio) 
                ? CreateRadioButton(_question) 
                : CreateCheckbox(_question);
            
            return MvcHtmlString.Create( CreateQuestionDiv( result ) );
        }



        public static MvcHtmlString CreateQuizTextbox( this HtmlHelper html, Textbox _textbox)
        {
            string result = CreateHiddenTextQuestionID( _textbox );

            TagBuilder input = new TagBuilder( "textarea" );

            input.MergeAttribute( "name", "QuizTextboxes[" + TextBoxUniqueId + "].Answer" );
            input.MergeAttribute( "placeholder", _textbox.Placeholder );
            input.MergeAttribute( "cols", "50" );
            input.MergeAttribute( "rows", "10" );

            result += "<br/>" + input.ToString();

            TextBoxUniqueId++;
            return MvcHtmlString.Create( CreateQuestionDiv( result ) );
        }



        public static MvcHtmlString CreateSingleRadiobutton( this HtmlHelper html, MultipleChoiceQuestion _question )
        {
            string result = String.Empty;
            string type = Enum.GetName(typeof(MultipleQuestionType), _question.Type).ToLower();


            TagBuilder header = new TagBuilder("h3");
            header.InnerHtml += _question.QuestionText;
            result += header.ToString();
       

            TagBuilder hidden = new TagBuilder("input");
        
            hidden.MergeAttribute("type", "hidden");
            hidden.MergeAttribute("name", "QuestionId");
            hidden.MergeAttribute("value", _question.Id.ToString());
            result += hidden.ToString();

            foreach ( Variable var in _question.Variables )
            {

                TagBuilder input = new TagBuilder("input");

                input.MergeAttribute("type", type);
                input.MergeAttribute("name", "Answer");
                input.MergeAttribute("value", var.Text);

                result += input.ToString(TagRenderMode.SelfClosing) + var.Text;

            }

            return MvcHtmlString.Create( result );
        }



        private static string CreateRadioButton( MultipleChoiceQuestion _question )
        {
            string result = String.Empty;
            string type = Enum.GetName(typeof(MultipleQuestionType), _question.Type).ToLower();


            result += CreateHiddenMultipleQuestionID(_question);
            foreach (Variable var in _question.Variables)
            {

                TagBuilder input = new TagBuilder("input");

                input.MergeAttribute("type", type);
                input.MergeAttribute("name", "MultipleAnswers[" + MultipleQuestionUniqueId + "].Answer");
                input.MergeAttribute("value", var.Text);

                result += input.ToString(TagRenderMode.SelfClosing) + var.Text;

            }
            MultipleQuestionUniqueId++;

            return result;
        }



        private static string CreateCheckbox( MultipleChoiceQuestion _question )
        {
            string result = String.Empty;
            string type = Enum.GetName( typeof(MultipleQuestionType), _question.Type ).ToLower();


            foreach (Variable var in _question.Variables)
            {
                result += CreateHiddenMultipleQuestionID(_question);

                TagBuilder input = new TagBuilder("input");

                input.MergeAttribute( "type", type );
                input.MergeAttribute( "name", "MultipleAnswers[" + MultipleQuestionUniqueId + "].Answer" );
                input.MergeAttribute( "value", var.Text );

                result += input.ToString( TagRenderMode.SelfClosing ) + var.Text;

                MultipleQuestionUniqueId++;

            }


            return result;
        }



        private static string CreateQuestionDiv( string _innerHtml )
        {
            TagBuilder div = new TagBuilder("div");

            div.MergeAttribute("class", "question");
            div.InnerHtml = _innerHtml;

            return div.ToString();
        }


        public static void ResetIndexator()
        {
            MultipleQuestionUniqueId = 0;
            TextBoxUniqueId = 0;
        }



        private static string CreateHiddenMultipleQuestionID( MultipleChoiceQuestion _question )
        {
            TagBuilder hidden = new TagBuilder("input");

            hidden.MergeAttribute( "type", "hidden");
            hidden.MergeAttribute( "name", "MultipleAnswers[" + MultipleQuestionUniqueId + "].QuestionId");
            hidden.MergeAttribute( "value", _question.Id.ToString());
            return hidden.ToString();
        }
        


        private static string CreateHiddenTextQuestionID( Textbox _textbox )
        {
            TagBuilder hidden = new TagBuilder("input");

            hidden.MergeAttribute( "type", "hidden" );
            hidden.MergeAttribute( "name", "QuizTextboxes[" + TextBoxUniqueId + "].QuestionText" );
            hidden.MergeAttribute( "value", _textbox.Placeholder );
            return hidden.ToString();
        }



    }
}