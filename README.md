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
- Dictionary (or do we just use language files)
- Default Devices

## Useful links
- Fontawesome thumbnails: https://github.com/Geta/Epi.FontThumbnail
  - i like this more than my `ImageUrlGenerator` feature
- 404 and redirect manager: https://github.com/Geta/404handler
- Sitemap: https://github.com/Geta/SEO.Sitemaps
- Sharing find across multiple developers: https://world.episerver.com/documentation/developer-guides/find/reindexing-a-site-without-affecting-other-developer-indexes/
- In-line block editing: https://world.episerver.com/blogs/bartosz-sekula/dates/2019/11/simple-block-publishing---episerver-labs-blockenhancements-v0-5-0/

## Things that might be cool

### Automatically register and index feature blocks

This is only required for self hosted lucene projects

#### Project: Searchable Controller / Service

```
	// add all the AsString text blocks for simple search
	keywordsQuery.QueryExpressions.Add(SearchBlockData(searchText));

	// for advanced searching target each blcok type i.e. date ranges etc
	keywordsQuery.QueryExpressions.Add(DateFieldBetweenQuery(searchStartDate, searchEndDate, Feature.CTA.Constants.IndexedFileds.StartDate));
```

#### Foundation Project: SearchableBlockData

```
// Index all block data fields
public class SearchableBlockDataInitializationModule {
	private void IndexingService_DocumentAdding(object sender, EventArgs e)
    {
/*
- need to cache this for performance
- for all pages (models that inherit PageData)
	- for each property of type ContentArea
		- for each item of IContent
			- if type is in AllowedTypes attribute and implements IIndexableBlockData
				- call AddIndexedFields
	- for each property that inherits BlockData and IIndexableBlockData
		- call AddFieldsToIndex
*/
	}
}

public interface IIndexableBlockData
{
	// should add a string version of the entire block for searching i.e. CTA_AsString
	// should also index individual fields for advanced searces. i.e. CTA_StartDate, CTA_SomeNumber
	public void AddFieldsToIndex(Document doc);

	// returns the search syntax for CTA_AsString
	public IQueryExpression GetStringQuery(string prefix)
}

// helpers to format lucene syntax

public static List<IQueryExpression> SearchBlockData(string query) {
/*
- need to cache this for performance
- for all pages (models that inherit PageData)
	- for each property of type ContentArea
		- for each item of IContent
			- if type is in AllowedTypes attribute and implements IIndexableBlockData
				- call return IIndexableBlockData.GetStringQuery();
	- for each property that inherits BlockData and IIndexableBlockData
		- call keywordsQuery.QueryExpressions.Add(IIndexableBlockData.GetStringQuery());
*/
}

public class StringFieldContainsQuery(string queryExpression, string fieldName)
public class DateFieldBetweenQuery(DateTime startDate, DateTime endDate, string fieldName)
```
   


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