﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PivotSharp.Aggregators;
using PivotSharp.Filters;

namespace PivotSharp
{
	[JsonObject(MemberSerialization.OptIn)]
	public class PivotConfig
	{
		[JsonProperty]
		public IList<string> Rows { get; set; }
		[JsonProperty]
		public IList<string> Cols { get; set; }
		public Func<IAggregator> Aggregator { get; set; }

		[JsonProperty]
		protected string[] AggregatorName {
			get {
				if (Aggregator == null) return new string[]{};
				var aggregator = Aggregator();
				return new []{aggregator.SqlFunctionName, aggregator.ColumnName};
			}
			set {
				if(value.Length < 2) throw new ArgumentException("Require at least one element");
				Aggregator = FromString(value[0], value.Length > 1 ? value[1] : null);
			} 
		}


		//protected dynamic[] FilterNames {
		//	get {
		//		var ret = new dynamic[Filters.Count];
		//		foreach (var filter in Filters) {
		//			ret[Filters.IndexOf(filter)] = new {
		//				Op = filter.Op,
		//				Value = filter.ParameterValue,
		//				FieldName = filter.FieldName
		//			};
		//		}
		//		return ret;
		//	}
		//	set {
		//		Filters = new List<Filter>();
		//		foreach (var details in value) {
		//			((List<Filter>)Filters).Add(FromString(details)); // Cast to List to fix a dynamic binding issue: http://stackoverflow.com/questions/15920844/system-collections-generic-ilistobject-does-not-contain-a-definition-for-ad
		//		}
		//	}
		//}


		//private Filter FromString(dynamic details) {

		//	return new Filter(
		//		fieldName: details.FieldName.Value,
		//		op: details.
		//		);

		//	var type = details.ParameterValue.Value.GetType();
			

		//	if (details.Name == "Equals") {
		//		var constructedClass = typeof (Equals<>).MakeGenericType(type);
		//		return (Filter)Activator.CreateInstance(constructedClass, new object[]{ details.FieldName.Value, details.ParameterValue.Value});
				
		//	}
		//	if (details.Name == "GreaterThan") {
		//		var constructedClass = typeof(GreaterThan<>).MakeGenericType(type);
		//		return (Filter)Activator.CreateInstance(constructedClass, new object[] { details.FieldName.Value, details.ParameterValue.Value });

		//	}
		//	throw new NotImplementedException();
		//}

		private Func<IAggregator> FromString(string name, string columnName) {

			switch (name) {
				case "Count":
					return () => new Count();
				case "Sum":
					return () => new Sum(columnName);
			}
			throw new NotImplementedException();
		}

		[JsonProperty]
		public bool FillTable { get; set; }

		[JsonProperty()]
		public IList<Filter> Filters { get; set; }



		public PivotConfig() {
			Rows = new List<string>();
			Cols = new List<string>();
			Filters = new List<Filter>();
		}


	}
}