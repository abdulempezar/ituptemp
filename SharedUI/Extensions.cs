using Radzen.Blazor;
using Radzen;
using Microsoft.AspNetCore.Components;

public static class Extensions
{
	internal static readonly Dictionary<FilterOperator, FormattableString> DataFilterOperators = new()
	{
		{FilterOperator.Equals, $"{0} = '{1}' {2}"},
		{FilterOperator.NotEquals, $"{0} != '{1}' {2}"},
		{FilterOperator.LessThan, $"{0} < '{1}' {2}"},
		{FilterOperator.LessThanOrEquals, $"{0} <= '{1}' {2}"},
		{FilterOperator.GreaterThan, $"{0} > '{1}' {2}"},
		{FilterOperator.GreaterThanOrEquals, $"{0} >= '{1}' {2}"},
		{FilterOperator.StartsWith, $"{0} ILIKE '%{1}'"},
		{FilterOperator.EndsWith, $"{0} ILIKE '{1}%'"},
		{FilterOperator.Contains, $"{0} ILIKE '%{1}%'"},
		{FilterOperator.DoesNotContain, $"{0} NOT ILIKE '%{1}%'"}
	};

	public static string? ToDataFilterString<T>(this RadzenDataGrid<T> dataGrid)
	{
		IEnumerable<FilterDescriptor>? columns = dataGrid.Query.Filters;
		Func<FilterDescriptor, bool> canFilter = (c) => c.Property != null &&
			!(c.FilterValue == null || c.FilterValue as string == string.Empty) && c.Property != null;

		if (columns?.Where(canFilter).Any() ?? false)
		{
			var gridLogicalFilterOperator = columns.FirstOrDefault()?.LogicalFilterOperator;
			var gridBooleanOperator = gridLogicalFilterOperator == LogicalFilterOperator.And ? "and" : "or";

			var whereList = new List<string>();
			foreach (var column in columns.Where(canFilter))
			{
				var property = column.Property;
				var value = (string)Convert.ChangeType(column.FilterValue, typeof(string)); value = value?.Replace("'", "''").Replace(';', ' ').ToLower();

				if (!string.IsNullOrEmpty(value))
				{
					var secondValue = (string)Convert.ChangeType(column.SecondFilterValue, typeof(string)); secondValue = secondValue?.Replace("'", "''").Replace(';', ' ').ToLower();
					var booleanOperator = column.LogicalFilterOperator == LogicalFilterOperator.And ? "and" : "or";

					if (string.IsNullOrEmpty(secondValue))
						whereList.Add(string.Format(DataFilterOperators[column.FilterOperator].Format, property, value, "COLLATE caseinsensitive"));
					else
						whereList.Add($"({string.Format(DataFilterOperators[column.FilterOperator].Format, property, value, "COLLATE caseinsensitive")} {booleanOperator} {string.Format(DataFilterOperators[column.SecondFilterOperator].Format, property, secondValue, "COLLATE caseinsensitive")})");
				}
			}

			return string.Join($" {gridBooleanOperator} ", whereList.Where(i => !string.IsNullOrEmpty(i))).Replace(';', ' ').Replace("union", "", StringComparison.CurrentCultureIgnoreCase);
		}

		return null;
	}

	public static void Notify(this NotificationService notification, string title, string message = "", NotificationSeverity severity = NotificationSeverity.Info)
	{
		notification.Notify(severity, title, message, 10000);
	}

	public static void Notify(this NotificationService notification, Exception ex)
	{
		notification.Notify(NotificationSeverity.Error, "Error!", $"{ex.Message}{(ex.InnerException is null ? string.Empty : Environment.NewLine)}{ex.InnerException?.Message}", 10000);
	}

    public delegate bool TryParseHandler<T>(string value, out T result);

    public static T? GetQueryValue<T>(this NavigationManager navigation, string paramName, TryParseHandler<T> handler) where T : struct
    {
        var queryParams = System.Web.HttpUtility.ParseQueryString((new Uri(navigation.Uri)).Query);
        if (handler(queryParams[paramName] ?? string.Empty, out T result)) return result;

        return null;
    }
}
