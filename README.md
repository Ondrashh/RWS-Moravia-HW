# RWS Moravia Homework.cs

## Issues

### File template
If we are using .NET 6 features, this template is not required to use no more.

### Multiple classes in one file
Creating class Document in same file violates single resposibility principle. I would recommend using separate file this class.

### Static file path
I would not recommend using static file path. If the code is executed on another pc it will probably fail. Another issues is that Environment.CurrentDirectory could sometimes not correct directory.

### File handling
File is beeing opened but is not closed. So it can lead to locking the file for further access.

### Using generic exceptions
Using generict Exception is a bad idea because you are not handling exceptions correctly. You are not getting any nformation and it is harder to debug or localize bug.

### Too much logic in one file
There is too much application logic written in one file. Basically there is the whole process -> opening file, reading, converting and writing back. So I would suggest splitting them into separate parts.

### Accessing properties
When accessing properties such as Value from xdoc.Root.Element("title") we should chech if we have the element, because when it is not there and we access its properties the program will crash.