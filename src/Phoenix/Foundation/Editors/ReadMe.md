# Editors

## Introduction

This project is intended to provide additional field editors that are not included by EPIServer but used regularly

## Contents

- [Avaliable Editors](#Editors)
  - [Date Only](#DateOnly)
- [Editor Demos](#EditorDemos)

## <a id="Editors"></a>Avaliable Editors

### <a id="DateOnly"></a>Date Only


Provides a date selector without time

#### Usage

```
[UIHint(Foundation.Editors.UIHints.DateOnly)]
public virtual System.DateTime DateOnly { get; set; }
```

## <a id="EditorDemos"></a>Editor Demos

To see all the avaliable editors add the `EditorsTestPage` to `AvailableContentTypes`

```
[AvailableContentTypes(Include = new[] { typeof(EditorsTestPage)})]
public class YourStartPage : PageData { /* ... */ }
```