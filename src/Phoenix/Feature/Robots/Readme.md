# Robots

## Introduction

Provides robots.txt functionality for your website

## Usage

This feature can used in 2 ways
1. Adding Robots.txt to your Start page
2. Creating a dedicated Robots Settings Page

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

Add `RobotsSettingsPage` as an AvailableContentTypes under you settings page

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