using System.Linq;
using System.Web.Mvc;
using EpamBlog.Models;

namespace EpamBlog.Helpers
{
    public class CommentHelper
    {
        private const short MARGIN_POINT = 70;

        private const short MAX_REPLIES_PER_COMMENT = 4;

        private static string PrintComment(Reply _comment, int _leftMarginLevel)
        {

            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "feedback Article");
            div.MergeAttribute("style", "margin-left:" + MARGIN_POINT * _leftMarginLevel + "px");


            TagBuilder hidden = new TagBuilder("input");
            hidden.MergeAttribute("type", "hidden");
            hidden.MergeAttribute("name", "feedbackId");
            hidden.MergeAttribute("value", _comment.Id.ToString());

            div.InnerHtml += hidden.ToString(TagRenderMode.SelfClosing);
            div.InnerHtml += "<h4>Author: " + _comment.Author + "</h4>";
            div.InnerHtml += "<div class='feedback-text'>" + _comment.Text + "</div>";
            div.InnerHtml += "<p>Date: " + _comment.Published + "</p>";

            if (_leftMarginLevel < MAX_REPLIES_PER_COMMENT)
                div.InnerHtml += "<a href='#feedback-anchor'> Reply </a>";

            return div.ToString();
        }


        public static MvcHtmlString PrintCommentsWithReplies(this HtmlHelper html, Reply _comment, int _level = 1)
        {
            string result = PrintComment(_comment, _level);


            if (_comment.Replies.Count == 0 || _level == MAX_REPLIES_PER_COMMENT)
                return MvcHtmlString.Create(result);

            ++_level;
            foreach (Reply reply in _comment.Replies)
            {
                result += PrintCommentsWithReplies(html, reply, _level);
            }

            return MvcHtmlString.Create(result);
        }
    }
}