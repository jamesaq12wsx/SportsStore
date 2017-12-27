using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        /// <summary>
        /// 產生頁碼
        /// </summary>
        /// <param name="html">自己本身，不需要傳入</param>
        /// <param name="pagingInfo">傳入viewModel中的pagingInfo</param>
        /// <param name="pageUrl">呼叫的action</param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(this HtmlHelper html,PagingInfo pagingInfo,Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
                result.Append(string.Format(" "));
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}