using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.ObjectPool;

namespace VendaLanches.TagHelpers 
{   
    [HtmlTargetElement("a", Attributes = "link-active")]
    public class LinkActiveTagHelper : TagHelper
    {

        public string Controller { get; set; }

        public string Action { get; set; }

        public string ActiveClass { get; set; } = "Active";

        [ViewContext]
        public ViewContext viewContext { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            string classes = context.AllAttributes["class"].Value.ToString() + " " + ActiveClass;

            string controller = viewContext.HttpContext.GetRouteValue("controller")?.ToString() ?? "";
            string action = viewContext.HttpContext.GetRouteValue("action")?.ToString() ?? "";
            
            bool isCurrentAction = Action == action;

            output.Attributes.SetAttribute("class", "nav-link");

            Action = Action.Equals("Index") ? "" : $"/{Action}";

            output.Attributes.SetAttribute("href", $"/{Controller}{Action}");


            if (controller == Controller && isCurrentAction) 
            {
                output.Attributes.SetAttribute("class", classes);
            }

        }
    }
}