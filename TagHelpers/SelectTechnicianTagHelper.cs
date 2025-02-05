using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualBasic;
using SportsPro.Models;
using SportsPro.Models.DataLayer;

namespace SportsPro.TagHelpers
{
    [HtmlTargetElement("technician-dropdown", Attributes = "asp-for")]
    public class SelectTechnicianTagHelper : TagHelper
    {
        private SportsProContext context { get; set; }
        public SelectTechnicianTagHelper(SportsProContext ctx) => context = ctx;

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

		[HtmlAttributeName("asp-for-string")]
		public string ForString { get; set; }


		public override void Process(TagHelperContext tagContext,
       TagHelperOutput output)
        {
            //get selected value from view's model
            For = (ModelExpression)tagContext.AllAttributes["asp-for"].Value;

            int modelValue = (int)For.Model;

            var technicians = context.Technicians.ToList();
           
            output.TagName = "select";
            output.Attributes.SetAttribute("asp-for", ForString);
            output.Attributes.SetAttribute("name", ForString);
			output.Attributes.SetAttribute("class", "form-select form-control");

			foreach (var technician in technicians)
            {
                var isSelected = technician.TechnicianId == modelValue ? "selected" : string.Empty;
                output.Content.AppendHtml($"<option value='{technician.TechnicianId}' {isSelected}>{technician.Name}</option>");
            }
        }
    }
}
