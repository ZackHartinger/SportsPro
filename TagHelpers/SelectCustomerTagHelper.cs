using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsPro.Models;

namespace SportsPro.TagHelpers
{
	[HtmlTargetElement("customer-dropdown", Attributes = "asp-for")]
	public class SelectCustomerTagHelper : TagHelper
	{
		private SportsProContext context { get; set; }
		public SelectCustomerTagHelper(SportsProContext ctx) => context = ctx;

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

			var customers = context.Customers.ToList();

			output.TagName = "select";
			output.Attributes.SetAttribute("asp-for", ForString);
			output.Attributes.SetAttribute("name", ForString);
			output.Attributes.SetAttribute("class", "form-select form-control");

			foreach (var customer in customers)
			{
				var isSelected = customer.CustomerId == modelValue ? "selected" : string.Empty;
				output.Content.AppendHtml($"<option value='{ customer.CustomerId }' {isSelected}>{ customer.FullName }</option>");
			}
		}
	}
}
