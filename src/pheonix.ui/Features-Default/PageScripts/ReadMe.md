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

On the page that authors should edit Global page scripts, implement `IHasGlobalPageScripts`

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
    @Html.Partial("~/Features/PageScripts/Views/Blocks/_GlobalPageHeadScript.cshtml", Model)
    @Html.Partial("~/Features/PageScripts/Views/Blocks/_PageHeadScript.cshtml", Model)
</head>
<body>
    @Html.Partial("~/Features/PageScripts/Views/Blocks/_GlobalPageBodyStartScript.cshtml", Model)
    @Html.Partial("~/Features/PageScripts/Views/Blocks/_PageBodyStartScript.cshtml", Model)
    
	@RenderBody()

    @Html.Partial("~/Features/PageScripts/Views/Blocks/_GlobalPageBodyEndScript.cshtml", Model)
    @Html.Partial("~/Features/PageScripts/Views/Blocks/_PageBodyEndScript.cshtml", Model)
</body>
</html>
```