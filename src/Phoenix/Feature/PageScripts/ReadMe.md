# Page Scripts

## Introduction

Provides the ability for content authors to add additional scripts to page for analytics and tracking.

Scripts can be applied at the the following levels
- Global page scripts (every page on the site)
- Page scripts (individual pages)

At each of the levels the following script locations are avaliable
- Page header
- Body start
- Body end

## Usage

#### 1. Implement IHasGlobalPageScripts

On the page that authors should edit Global page scripts, implement `IHasGlobalPageScripts`. 

i.e. Your sites `StartPage`

```
public class StartPage : BasePage, IHasGlobalPageScripts
{
	[Display(Name = "Global Page Scripts", 
		GroupName = "Global Page Scripts", 
		Order = 600, 
		Description = "These scripts will be rendered on every page in the site")]
	virtual public PageScriptsBlock GlobalPageScripts { get; set; }
}
```

#### 2. Implement IHasPageScripts

On the pages that authors can edit page scripts, implement `IHasPageScripts`

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

#### 3. Add Partial Renderings

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