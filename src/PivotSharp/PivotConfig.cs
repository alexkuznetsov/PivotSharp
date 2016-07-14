﻿using System.Collections.Generic;
using Newtonsoft.Json;
using PivotSharp.Aggregators;
using PivotSharp.Filters;

namespace PivotSharp
{
	[JsonObject(MemberSerialization.OptOut)]
	public class PivotConfig
	{
		public IList<string> Rows { get; set; }

		public IList<string> Cols { get; set; }

		public IList<Filter> Filters { get; set; }

		public AggregatorDef Aggregator { get; set; }

		public bool FillTable { get; set; }

		public ConfigurationErrorHandlingMode ErrorMode { get; set; }

		public PivotConfig() {
			Rows = new List<string>();
			Cols = new List<string>();
			Filters = new List<Filter>();

		}
	}
}