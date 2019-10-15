# Editors

## Introduction

This project is intended to provide additional field editors that are not included by EPIServer but used regularly

## Contents

- [Avaliable Editors](#Editors)
  - [Date Time](#DateTime)
  - [Date Only](#DateOnly)
- [Editor Tests](#Tests)

## <a id="Editors"></a>Avaliable Editors

### <a id="DateTime"></a>Date Time

- Enhanced Date Time to support en-AU date formats: dd-MM-yyyy

#### Usage

```
public virtual System.DateTime DateOnly { get; set; }
```

### <a id="DateOnly"></a>Date Only

- Provides a date selector without time
- Supports en-AU date formats: dd-MM-yyyy

#### Usage

```
[UIHint(Foundation.Editors.UIHints.DateOnly)]
public virtual System.DateTime DateOnly { get; set; }
```

## <a id="Tests"></a>Editor Tests

1. Log into the CMS
2. Navigate to `Admin` > `Content Type`
3. Select the `Page Type` you would like to create the test page under
4. Select the `Avaliable Page Types` tab
5. Enable `Editors Test Page`