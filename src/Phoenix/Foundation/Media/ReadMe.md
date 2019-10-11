# Media

## Introduction

This feautre supports the major media types required by a site.

## Contents

- [Avaliable Editors](#Editors)
  - [Image File](#ImageFile)
  - [Video File](#VideoFile)
- [Media Tests](#Tests)
- [To Do](#TODO)

## <a id="Editors"></a>Avaliable Editors

### <a id="ImageFile"></a>Image File

```
[UIHint(UIHint.Image)]
public virtual ContentReference ImageFile { get; set; }
```

### <a id="VideoFile"></a>Video File

```
[UIHint(UIHint.Video)]
public virtual ContentReference VideoFile { get; set; }
```

## <a id="Tests"></a>Media Tests

1. Log into the CMS
2. Navigate to `Admin` > `Content Type`
3. Select the `Page Type` you would like to create the test page under
4. Select the `Avaliable Page Types` tab
5. Enable `Media Test Page`

## <a id="TODO"></a>To Do

- Additional file types
  - i.e. pdf, doc etc