# Page Scripts

## Introduction

Provides the ability for content authors to add additional scripts to page for analytics and tracking.

Scripts can be applied at the the following levels
- Global page scripts (every page on the site)
- Page scripts (individual pages)

At each of the levels the following script locations are avaliable
- Page Header
- Body Start
- Body End

### Features
- Caches global scripts page until next publish
- Test without cache `/?ignorecache=true`
- Prevents multiple `Page Script Settings Pages`

### ToDo
- Test in multi-site
- Improve multiple page prevention i.e. check trash / un-published

## Usage

1. Implemnt the Global Page Scripts
2. Implement the Page Scripts

### 1. Adding Global Page Scripts

This part of the  feature can used in 2 ways
1. Adding Global Page Scripts to your `Start page`
2. Creating a dedicated `Page Scripts Settings Page`
3. Add the rendering to your layout

#### Adding Global Page Scripts to your Start page

Implement `IHasGlobalPageScripts` on your Start page: `SiteDefinition.Current.StartPage`. 

```
public class StartPage : PageData, IHasGlobalPageScripts
{
	[Display(Name = "Global Page Scripts", 
		GroupName = "Site Settings", 
		Order = 600, 
		Description = "These scripts will be rendered on every page in the site")]
	virtual public PageScriptsBlock GlobalPageScripts { get; set; }
}
```

#### Creating a dedicated Page Scripts Settings Page

Add `PageScriptSettingsPage` to your `AvailableContentTypes` attribute of your settings page

```
Root
├── Home
└── Settings
    └── Page Scripts
```

```
[ContentType(DisplayName = "SettingsPage", 
    GUID = "d838aac8-6500-4454-a25b-976966270c11", 
    Description = "")]
[ImageUrlGenerator("Site Settings")]
[ContentIcon(ContentIcon.Settings)]
[AvailableContentTypes(Include = new[] { typeof(PageScriptsSettingsPage) })]
public class SettingsPage : PageData
{
        
}
```

### 2. Adding Page Scripts

On any page that authors can edit page scripts, implement `IHasPageScripts`

i.e. Your sites `BasePage` that all pages inherit from

```
public class BasePage : IHasPageScripts
{
	[Display(Name = "Page Scripts", 
		GroupName = "Page Scripts", 
		Order = 600)]
	public virtual PageScriptsBlock PageScripts { get; set; }
}
```

### 3. Add Partial Renderings

On you shared layout add Partial Renderings for both Global Page Scripts and Page Scripts

```
@model EPiServer.Core.PageData
<!DOCTYPE html>
<html>
<head>
	@Html.Partial(Feature.PageScripts.Constants.ViewPaths.GlobalPageHeadScripts, Model.CurrentPage)
	@Html.Partial(Feature.PageScripts.Constants.ViewPaths.PageHeadScripts, Model.CurrentPage)
</head>
<body>
	@Html.Partial(Feature.PageScripts.Constants.ViewPaths.GlobalPageBodyStartScripts, Model.CurrentPage)
	@Html.Partial(Feature.PageScripts.Constants.ViewPaths.PageBodyStartScripts, Model.CurrentPage)
    
	@RenderBody()

	@Html.Partial(Feature.PageScripts.Constants.ViewPaths.GlobalPageBodyEndScripts, Model.CurrentPage)
	@Html.Partial(Feature.PageScripts.Constants.ViewPaths.PageBodyStartScripts, Model.CurrentPage)
</body>
</html>
```