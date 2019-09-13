# Block Preview

## Introduction

Provides the ability to preview a block type when editing it.

## Issues

### Temporary DisplayOptions when none exist

Becase this site doesn't currently have any  DisplayOptions defined we would never render these nicely
So i modified the controller to always include at least one called "Preview Only".
The downside is a Block that might not work on its own... like a TeaserBlock (which needs a teaser carousel around it) will look bad

### _ViewStart.cshtml

To pick up the Layout i have had to include a _ViewStart.cshtml in the Views folder.
This would be resolved if
- this Foundation was moved to a new project
- The Views folder changed from
  - \Foundation\BlockPreview\Views
  - to: \Views

### Hard refereces to **StartPage** and **SitePageData**. 

To make this a true foundation component i think we need SitePageData in the foundation layer... and a technique to let us fluently inject a template page
Posisbly using interfaces?