# Farhang Dictionary Production System (DPS)

The purpose of this project is to typeset bilingual dictionaries. After typesetting, it provides options to export them to a specially crafted TeX file, which 
uses `farhang.cls` LaTeX class file for the layout of the TeX files which will then be converted to PDF using TeXLive distribution using XeLaTeX. It also has a 
SQLite export feature to be used for writing dictionary apps.

It is written in C# and uses MongoDB as database for storing dictionary entries as separate documents. The first (stone-age) version was developed about 9 
years ago using Python, PostgreSQL and it was developed on Debian and was cross-compiled for windows. The current version has been developed about 6 
years ago and is very old and possibly needs refactoring and adding features.
I used Mercurial (Hg) to manage the project, but converted the whole project from Mercurial to Git, just before making it free using hg-git plugin, mercurial package, python and bitbucket.

In order to run the project, you should install MongoDB and compile and run the project from source. I will try to provide a binary version for your convenience 
if I can find a suitable time. Also, you should have `DejaVu` font family installed on your machine to be able to use this software, since this font family has 
by far the most complete set of unicode characters. You can download it [here](https://dejavu-fonts.github.io/). It is published with Free License and is in 
Public Domain.

This project is used to typeset a bilingual German-Persian dictionary of over 2600 pages which is published by Zabankadeh and Langenscheidt AG.

[Langenscheidt Handwörterbuch Deutsch-Persisch](https://www.langenscheidt.com/deutsch-daf/selbstlernen-woerterbuch/langenscheidt-handwoerterbuch-deutsch-persisch-hardcover)

## Screenshots

### Main screen
![Farhang 2 Screenshot - Main Screen](/assets/farhang.png)

### International Phonetic Alphabet (IPA) Keyboard
<img src="/assets/IPA-keyboard.png" width="400" height="365">

### SQLite Database Exporter (a.k.a. Mobile Database Exporter)
<img src="/assets/SQLite-exporter.png" width="400" height="300">

### Manual Headword Sorter
![Farhang 2 Screenshot - Manual Headword Sortter](/assets/Manual-Headword-Sorter.png)

### TeX Exporter (aka. PDF Builder)
<img src="/assets/tex-exporter.png" width="400" height="300">

### Generated TeX file
<img src="/assets/tex-input.png" width="385" height="572">

### TeX->PDF Output
<img src="/assets/tex-output.png" width="400" height="572">

## Contribution
Contribution is always welcome! To report bugs, simply open an issue and fill it with related information. To fix a bug, fork the repository, fix the bug, push to your own fork, make a pull request and done!

## License
[GPLv3](https://github.com/mostafa/farhang2/blob/master/LICENSE)
