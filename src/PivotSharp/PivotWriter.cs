﻿using System.IO;
using System.Reflection;
using RazorEngine;
using RazorEngine.Templating;

namespace PivotSharp
{
	public static class PivotWriter
	{
		public static string WriteHtmlTable(PivotTable table)  {
			// See https://antaris.github.io/RazorEngine/
			// This file need to have Build Action set to Embedded Resource.
			// The VS editor doesn't work well with .cshtml files outside a web project, so the easiest way to
			// develop this is in a web project, and then copy across when stable.
			var resourceName = "PivotSharp.Templates.Table.cshtml";
			string text = "";
			using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
			using (var reader = new StreamReader(stream)) {
				text = reader.ReadToEnd();
			}
			string renderedText = Engine.Razor.RunCompile(
				templateSource: text, 
				name: resourceName, 
				modelType: typeof(PivotTable), 
				model: table);
			return renderedText;
		}
	}
}