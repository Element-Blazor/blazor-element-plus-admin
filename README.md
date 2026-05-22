# blazor-element-plus-admin

Blazor native replica of
[kailong321200875/vue-element-plus-admin](https://github.com/kailong321200875/vue-element-plus-admin),
built on top of Element-Blazor / Element Plus style components.

## Goal

Recreate the admin experience, route matrix, examples, mock data, layout system,
permission flow, theme settings, tags view and dashboard pages in Blazor. The
target is feature parity, not a Vue runtime wrapper.

## Source Baseline

- Source repository: `kailong321200875/vue-element-plus-admin`
- Source branch: `master`
- Source version inspected: `2.9.0`
- Source HEAD inspected: `38047fba67ea1e0fac9d576caf0facd39c96d235`
- Source license: MIT, copyright Archer

See [ROADMAP.md](ROADMAP.md) for the replication plan.

## MVP Host

The current MVP is a .NET 10 Blazor Web App in `BlazorElementPlusAdmin`.
It references the local Element-Blazor component project from the parent
repository:

```powershell
cd BlazorElementPlusAdmin
dotnet run
```

Open `http://localhost:5072` or the URL printed by `dotnet run`.

Implemented MVP routes:

- `/login` with local `admin/admin` mock login
- `/dashboard/analysis`
- `/dashboard/workplace`
- `/personal/personal-center`
- `/error/403`
- `/error/404`
- `/error/500`

The app uses Blazor components and Element-Blazor `El*` controls only. It does
not embed Vue, Vite, Pinia, npm packages, or a Vue runtime.
