﻿using System.Collections.Generic;
using NUnit.Framework;

namespace PivotSharp.Tests
{
	[TestFixture]
	class PivotKeyTests
	{
		[Test]
		public void Can_Match() {

			var key1 = new PivotKey() {
				ColKeys = new List<string> {"Red", "Circle"},
				RowKeys = new List<string> {"Dotted", "Line"}
			};

			var key2 = new PivotKey() {
				ColKeys = new List<string> { "Red", "Circle" },
				RowKeys = new List<string> { "Dotted", "Line" }
			};

			Assert.That(key2, Is.EqualTo(key1));
			Assert.That(key1 == key2, Is.True);
			Assert.That(key1, Is.Not.EqualTo(key2));
		}

		[Test]
		public void Can_Distinguish() {

			var key1 = new PivotKey() {
				ColKeys = new List<string> { "Red", "Circle" },
				RowKeys = new List<string> { "Dotted", "Line" }
			};

			var key2 = new PivotKey() {
				ColKeys = new List<string> { "Red", "Circle" },
				RowKeys = new List<string> { "Dashed", "Line" }
			};

			Assert.That(key2, Is.EqualTo(key1));
			Assert.That(key1 == key2, Is.False);
			Assert.That(key1 != key2, Is.True);
		}

	}
}
