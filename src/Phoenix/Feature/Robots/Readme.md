# Robots

## Introduction

Provides robots.txt functionality for your website

## Usage

#### Implement `IHasRobots`

On the page that authors should edit robots.txt content, implement `IHasRobots`

i.e. Your sites `StartPage` that all pages inherit from

```
public abstract class StartPage : PageData, IHasRobots
{
	[Display(Name = "Robots.txt",
        GroupName = "Robotx.txt",
        Order = 700,
        Description = "Content for robots.txt")]
    virtual public RobotsBlock Robots { get; set; }
}
```