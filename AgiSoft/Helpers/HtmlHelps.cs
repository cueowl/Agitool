using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AgiSoft.Helpers {
    public static class HtmlHelps {
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, string controller, string imagePath, string alt) {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            // build the <img> tag
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controller));
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }

        public static MvcHtmlString ActionButton(this HtmlHelper html, string text, string action, string controller, string cssClass) {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            // build the <button> tag
            var btnBuilder = new TagBuilder("button");
            btnBuilder.MergeAttribute("type", "button");
            btnBuilder.InnerHtml = text;
            btnBuilder.AddCssClass(cssClass);
            string btnHtml = btnBuilder.ToString(TagRenderMode.Normal);

            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controller));
            anchorBuilder.InnerHtml = btnHtml; // include the <button> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }
    }
}