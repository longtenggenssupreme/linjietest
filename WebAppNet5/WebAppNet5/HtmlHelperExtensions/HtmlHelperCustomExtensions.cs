using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// Html标签扩展---自定义标签
    /// </summary>
    public static class HtmlHelperCustomExtensions
    {
        /// <summary>
        /// 自定义标签
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IHtmlContent CustomArea(this IHtmlHelper htmlHelper, string expression)
        {
            return new HtmlString($"这是IHtmlHelper自定义扩展标签+{expression}");
        }
    }


    /// <summary>
    /// Html标签扩展---自定义标签
    /// 1、命名要以XX+TagHelper结尾，如SimpleTagHelper
    /// 2、使用的时候注意
    /// 如果有特性[HtmlTargetElement("SimpleCustomHtml")]，优先使用特性，
    /// 没有特性的话，使用SimpleTagHelper中的Simple作为标签，
    /// </summary>
    [HtmlTargetElement("SimpleCustomHtml")]
    public class SimpleTagHelper : TagHelper/*,ITagHelper*/
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetContent("TagHelper这是自定义标签");
            output.TagMode = TagMode.StartTagAndEndTag;
            //output.TagName = "div";//该标签渲染的时候显示的真实的Html标签
            output.TagName = "strong";//该标签渲染的时候显示的真实的Html标签，粗体
            base.Process(context, output);
        }
    }

    /// <summary>
    /// 定义一个图片的taghelper，razor标记帮助器
    /// </summary>
    [HtmlTargetElement("ImageCustom")]
    public class SimpleImageTagHelper : TagHelper/*,ITagHelper*/
    {
        /// <summary>
        /// 图片url地址
        /// </summary>
        public string ImageLink { get; set; }//界面使用的时候image-link

        /// <summary>
        /// 不显示图片的替换文本
        /// </summary>
        public string AlternativeText { get; set; }//界面使用的时候alternative-text-

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //output.Content.SetContent("TagHelper这是自定义标签");            
            //output.TagName = "div";//该标签渲染的时候显示的真实的Html标签
            output.TagName = "img";//该标签渲染的时候显示的真实的Html标签，图片
            output.TagMode = TagMode.StartTagOnly;
            //界面使用的时候 ：<ImageCustom image-link="" alternative-text="图片加载失败"></ImageCustom>
            //<img src="https://ss2.bdstatic.com/70cFvnSh_Q1YnxGkpoWK1HF6hhy/it/u=1188114947,823520637&amp;fm=26&amp;gp=0.jpg" alt="图片加载失败">
            output.Attributes.SetAttribute("src", ImageLink);//绑定image的src属性
            output.Attributes.SetAttribute("alt", AlternativeText);//绑定image的alt属性

            base.Process(context, output);
        }
    }
}
