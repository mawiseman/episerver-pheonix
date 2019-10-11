# Editors

## Introduction

This project is intended to provide additional field editors that are not included by EPIServer but used regularly

## Contents

- [Avaliable Editors](#Editors)
  - [Date Only](#DateOnly)
- [Editor Tests](#Tests)

## <a id="Editors"></a>Avaliable Editors

### <a id="DateOnly"></a>Date Only


Provides a date selector without time

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