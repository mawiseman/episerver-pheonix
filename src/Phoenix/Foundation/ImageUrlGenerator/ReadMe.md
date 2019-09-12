# Image Url Generator

## Introduction

Provides developers the ability to auto generate Image Url's for Pages and Blocks.

On the first call the image will be generated online and dowloaded locally. Each subsequent call will deliver the image from disk.

This might be better though https://github.com/Geta/Epi.FontThumbnail

## Usage

Decorate your pages with the `ImageUrlGeneratorAttribute` specifying the the required text

```
[ImageUrlGenerator("Testimony")]
public class TestimonyBlock : BlockData
{
}
```

This is an example of the generated image

![image](https://fakeimg.pl/120x90/ff5800/fff/?retina=1&text=Testimony)
