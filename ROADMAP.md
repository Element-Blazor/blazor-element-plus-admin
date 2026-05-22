# blazor-element-plus-admin 复刻路线图

> 目标：以 Blazor 原生实现完整复刻 `kailong321200875/vue-element-plus-admin`，使用 Element-Blazor 的 `El*` 组件与 Element Plus 风格主题。不是嵌入 Vue，不直接运行 Vue 代码。

## 基线

| 项目 | 决策 |
| --- | --- |
| 源项目 | `kailong321200875/vue-element-plus-admin` |
| 源版本 | `2.9.0` |
| 源 HEAD | `38047fba67ea1e0fac9d576caf0facd39c96d235` |
| 目标仓库 | `Element-Blazor/blazor-element-plus-admin` |
| 目标技术 | .NET 10 + Blazor + Element-Blazor |
| 许可证 | 源项目 MIT；本项目保留来源说明与 MIT 版权声明 |

## 复刻原则

- 复刻信息架构、布局、页面、交互、视觉密度、主题能力和示例覆盖。
- 不照搬 Vue/TypeScript 运行时结构；按 Blazor 的组件、服务、路由和状态模型重建。
- 页面示例统一使用 `El*` 组件，不出现旧无前缀组件名。
- 源项目资产可在 MIT 允许范围内复用；新增实现保留来源署名。
- 对 Element-Blazor 暂缺组件，先在本仓库做业务层组件，稳定后回补组件库。

## 源功能矩阵

| 模块 | 源页面/能力 | Blazor 目标 |
| --- | --- | --- |
| Layout | 侧边栏、顶部工具栏、面包屑、TagsView、AppView、Footer、设置抽屉 | `MainLayout`、`AdminShell`、`SidebarMenu`、`ToolHeader`、`TagsView`、`SettingsPanel` |
| Login | 登录、注册、暗色/主题背景、账号 `admin/admin` | 本地 Mock 登录与 AuthState |
| Dashboard | Analysis、Workplace、PanelGroup、图表数据 | 首屏统计卡、趋势图、待办、快捷入口 |
| Components/Form | DefaultForm、UseForm | `ElForm` 示例与 schema form |
| Components/Table | DefaultTable、UseTable、TreeTable、CardTable、图片/视频预览 | 表格 CRUD、筛选、分页、树表、卡片表 |
| Components/Editor | 富文本、JSON、代码编辑器 | P2 后补；优先保留页面占位与 Monaco/textarea 适配 |
| Components | Search、Descriptions、Dialog、Icon、IconPicker、Echart、Qrcode、Tree、ImageViewer 等 | 按组件可用度逐步复刻 |
| Function | 多标签、请求、权限按钮 | TagsView、Http mock、权限指令等价组件 |
| Hooks | watermark、clipboard、network、validator、tags view、crud schemas | 转成 Blazor services/components demos |
| Level | 多级菜单 | 嵌套路由与多级侧栏 |
| Example | dialog CRUD、page CRUD、详情/编辑/新增 | Mock CRUD 数据流 |
| Error | 403、404、500 | 错误页 |
| Authorization | 用户、角色、菜单、部门管理 | Mock RBAC 管理界面 |
| Personal | 个人中心、资料、密码、头像 | 用户资料 Mock 页面 |
| i18n/theme | 中英文、尺寸、暗色、主题色、布局模式 | `IStringLocalizer`/轻量字典 + CSS variable settings |

## 阶段路线

### P0 仓库与工程骨架 🟡 进行中

| 任务 | 状态 | 验收 |
| --- | --- | --- |
| 子模块接入主仓库 | 🟢 已完成 | 主仓库 `.gitmodules` 包含 `blazor-element-plus-admin`。 |
| 记录源版本与许可证 | 🟢 已完成 | README/ROADMAP 写明源版本、HEAD、MIT。 |
| 创建 .NET 10 Blazor 工程 | 🔵 待开始 | 可 `dotnet run`，首页能启动。 |
| 引用本地 Element-Blazor | 🔵 待开始 | 使用当前主仓库 `src/Components/Element.csproj`。 |
| 建立 Mock 数据与静态资产目录 | 🔵 待开始 | `Data/Mock`、`wwwroot/assets`、`wwwroot/admin` 成形。 |

### P1 Admin Shell MVP 🔵 待开始

| 任务 | 验收 |
| --- | --- |
| 登录页 | `/login` 可用，支持 admin/admin，本地保存 token 状态。 |
| 主布局 | 侧边栏、Logo、顶部栏、面包屑、TagsView、内容区、Footer。 |
| 路由模型 | 建立 `AdminRoute`，支持 hidden、title、icon、affix、noTagsView、activeMenu、permission。 |
| 菜单渲染 | 按源 `asyncRouterMap` 渲染多级菜单。 |
| 基础主题 | 主题色、暗色、菜单折叠、尺寸切换。 |
| 首批页面 | Dashboard Analysis、Workplace、404、403、500、Personal Center。 |

### P2 高曝光页面复刻 🔵 待开始

| 模块 | 验收 |
| --- | --- |
| Components/Form | DefaultForm、UseFormDemo 页面可交互。 |
| Components/Table | DefaultTable、UseTable、TreeTable、CardTable、预览页面可交互。 |
| Example CRUD | 列表、新增、编辑、详情、Dialog CRUD 走通。 |
| Authorization | 用户、角色、菜单、部门四个管理页走 Mock CRUD。 |
| Function | 多标签页、请求示例、权限按钮演示。 |

### P3 组件示例补齐 🔵 待开始

| 模块 | 处理 |
| --- | --- |
| Echart | 优先用轻量 JS interop 包装 ECharts。 |
| Qrcode | 优先 JS interop 或纯 C# 生成。 |
| Editor/CodeEditor/JsonEditor | Monaco/textarea 分层实现。 |
| ImageCropping/ImageViewer | 先做查看器，裁剪使用 cropper interop。 |
| VideoPlayer | HTML5 video + viewer。 |
| Icon/IconPicker | 基于现有 Element icon class 与 Iconify 名称列表。 |
| Waterfall/Descriptions/Search/Infotip/IAgree | 业务层组件复刻。 |

### P4 状态、权限、国际化与主题 🔵 待开始

| 任务 | 验收 |
| --- | --- |
| AppState | 替代 Pinia：用户、权限、布局、tags、locale、lock。 |
| 权限 | route permission 与按钮 permission 均可控制。 |
| i18n | `en`、`zh-CN` 文案覆盖菜单和主要页面。 |
| TagsView | 新增、关闭、刷新、固定、右键菜单。 |
| Settings | 主题色、暗色、布局模式、面包屑、Logo、TagsView、Footer 开关。 |

### P5 完整性与发布 🔵 待开始

| 任务 | 验收 |
| --- | --- |
| 源页面核对 | 每个源路由都有 Blazor 页面、占位或明确后续说明。 |
| 视觉核对 | 桌面宽屏、普通桌面、移动断点截图核对。 |
| 构建 | `dotnet build` 零错误。 |
| 启动说明 | README 提供本地启动、账号、结构说明。 |
| 上游归属 | 可复用通用组件整理成 Element-Blazor issue/PR 清单。 |

## 首屏 MVP 路由

| 路径 | 页面 |
| --- | --- |
| `/login` | Login |
| `/dashboard/analysis` | Analysis |
| `/dashboard/workplace` | Workplace |
| `/components/form/default-form` | DefaultForm |
| `/components/table/default-table` | DefaultTable |
| `/example/example-page` | ExamplePage |
| `/authorization/user` | User |
| `/personal/personal-center` | PersonalCenter |
| `/error/404-demo` | 404 |

## 未实现不得虚标

- Virtualized Select/Table 不在 admin 仓库内假实现；需要时回补 Element-Blazor。
- Vue composables 不逐字迁移，转成 Blazor service/component。
- 富文本、Monaco、ECharts、Cropper 等 JS 生态能力允许通过薄 interop 实现，但页面 API 要保持 Blazor 风格。
- 源项目在线接口不作为硬依赖，默认使用本地 Mock。
