namespace BlazorElementPlusAdmin.Models;

public sealed record MetricCard(string Label, string Value, string Trend, string Icon, string Accent);

public sealed record WorkItem(string Title, string Owner, string Status, int Progress);

public sealed record ActivityItem(string Actor, string Action, string Target, string Time);

public sealed record QuickLink(string Label, string Icon, string Path);
