using BlazorElementPlusAdmin.Models;

namespace BlazorElementPlusAdmin.Services;

public sealed class AdminShellState
{
    private readonly List<AdminTag> tags =
    [
        new("/dashboard/analysis", "Analysis", true)
    ];

    public event Action? Changed;

    public bool IsAuthenticated { get; private set; }

    public string UserName { get; private set; } = "admin";

    public bool SidebarCollapsed { get; private set; }

    public bool SettingsOpen { get; private set; }

    public bool DarkMode { get; private set; }

    public bool ShowBreadcrumb { get; private set; } = true;

    public bool ShowTagsView { get; private set; } = true;

    public bool ShowFooter { get; private set; } = true;

    public string ThemeColor { get; private set; } = "#409eff";

    public string Size { get; private set; } = "default";

    public string CurrentPath { get; private set; } = "/dashboard/analysis";

    public IReadOnlyList<AdminTag> Tags => tags;

    public bool Login(string account, string password)
    {
        if (!string.Equals(account, "admin", StringComparison.OrdinalIgnoreCase) || password != "admin")
        {
            return false;
        }

        IsAuthenticated = true;
        UserName = account;
        Notify();
        return true;
    }

    public void Logout()
    {
        IsAuthenticated = false;
        CurrentPath = "/login";
        Notify();
    }

    public void Visit(string? path)
    {
        var normalized = AdminRouteCatalog.Normalize(path);
        CurrentPath = normalized;
        var route = AdminRouteCatalog.Find(normalized);
        if (route is { NoTagsView: false } && !tags.Any(tag => tag.Path == normalized))
        {
            tags.Add(new AdminTag(normalized, route.Title, route.Affix));
        }

        Notify();
    }

    public void ToggleSidebar()
    {
        SidebarCollapsed = !SidebarCollapsed;
        Notify();
    }

    public void ToggleSettings()
    {
        SettingsOpen = !SettingsOpen;
        Notify();
    }

    public void ToggleDarkMode()
    {
        DarkMode = !DarkMode;
        Notify();
    }

    public void ToggleBreadcrumb()
    {
        ShowBreadcrumb = !ShowBreadcrumb;
        Notify();
    }

    public void ToggleTagsView()
    {
        ShowTagsView = !ShowTagsView;
        Notify();
    }

    public void ToggleFooter()
    {
        ShowFooter = !ShowFooter;
        Notify();
    }

    public void SetThemeColor(string color)
    {
        ThemeColor = color;
        Notify();
    }

    public void SetSize(string size)
    {
        Size = size;
        Notify();
    }

    public void CloseTag(string path)
    {
        var tag = tags.FirstOrDefault(item => item.Path == path);
        if (tag is null || tag.Affix)
        {
            return;
        }

        tags.Remove(tag);
        Notify();
    }

    private void Notify() => Changed?.Invoke();
}
