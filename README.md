# Farhang Dictionary Production System (DPS)

The purpose of this project is to typeset bilingual dictionaries. After typesetting, it provides options to export them to a specially crafted TeX file, which uses `farhang.cls` LaTeX class file for the layout of the TeX files. It also has a SQLite export feature to be used for writing dictionary apps.

It is written in C# and uses MongoDB as database for storing dictionary entries as separate documents. It has been developed about 6 years ago and is very old. I used Mercurial (Hg) to manage the project, but converted the whole project from Mercurial to Git, just before making it free using hg-git plugin, mercurial package, python and bitbucket.

In order to run the project, you should install MongoDB and compile and run the project from source. I will try to provide a binary version for your convenience if I can find a suitable time.

This project is used to typeset a bilingual German-Persian dictionary of over 2600 pages which is published by Zabankadeh and Langenscheidt AG.

[Großwörterbuch Deutsch – Persisch](https://www.langenscheidt.com/deutsch-daf/schule-studium-woerterbuch/langenscheidt-grosswoerterbuch-deutsch-als-fremdsprache-hardcover)

## Screenshot
![Farhang 2 Screenshot](/assets/farhang.png)

## TeX Output
 <img src="/assets/tex-output.png" width="400" height="572">

## Contribution
Contribution is always welcome! To report bugs, simply open an issue and fill it with related information. To fix a bug, fork the repository, fix the bug, push to your own fork, make a pull request and done!

## License
[GPLv3](https://github.com/mostafa/farhang2/blob/master/LICENSE)
