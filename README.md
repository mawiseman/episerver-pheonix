## Introduction

This is a project that i ahve been putting together whilst going through the EPI Server developers training and is a proving ground for what i am learning as well as some structures / processes which future projects might use

### Project Structure

Currently using a semi Sitecore Helix approach.
- **Foundation Layer**
  - Stored in `/foundation/xxx`
  - Functionality shared by multiple features and enhancements to EPIServer core
  - Future state: Probably separate VS Projects
- **Feature Layer**
  - Stored in `/feature/xxx`
  - Functionality generally provided by block data
  - Future state: Probably separate VS Projects
- **Project Layer**
  - Stored in default folders i.e. `/Business`, `/Controllers`
  - Defines pages and data for this specific site

## Todo
- 404
- 500
- Robots
- Dictionary (or do we just use language files)
- Default Devices

## Useful links
- Fontawesome thumbnails: https://github.com/Geta/Epi.FontThumbnail
  - i like this more than my `ImageUrlGenerator` feature
- 404 and redirect manager: https://github.com/Geta/404handler
- Sitemap: https://github.com/Geta/SEO.Sitemaps

## Things that might be cool

### Unicorn for dev content
- It would be good to be able to serialize content so developers have a consistent environment
  - i.e. includes test pages
  - i.e. includes default site
- Would save everyone always generating this data

### LanguageFiles transforms for features
  - Language files are stored here \Resources\LanguageFiles\ (EditorHints.xml for editor hints)
  - This presents a problem when you have multiple features and want to provide language files for each of them
  - How can either... 
    - combine xml files from features during build
    - or: change the epi core so that xml files are referenced from multiple locations