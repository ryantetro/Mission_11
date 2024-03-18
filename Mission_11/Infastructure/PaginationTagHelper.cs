using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission_11.Models.ViewModels;

namespace Mission_11.Infastructure
{
    // Custom TagHelper for generating pagination links.
    [HtmlTargetElement("div", Attributes="page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        // Constructor that gets a URL helper factory to create URL helpers.
        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            this.urlHelperFactory = temp;
        }

        // Allows access to the current ViewContext.
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }

        // The action method name for generating URLs.
        public string? PageAction { get; set; }

        // Pagination information (current page, total pages, etc.).
        public PaginationInfo PageModel { get; set; }

        // Whether to apply custom CSS classes.
        public bool PageClassesEnabled { get; set; } = false;

        // CSS class for the pagination div.
        public string PageClass { get; set; } = String.Empty;

        // CSS class for normal (unselected) pages.
        public string PageClassNormal { get; set; } = String.Empty;

        // CSS class for the currently selected page.
        public string PageClassSelected { get; set; } = String.Empty;

        // Processes the content to output the pagination HTML.
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Only proceed if we have a valid ViewContext and PageModel.
            if (ViewContext != null && PageModel != null)
            {
                // Creates a URL helper to build URLs.
                IUrlHelper UrlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                // The container for all pagination links.
                TagBuilder result = new TagBuilder("div");

                // Loop through all pages and create a link for each.
                for (int i = 1; i <= PageModel.TotalNumPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    // Set the link URL to the specified action, passing the current page number.
                    tag.Attributes["href"] = UrlHelper.Action(PageAction, new { pageNum = i });

                    // Apply CSS classes if enabled.
                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    // Set the link text to the page number.
                    tag.InnerHtml.Append(i.ToString());

                    // Add the link to the container.
                    result.InnerHtml.AppendHtml(tag);
                }

                // Set the output HTML to the container's inner HTML.
                output.Content.AppendHtml(result.InnerHtml);
            }
        }

    }
}
