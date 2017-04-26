using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EpamBlog.Models;


namespace EpamBlog.Helpers
{
    public static class ArticleHelper
    {
        private const short MAX_AMOUNT_SYMBOLS_PREVIEW = 200;

        public static MvcHtmlString PrintArticle(this HtmlHelper html, Article _article)
        {

            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "article-text");

            if (_article.Text.Count() < MAX_AMOUNT_SYMBOLS_PREVIEW)
            {
                div.InnerHtml = _article.Text;
            }
            else
            {
                div.InnerHtml = _article.Text.Substring(0, MAX_AMOUNT_SYMBOLS_PREVIEW) + "...<br/>";
            }

            TagBuilder a = new TagBuilder("a");
            a.MergeAttribute("href", urlHelper.Action("ReadArticle/" + _article.Id, "Home"));
            a.InnerHtml += "<br/>Read More";

            div.InnerHtml += a.ToString();

            return MvcHtmlString.Create(div.ToString());
        }



        public static MvcHtmlString PrintArticleWithFeedback(this HtmlHelper html, Article _article)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "single-article");


            TagBuilder header = new TagBuilder("h2");
            header.InnerHtml = _article.Title;

            div.InnerHtml += header.ToString();


            TagBuilder textDiv = new TagBuilder("div");
            textDiv.MergeAttribute("class", "article-text");
            textDiv.InnerHtml = _article.Text + "<br/>";

            div.InnerHtml += textDiv.ToString();

            foreach (Tag tag in _article.Tags)
            {
                div.InnerHtml += "#" + tag.Name + " ";
            }

            div.InnerHtml += "<br/>" + _article.Published.ToString();


            return MvcHtmlString.Create(div.ToString());
        }
    }
}