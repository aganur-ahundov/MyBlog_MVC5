using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EpamBlog.Models;
using EpamBlog.Models.QuizModels;



namespace EpamBlog.Helpers
{
    public static class BlogHelper
    {
        private const short MAX_AMOUNT_SYMBOLS_PREVIEW = 200;

        private const short MARGIN_POINT = 70;

        private const short MAX_REPLIES_PER_COMMENT = 4;


        public static MvcHtmlString CreateNumberedList(this HtmlHelper html, string[] items)
        {
            TagBuilder ol = new TagBuilder("ol");
            foreach (var item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(item);
                ol.InnerHtml += li;
            }

            return new MvcHtmlString(ol.ToString());
        }



        public static MvcHtmlString CreateMarkedList(this HtmlHelper html, string[] items)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (var item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li;
            }

            return new MvcHtmlString(ul.ToString());
        }



        public static MvcHtmlString PrintArticle(this HtmlHelper html, Article _article)
        {

            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "article-text");
            
            if ( _article.Text.Count() < MAX_AMOUNT_SYMBOLS_PREVIEW )
            {
                div.InnerHtml = _article.Text;
            }
            else
            {
                div.InnerHtml = _article.Text.Substring( 0, MAX_AMOUNT_SYMBOLS_PREVIEW ) + "...<br/>";
            }

            TagBuilder a = new TagBuilder("a");
            a.MergeAttribute("href", urlHelper.Action("ReadArticle/" + _article.Id, "Home"));
            a.InnerHtml += "<br/>Read More";

            div.InnerHtml += a.ToString();

            return MvcHtmlString.Create(div.ToString());
        }



        public static MvcHtmlString PrintArticleWithFeedback(this HtmlHelper html, Article _article)
        {
            TagBuilder div = new TagBuilder( "div" );
            div.MergeAttribute( "class", "single-article" );


            TagBuilder header = new TagBuilder( "h2" );
            header.InnerHtml = _article.Title;

            div.InnerHtml += header.ToString();

           
            TagBuilder textDiv = new TagBuilder("div");
            textDiv.MergeAttribute("class", "article-text");
            textDiv.InnerHtml = _article.Text + "<br/>";

            div.InnerHtml += textDiv.ToString();

            foreach ( Tag tag in _article.Tags )
            {
                div.InnerHtml += "#" + tag.Name + " ";
            }

            div.InnerHtml += "<br/>" +_article.Published.ToString();


            return MvcHtmlString.Create( div.ToString() );
        }
        

            public static MvcHtmlString CreateMenuQuiz(this HtmlHelper html, StatisticViewModel _statistic)
        {

            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "statistic");
            div.InnerHtml += "<h3>" + _statistic.Title + "</h3>";

            foreach (var dictionary in _statistic.Data)
            {
                div.InnerHtml += "<span class='answer - text'>Variant<span class='key'> ";
                div.InnerHtml += dictionary.Key;
                div.InnerHtml += " </span> has chosen<span class='key'> ";
                div.InnerHtml += Math.Floor(dictionary.Value * _statistic.PersentPerPoint);
                div.InnerHtml += "%</span></span> <br/>";
            }

            return MvcHtmlString.Create(div.ToString());
        }


        public static MvcHtmlString CreateTextArea(this HtmlHelper html, string _name, string _placeholder)
        {
            TagBuilder input = new TagBuilder("textarea");

            input.MergeAttribute( "name", _name );
            input.MergeAttribute( "placeholder", _placeholder );
            input.MergeAttribute( "cols", "80" );
            input.MergeAttribute( "rows", "10" );
            
            return MvcHtmlString.Create( input.ToString() );
        }


        private static string PrintComment( Reply _comment, int _leftMarginLevel )
        {
            
            TagBuilder div = new TagBuilder( "div" );
            div.MergeAttribute( "class", "feedback Article" );
            div.MergeAttribute( "style", "margin-left:" + MARGIN_POINT * _leftMarginLevel + "px" );


            TagBuilder hidden = new TagBuilder( "input" );
            hidden.MergeAttribute( "type", "hidden" );
            hidden.MergeAttribute( "name", "feedbackId" );
            hidden.MergeAttribute( "value", _comment.Id.ToString() );

            div.InnerHtml += hidden.ToString( TagRenderMode.SelfClosing );
            div.InnerHtml += "<h4>Author: " + _comment.Author + "</h4>";
            div.InnerHtml += "<div class='feedback-text'>" + _comment.Text + "</div>";
            div.InnerHtml += "<p>Date: " + _comment.Published + "</p>";

            if( _leftMarginLevel < MAX_REPLIES_PER_COMMENT )
                div.InnerHtml += "<a href='#feedback-anchor'> Reply </a>";

            return div.ToString();
        }


        public static MvcHtmlString PrintCommentsWithReplies(this HtmlHelper html, Reply _comment, int _level = 1 )
        {
            string result = PrintComment( _comment, _level );
            

            if ( _comment.Replies.Count == 0 || _level == MAX_REPLIES_PER_COMMENT ) 
                return MvcHtmlString.Create( result );

            ++_level;
            foreach ( Reply reply in _comment.Replies )
            {
                result += PrintCommentsWithReplies( html, reply, _level );
            }

            return MvcHtmlString.Create( result );
        }
    }
}