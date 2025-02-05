using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsPro.Models;

namespace SportsPro.TagHelpers
{
	[HtmlTargetElement("product-dropdown", Attributes = "asp-for")]
	public class SelectProductTagHelper : TagHelper
	{
		private SportsProContext context { get; set; }
		public SelectProductTagHelper(SportsProContext ctx) => context = ctx;

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

			var products = context.Products.ToList();

			output.TagName = "select";
			output.Attributes.SetAttribute("asp-for", ForString);
			output.Attributes.SetAttribute("name", ForString);
			output.Attributes.SetAttribute("class", "form-select form-control");



			foreach (var product in products)
			{
				var isSelected = product.ProductId == modelValue ? "selected" : string.Empty;
				output.Content.AppendHtml($"<option value='{product.ProductId}' {isSelected}>{product.Name}</option>");
			}
		}
	}
}
