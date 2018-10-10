using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo info, Func<int,string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for(int i=1;i<=info.Totalpages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == info.CurrentPage)
                {
                    tag.AddCssClass("btn-primary");
                    tag.AddCssClass("selected");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());

            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}