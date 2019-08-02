# Feature Folders

I think we are bettor off using the RegisterBlockViews approach

This features adds new locations to better organise views for controllerless Blocks

To store all views with a Features... they would all require a controller.

## Feature Folder Structure

**Folder structure**

```
Project
└───...
└───Views
	└───Shared
		└───Blocks
		└───PagePartials
		└───Partials
```


## TODO
### support feature view folders
1. Scan project for controllers in Feature namespace?
2. Scan project for controllers with a "FeatureViews" attribute?
```
Project
└───...
└───Views
└───Feature
	└───First Feature
	|	└───Views
	└───Second Feature
		└───Views
```