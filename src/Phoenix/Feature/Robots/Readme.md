# Robots

## Introduction

Provides robots.txt functionality for your website

## Features
- Display values at `/robots.txt`
- Caches value until publish
- Test without cache `/robots.txt?ignorecache=true`
- Prevents multiple `Rbots Settings Pages`


## ToDo
- Test in multi-site
- Improve multiple page prevention i.e. check trash / un-published

## Usage

This feature can used in 2 ways
1. Adding Robots.txt to your `Start page`
2. Creating a dedicated `Robots Settings Page`

#### 1. Adding Robots.txt to your Start page

Implement `IHasRobots` on your Start page: `SiteDefinition.Current.StartPage`. 

```
public abstract class StartPage : PageData, IHasRobots
{
    [Display(Name = "Robots.txt",
        GroupName = "Site Settings",
        Order = 700,
        Description = "Content for robots.txt")]
    virtual public RobotsBlock Robots { get; set; }
}
```

#### 2. Creating a dedicated Robots Settings Page

Add `RobotsSettingsPage` to your `AvailableContentTypes` attribute of your settings page

```
Root
├── Home
└── Settings
    └── Robots.txt
```

```
[ContentType(DisplayName = "SettingsPage", 
    GUID = "d838aac8-6500-4454-a25b-976966270c11", 
    Description = "")]
[ImageUrlGenerator("Site Settings")]
[ContentIcon(ContentIcon.Settings)]
[AvailableContentTypes(Include = new[] { typeof(RobotsSettingsPage) })]
public class SettingsPage : PageData
{
        
}
```