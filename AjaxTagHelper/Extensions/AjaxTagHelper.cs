

using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;


namespace AjaxTagHelper.Extensions
{
    /// <summary>
    /// You can use Ajax Tag Helper to submit forms as AJAX in Asp Net Core.
    /// </summary>
    public class AjaxButtonTagHelper:TagHelper
    {
        /// <summary>
        /// set controller    (should not be empty)
        /// </summary>
        [HtmlAttributeName("ajax-controller")]
        public string Controller { get; set; }
        /// <summary>
        /// set action       (should not be empty)
        /// </summary>
        [HtmlAttributeName("ajax-action")]
        public string Action { get; set; }
        /// <summary>
        /// set area
        /// </summary>
        [HtmlAttributeName("ajax-area")]
        public string Area { get; set; } = null;
        /// <summary>
        /// set form id       (should not be empty)
        /// </summary>
        [HtmlAttributeName("ajax-form-id")]
        public string FormId { get; set; } = null;

        /// <summary>
        /// set method (default => post)
        /// </summary>
        [HtmlAttributeName("ajax-method")]
        public string Method { get; set; } = "Post";

        /// <summary>
        /// Customize function success (Enter the name of the custom function) default => null  
        /// example create function successFunction(data){ code }
        /// </summary>
        [HtmlAttributeName("ajax-success-func")]
        public string SuccessFunction { get; set; } = null;
        /// <summary>
        /// Customize function failure (Enter the name of the custom function) default => null
        /// example create function failureFunction(data){ code }
        /// </summary>
        [HtmlAttributeName("ajax-failure-func")]
        public string FailureFunction { get; set; } = null;

        [HtmlAttributeName("ajax-content-type")]
        public string ContentType { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";    // Replaces <ajax-button> with <button> tag
            output.TagMode = TagMode.StartTagAndEndTag;
           
            if (Action == null || Controller == null)
            {
                throw new ArgumentException("The action and the controller should not be empty");
            }
            output.Attributes.SetAttribute("action", Controller + "/" + Action);
            output.Attributes.SetAttribute("data-method", Method);
            output.Attributes.SetAttribute("type", "button");
            output.Attributes.SetAttribute("success-func", SuccessFunction);
            output.Attributes.SetAttribute("failure-func", FailureFunction);
            var valueClass = output.Attributes.FirstOrDefault(m => m.Name == "class")?.Value;
            output.Attributes.SetAttribute("class", "ajaxButton " + valueClass);
            output.Attributes.SetAttribute("data-content-type", ContentType);
            output.Attributes.SetAttribute("form-id", FormId);
            if (Area != null)
            {
                Area = Area + "/";
            }
            output.Attributes.SetAttribute("data-area", Area);

        }
    }


    /// <summary>
    /// Ajax Action Helper
    /// </summary>
    public class AjaxActionTagHelper : TagHelper
    {
        /// <summary>
        /// set controller    (should not be empty)
        /// </summary>
        [HtmlAttributeName("ajax-controller")]
        public string Controller { get; set; }
        /// <summary>
        /// set action       (should not be empty)
        /// </summary>
        [HtmlAttributeName("ajax-action")]
        public string Action { get; set; }
        /// <summary>
        /// set area
        /// </summary>
        [HtmlAttributeName("ajax-area")]
        public string Area { get; set; } = null;
        /// <summary>
        /// set data id           (should not be empty)
        /// </summary>
        [HtmlAttributeName("ajax-data-id")]
        public string Data { get; set; } = null;

        /// <summary>
        /// set method (default => post)
        /// </summary>
        [HtmlAttributeName("ajax-method")]
        public string Method { get; set; } = "Post";

        /// <summary>
        /// Customize function success (Enter the name of the custom function) default => null  
        /// example create function successFunction(data){ code }
        /// </summary>
        [HtmlAttributeName("ajax-success-func")]
        public string SuccessFunction { get; set; } = null;
        /// <summary>
        /// Customize function failure (Enter the name of the custom function) default => null
        /// example create function failureFunction(data){ code }
        /// </summary>
        [HtmlAttributeName("ajax-failure-func")]
        public string FailureFunction { get; set; } = null;

        [HtmlAttributeName("ajax-content-type")]
        public string ContentType { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";    // Replaces <ajax-action> with <a> tag
            output.TagMode = TagMode.StartTagAndEndTag;
            if (Action == null || Controller == null)
            {
                throw new ArgumentException("The action and the controller should not be empty");
            }
            output.Attributes.SetAttribute("action", Controller + "/" + Action);
            output.Attributes.SetAttribute("data-method", Method);
            output.Attributes.SetAttribute("success-func", SuccessFunction);
            output.Attributes.SetAttribute("failure-func", FailureFunction);
            var valueClass=output.Attributes.FirstOrDefault(m=>m.Name=="class")?.Value;
            output.Attributes.SetAttribute("class", "ajaxAction "+valueClass);


            output.Attributes.SetAttribute("data-content-type", ContentType);
output.Attributes.SetAttribute("data-id", Data);
            if (Area!=null)
            {
                Area = Area + "/";
            }
            output.Attributes.SetAttribute("data-area", Area);

        }
    }
}
