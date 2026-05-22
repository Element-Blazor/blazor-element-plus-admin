namespace BlazorElementPlusAdmin.Models;

public sealed record AdminRoute(
    string Path,
    string Title,
    string Icon,
    bool Hidden = false,
    bool Affix = false,
    bool NoTagsView = false,
    string? ActiveMenu = null,
    string? Permission = null,
    IReadOnlyList<AdminRoute>? Children = null)
{
    public IReadOnlyList<AdminRoute> Children { get; init; } = Children ?? Array.Empty<AdminRoute>();
}
