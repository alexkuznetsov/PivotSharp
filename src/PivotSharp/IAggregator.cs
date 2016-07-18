﻿using System.Data;

namespace PivotSharp
{
	public interface IAggregator
	{
		string SqlFunctionName { get; }
		string ColumnName { get; set; }
		void Push(IDataReader record);
		decimal Value { get; }
		string FormattedValue { get; }
		int Count { get; }
		bool HasEntries { get; }
	}
}