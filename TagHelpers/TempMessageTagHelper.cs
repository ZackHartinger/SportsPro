﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsPro.Models.ExtensionMethods;


namespace SportsPro.TagHelpers
{
	[HtmlTargetElement("my-temp-message")]
	public class TempMessageTagHelper : TagHelper
	{
		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext ViewCtx { get; set; } = null!;

		public override void Process(TagHelperContext context,
		TagHelperOutput output)
		{
			var td = ViewCtx.TempData;
			if (td.ContainsKey("message"))
			{
				output.BuildTag("h4", "bg-info text-center text-white p-2");
				output.Content.SetContent(td["message"]?.ToString());
			}
			else
			{
				output.SuppressOutput();
			}
		}
	}
}
