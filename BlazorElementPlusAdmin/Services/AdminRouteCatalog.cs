using BlazorElementPlusAdmin.Models;

namespace BlazorElementPlusAdmin.Services;

public static class AdminRouteCatalog
{
    public static readonly IReadOnlyList<AdminRoute> Routes =
    [
        new("/dashboard", "Dashboard", "el-icon-data-analysis", Children:
        [
            new("/dashboard/analysis", "Analysis", "el-icon-pie-chart", Affix: true),
            new("/dashboard/workplace", "Workplace", "el-icon-office-building")
        ]),
        new("/personal/personal-center", "Personal Center", "el-icon-user"),
        new("/error", "Error Pages", "el-icon-warning-outline", Children:
        [
            new("/error/403", "403", "el-icon-lock"),
            new("/error/404", "404", "el-icon-document-delete"),
            new("/error/500", "500", "el-icon-circle-close")
        ])
    ];

    public static AdminRoute? Find(string? path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return Find("/dashboard/analysis");
        }

        var normalizedPath = Normalize(path);
        return Flatten(Routes).FirstOrDefault(route => Normalize(route.Path) == normalizedPath);
    }

    public static IReadOnlyList<AdminRoute> Breadcrumb(string? path)
    {
        var normalizedPath = Normalize(path);
        var trail = new List<AdminRoute>();
        foreach (var route in Routes)
        {
            if (TryBuildTrail(route, normalizedPath, trail))
            {
                return trail;
            }
        }

        return Array.Empty<AdminRoute>();
    }

    public static IEnumerable<AdminRoute> Flatten(IEnumerable<AdminRoute> routes)
    {
        foreach (var route in routes)
        {
            yield return route;
            foreach (var child in Flatten(route.Children))
            {
                yield return child;
            }
        }
    }

    public static string Normalize(string? path)
    {
        if (string.IsNullOrWhiteSpace(path) || path == "/")
        {
            return "/dashboard/analysis";
        }

        var value = path.StartsWith('/') ? path : $"/{path}";
        return value.TrimEnd('/');
    }

    private static bool TryBuildTrail(AdminRoute route, string path, List<AdminRoute> trail)
    {
        trail.Add(route);
        if (Normalize(route.Path) == path)
        {
            return true;
        }

        foreach (var child in route.Children)
        {
            if (TryBuildTrail(child, path, trail))
            {
                return true;
            }
        }

        trail.RemoveAt(trail.Count - 1);
        return false;
    }
}
