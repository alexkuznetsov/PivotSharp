using Microsoft.AspNetCore.Mvc;
using PivotSharp.DataReader;
using PivotSharp.WebCore.Models;

namespace PivotSharp.WebCore.Pages;
public class IndexModel : BaseHomePageModel
{
	private readonly ILogger<IndexModel> _logger;

	public PivotTableViewModel? PivotTable { get; private set; }

	public IndexModel(ILogger<IndexModel> logger) => _logger = logger;

	public ActionResult OnGet(int id = 1) {

		var config = configs.Single(c => c.Key == id).Value;

		var reader = new EnumerableDataReader(source);

		var pivot = PivotSharp.PivotTable.Create(config);
		pivot.Pivot(reader);

		PivotTable = new PivotTableViewModel(id, pivot, config);
		return Page();
	}
}
