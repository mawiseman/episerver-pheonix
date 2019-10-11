# MetaData

## Introduction

Provides the ability for content authors add meta data to their websites

## Usage

#### Implement IHasMetaData

On the page that authors should edit Global page scripts, implement `IHasMetaData`

i.e. Your sites `BasePage` that all pages inherit from

```
public abstract class BasePage : PageData, IHasMetaData
{
	[Display(Name = "Meta Data", 
		GroupName = "SEO", 
		Order = 500)]
	public virtual MetaDataBlock MetaData { get; set; }
}
```

#### Add Partial Renderings

On you shared layout add Partial Renderings to display the Meta Data

```
@model EPiServer.Core.PageData
<!DOCTYPE html>
<html>
<head>
    @Html.Partial(Feature.MetaData.Constants.ViewPaths.MetaData, Model.CurrentPage)
</head>
<body>
    @RenderBody()
</body>
</html>
```

#### Restrict Allowed Types

We don't want authors to be able to able to create new blocks of this

