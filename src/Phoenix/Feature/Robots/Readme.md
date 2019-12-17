# Robots

## Introduction

Provides robots.txt functionality for your website

## Usage

#### Implement `IHasRobots`

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