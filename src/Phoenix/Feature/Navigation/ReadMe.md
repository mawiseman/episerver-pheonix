# Navigation

## Introduction

A simple navigation feature. Currently only has PrimaryNavigation but should also be responsible for 
- Breadcrumbs
- Secondary Navigation

### Features
- Heavily based on the example from: https://world.episerver.com/documentation/developer-guides/CMS/learning-path/listings-and-navigation/
- Caches navigation items. 
  - Cleared on item publish, scheduled publish, deletion, moved

**Notes on caching**

In it's current state I couldn't use ContentOutputCache because that does not work with Child Actions
It would also be possible to just use `OutputCache` but that does not clear on the actions above

## Usage

In your layout add the following
```
@{ Html.RenderAction("PrimaryNavigation", "Navigation"); }
```