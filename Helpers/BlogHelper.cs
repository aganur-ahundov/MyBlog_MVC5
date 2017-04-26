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
        

            public static MvcHtmlString CreateMenuQuiz( this HtmlHelper html, StatisticViewModel _statistic )
        {

            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "statistic");
            div.InnerHtml += "<h3>" + _statistic.Title + "</h3>";

            foreach ( var dictionary in _statistic.Data )
            {
                div.InnerHtml += "<span class='answer - text'>Variant<span class='key'> ";
                div.InnerHtml += dictionary.Key;
                div.InnerHtml += " </span> has chosen<span class='key'> ";
                div.InnerHtml += Math.Floor(dictionary.Value * _statistic.PersentPerPoint);
                div.InnerHtml += "%</span></span> <br/>";
            }

            return MvcHtmlString.Create( div.ToString() );
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
        
    }
}