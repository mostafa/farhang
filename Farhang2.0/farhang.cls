% it needs LaTeX2e to run
\NeedsTeXFormat{LaTeX2e}
% and it provides a 'farhang' class written in 2009/08/28 for Farhang DPS
% latest update: 2010/06/23 (The would be no change log until the stable version is out)
\ProvidesPackage{farhang}[2009/08/28 Farhang Dictionary Production System LaTeX class]

% load the code of the book (document) class
\LoadClass[a4paper,openright,final]{book}

% required packages are called here
\RequirePackage[papersize={170mm,240mm}]{zwpagelayout}
\RequirePackage[ngerman]{babel}
\RequirePackage[OT1]{fontenc}
\RequirePackage{xunicode}
\RequirePackage{xltxtra}
\RequirePackage{tipa}
\RequirePackage{fontspec}
\RequirePackage{phonetic}
\RequirePackage{latexsym}
\RequirePackage{fancyhdr}
%\RequirePackage{tikz}
\RequirePackage{multicol}
\RequirePackage{color}
%\RequirePackage{pstricks}
\RequirePackage{ifthen}
\RequirePackage{manfnt}
\RequirePackage{textcomp}
%\RequirePackage{framed}
\RequirePackage{float}
\RequirePackage{dblfloatfix}
%\RequirePackage{fix2col}
%\RequirePackage{hyperref}
\RequirePackage{balance}
\RequirePackage[absolute]{textpos}
\RequirePackage{changepage}
\RequirePackage{everypage}
%\RequirePackage{afterpage}
\RequirePackage{calc}
\RequirePackage{printlen}
%\RequirePackage{alphalph}
%\RequirePackage[pagecontinue=true,alphMult=ab,AlphMulti=AB,fnsymbolmult=true,romanMult=true,RomanMulti=true]{pagesLTS}
%\RequirePackage[showframe]{geometry}
%\RequirePackage{graphicx}
\RequirePackage{xstring}
\RequirePackage{xepersian}

% font definitions
\newfontfamily\ArialNormal[Scale=0.9]{Arial}
\newfontfamily\ArialBig[Scale=1]{Arial}
\newfontfamily\TimesNormal[Scale=0.9]{Liberation Serif}
\newfontfamily\DejaVuSansExtraLight[Scale=0.9]{Ubuntu Light}
\newfontfamily\DejaVuSansNormal[Scale=0.8]{DejaVu Sans}

% color definitions
\definecolor{cyan}{cmyk}{1.0,0.0,0.0,0.0}
\definecolor{black}{cmyk}{0.0,0.0,0.0,1.0}
\definecolor{white}{cmyk}{0,0,0,0}

%------------------------------------------------------------------------------------------------------
% color definitions for thumbindices
\definecolor{ThumbIndexBackgroundCyan}{cmyk}{0.4,0.0,0,0.0}

% font definition for thumbindices
\newfontfamily\ArialThumbIndex[Scale=1.55]{Arial}

% these are used to change the position and length of the thumbindices
% initial values are just for character "A"
\newcommand\thumbindexwidth{12mm}
%\newcommand\thumbindexheight{0.14}
\newcommand\thumbindexoddx{156.5mm}
\newcommand\thumbindexevenx{1mm}
\newcommand\thumbindexy{0mm}

\TPMargin*{2.3mm}
\textblockorigin{0mm}{0mm}
\textblockcolour{ThumbIndexBackgroundCyan}

% prints thumb-index according to the alphabet number (this is internal to farhang class)
% usage: \thumbindex{upper-case letter}
% example: \thumbindex{A}
\DeclareRobustCommand{\thumbindex}[1]
{
	\easypagecheck%
	\checkoddpage%
	\ifoddpage%
		\ifthenelse{\equal{#1}{A}}
		{
			\begin{textblock*}{\thumbindexwidth}(\thumbindexoddx,\thumbindexy)
			\vspace{5.5mm}
			\raggedright\textcolor{white}{\ArialThumbIndex{\textbf{#1}}}
			\end{textblock*}
		}
		{
			\ifthenelse{\equal{#1}{Z}}
			{
				\begin{textblock*}{\thumbindexwidth} (\thumbindexoddx,\thumbindexy)
				\raggedright\textcolor{white}{\ArialThumbIndex{\textbf{#1}}}
				\vspace{5.5mm}
				\end{textblock*}
			}
			{
				\begin{textblock*}{\thumbindexwidth} (\thumbindexoddx,\thumbindexy)
				\raggedright\textcolor{white}{\ArialThumbIndex{\textbf{#1}}}
				\end{textblock*}
			}
		}
	\else%
		\ifthenelse{\equal{#1}{A}}
		{
			\begin{textblock*}{\thumbindexwidth}(\thumbindexevenx,\thumbindexy)
			\vspace{5.5mm}
			\raggedleft\textcolor{white}{\ArialThumbIndex{\textbf{#1}}}
			\end{textblock*}
		}
		{
			\ifthenelse{\equal{#1}{Z}}
			{
				\begin{textblock*}{\thumbindexwidth} (\thumbindexevenx,\thumbindexy)
				\raggedleft\textcolor{white}{\ArialThumbIndex{\textbf{#1}}}
				\vspace{5.5mm}
				\end{textblock*}
			}
			{
				\begin{textblock*}{\thumbindexwidth} (\thumbindexevenx,\thumbindexy)
				\raggedleft\textcolor{white}{\ArialThumbIndex{\textbf{#1}}}
				\end{textblock*}
			}
		}
	\fi%
}

% this hook will call the \thumbindex before each page is going to output (this is used in the tex file before \begin{document})
% usage: \thumbindexcharacter{upper-case letter}
% example: \thumbindexcharacter{A}
\DeclareRobustCommand{\thumbindexcharacter}[1]
{
	\AddEverypageHook{\thumbindex{#1}}
	\ifthenelse{\equal{#1}{A}}{\renewcommand{\thumbindexy}{0mm}}{}
	\ifthenelse{\equal{#1}{B}}{\renewcommand{\thumbindexy}{14.8mm}}{}
	\ifthenelse{\equal{#1}{C}}{\renewcommand{\thumbindexy}{23.8mm}}{}
	\ifthenelse{\equal{#1}{D}}{\renewcommand{\thumbindexy}{32.8mm}}{}
	\ifthenelse{\equal{#1}{E}}{\renewcommand{\thumbindexy}{41.8mm}}{}
	\ifthenelse{\equal{#1}{F}}{\renewcommand{\thumbindexy}{50.8mm}}{}
	\ifthenelse{\equal{#1}{G}}{\renewcommand{\thumbindexy}{59.8mm}}{}
	\ifthenelse{\equal{#1}{H}}{\renewcommand{\thumbindexy}{68.8mm}}{}
	\ifthenelse{\equal{#1}{I}}{\renewcommand{\thumbindexy}{77.8mm}}{}
	\ifthenelse{\equal{#1}{J}}{\renewcommand{\thumbindexy}{86.8mm}}{}
	\ifthenelse{\equal{#1}{K}}{\renewcommand{\thumbindexy}{95.8mm}}{}
	\ifthenelse{\equal{#1}{L}}{\renewcommand{\thumbindexy}{104.8mm}}{}
	\ifthenelse{\equal{#1}{M}}{\renewcommand{\thumbindexy}{113.8mm}}{}
	\ifthenelse{\equal{#1}{N}}{\renewcommand{\thumbindexy}{122.8mm}}{}
	\ifthenelse{\equal{#1}{O}}{\renewcommand{\thumbindexy}{131.8mm}}{}
	\ifthenelse{\equal{#1}{P}}{\renewcommand{\thumbindexy}{140.8mm}}{}
	\ifthenelse{\equal{#1}{Q}}{\renewcommand{\thumbindexy}{149.8mm}}{}
	\ifthenelse{\equal{#1}{R}}{\renewcommand{\thumbindexy}{158.8mm}}{}
	\ifthenelse{\equal{#1}{S}}{\renewcommand{\thumbindexy}{167.8mm}}{}
	\ifthenelse{\equal{#1}{T}}{\renewcommand{\thumbindexy}{176.8mm}}{}
	\ifthenelse{\equal{#1}{U}}{\renewcommand{\thumbindexy}{185.8mm}}{}
	\ifthenelse{\equal{#1}{V}}{\renewcommand{\thumbindexy}{194.8mm}}{}
	\ifthenelse{\equal{#1}{W}}{\renewcommand{\thumbindexy}{203.8mm}}{}
	\ifthenelse{\equal{#1}{X}}{\renewcommand{\thumbindexy}{212.8mm}}{}
	\ifthenelse{\equal{#1}{Y}}{\renewcommand{\thumbindexy}{221.8mm}}{}
	\ifthenelse{\equal{#1}{Z}}{\renewcommand{\thumbindexy}{230.8mm}}{}
}
%------------------------------------------------------------------------------------------------------
% variable to detect the remaining space at the end of the paragraph

\newlength{\HeadwordLineWidth}%
\newlength{\remainingHeadwordLineWidth}%
\newlength{\TranslationLineWidth}%
\newlength{\SourceTextLineWidth}%
\newlength{\remainingEntryColumnWidth}%
\newlength{\remainingEntryAndTranslationColumnWidth}%
\newlength{\totalEntryAndSourceTextWidth}%
\newlength{\remainingHeadwordAndTranslationWidth}%
\newlength{\totalTranslationAndRemainingWidth}%
\newlength{\DoubleColumnWidth}%
\newlength{\TripleColumnWidth}%

\setlength{\DoubleColumnWidth}{2\columnwidth}
\setlength{\TripleColumnWidth}{3\columnwidth}

\newcommand{\getHeadwordLineWidth}[1]{%
\settowidth{\HeadwordLineWidth}{#1}%
\ifthenelse{\lengthtest{\columnwidth > \HeadwordLineWidth}}{\setlength{\remainingHeadwordLineWidth}{\columnwidth - \HeadwordLineWidth}}{\setlength{\remainingHeadwordLineWidth}{\HeadwordLineWidth - \columnwidth}}}%

\newcommand{\getEntryLineWidth}[2]{%
\settowidth{\SourceTextLineWidth}{#1}%
\settowidth{\TranslationLineWidth}{#2}%
\setlength{\totalEntryAndSourceTextWidth}{\SourceTextLineWidth+\TranslationLineWidth}%
\setlength{\remainingHeadwordAndTranslationWidth}{\HeadwordLineWidth - \TranslationLineWidth}%
\ifthenelse{\lengthtest{\columnwidth > \SourceTextLineWidth}}{\setlength{\remainingEntryColumnWidth}{\columnwidth - \SourceTextLineWidth}}{\ifthenelse{\lengthtest{\DoubleColumnWidth > \SourceTextLineWidth}}{\setlength{\remainingEntryColumnWidth}{\DoubleColumnWidth - \SourceTextLineWidth}}{\SourceTextLineWidth - \DoubleColumnWidth}}
%%%%%%%%%%%%%%%%%%%%%%%
%{\setlength{\remainingEntryColumnWidth}{\SourceTextLineWidth - \columnwidth}}%
\ifthenelse{\lengthtest{\columnwidth > \totalEntryAndSourceTextWidth}}{\setlength{\remainingEntryAndTranslationColumnWidth}{\columnwidth - \totalEntryAndSourceTextWidth}}{\ifthenelse{\lengthtest{\DoubleColumnWidth > \totalEntryAndSourceTextWidth}}{\setlength{\remainingEntryAndTranslationColumnWidth}{\DoubleColumnWidth - \totalEntryAndSourceTextWidth}}{\ifthenelse{\lengthtest{\TripleColumnWidth > \totalEntryAndSourceTextWidth}}{\setlength{\remainingEntryAndTranslationColumnWidth}{\totalEntryAndSourceTextWidth - \DoubleColumnWidth}}{\setlength{\remainingEntryAndTranslationColumnWidth}{\totalEntryAndSourceTextWidth - \TripleColumnWidth}}}}
\setlength{\totalEntryAndSourceTextWidth}{\SourceTextLineWidth+\TranslationLineWidth}
\setlength{\totalTranslationAndRemainingWidth}{\remainingEntryAndTranslationColumnWidth - \TranslationLineWidth}}%

%\totalEntryAndSourceTextWidth - \DoubleColumnWidth


% new! magic space ;)
% usage & example: \magicspace
%\DeclareRobustCommand{\magicspace}{\hfill\hfill\hfill\newline}%
\DeclareRobustCommand{\magicspace}{\null\newline}%


% alphahead defines the alphabetical heading of each part of the dictionary (alphabet) - [A, a], [B, b], ...
% usage: \alphahead{upper-case letter}
% example: \alphahead{A}
%\DeclareRobustCommand{\alphahead}[1]{\vspace*{1.4in}\makebox[135mm]{{\textcolor{cyan}{\ArialBig{\textbf{\Huge{#1}}}}}}\newline}


% The first one that complies with 2003 version of Langenscheidt Wörterbuch
\DeclareRobustCommand{\alphahead}[1]{\vspace*{1.4in}\makebox[135mm]{\textcolor{cyan}{\ArialBig{\textbf{\Huge{#1}, \MakeLowercase{#1}}}}}}%


% headword (lemma, pronunciation, description, translation, derived, etymology, frequency)
% frequency is not used [only in English language]
% styles are hard-coded for the moment being... [fix it!]
% derived and etymology should be defined (not used now) [only in English or monolingual languages]
% usage: \headword{lemma}{pronunciation}{description}{headerlemma-notag}
% example: \headword{Aa}{[a]}{nur Sg.}{Aa}
\DeclareRobustCommand{\headword}[4]{\getHeadwordLineWidth{\noindent\hspace*{-2.5mm}\lr{\textcolor{cyan}{\ArialNormal{\textbf{#1}}} \textcolor{black}{\TimesNormal{#2 \textit{#3}}}}}\noindent\hspace*{-2.5mm}\lr{\textcolor{cyan}{\ArialNormal{\textbf{#1}}} \textcolor{black}{\TimesNormal{#2 \textit{#3}}}}\header{#4}}%
%\hfill\null\newline{}
%\measureremainder{\whatsleft}


% fill up space in the first column and break to the next one in the same page
\DeclareRobustCommand{\breakcolumn}{\vfill\columnbreak}


% uses words in \headword{}{}{}{word} to mark left and right side of header (lemmanotag)
\DeclareRobustCommand{\header}[1]{\markboth{\lr{\textcolor{cyan}{\DejaVuSansExtraLight{\textbf{{#1}}}}}}{\lr{\textcolor{cyan}{\DejaVuSansExtraLight{\textbf{{\hspace*{-2.5mm}#1}}}}}}\fancyhead[LE]{\rightmark}\fancyhead[RO]{\leftmark}}

% here lies ;) the entry
% usage: \entry{number}{entry}{translation}
% example: \entry{1.}{to welcome s.o.}{jdn. begrüssen}
\DeclareRobustCommand{\entry}[3]{\getEntryLineWidth{\noindent\textcolor{black}{\textbf{\TimesNormal{#1}} \textit{\TimesNormal{#2\hfill}}}}{\rl{\textbf{#3\hfill}}}\ifthenelse{\equal{#1}{1.}}{\newline}{}\ifthenelse{\equal{#1}{}}{\ifthenelse{\lengthtest{\remainingHeadwordLineWidth < \TranslationLineWidth}}{\newline}{\hspace*{-1mm}}}{}\noindent\textcolor{black}{\textbf{\TimesNormal{#1}}} \textit{\TimesNormal{#2\hfill}}\ifthenelse{\equal{#1}{}}{}{\ifthenelse{\lengthtest{\remainingEntryColumnWidth < \TranslationLineWidth}}{\ifthenelse{\TranslationLineWidth > 0}{\newline}{}}{\hspace*{-1mm}}}\rl{\textbf{#3\hfill}}\newline}%

%\printlength{\remainingHeadwordLineWidth}\printlength{\remainingHeadwordAndTranslationWidth}
%\printlength{\HeadwordLineWidth}  \printlength{\remainingHeadwordLineWidth}
%\ifthenelse{\equal{#1}{1.}}{\newline}{}\ifthenelse{\equal{#1}{}}{\linebreak}{}

% here lies ;) the subentry
% usage: \subentry{subentry}{translation}
% example: \subentry{Hallo}{Hello}
%%% for myself: put \vspace{1mm} before \newline to have a clearer text/column [43 lines instead of 48 lines per column per page]
\DeclareRobustCommand{\subentry}[2]{\getEntryLineWidth{\noindent\textcolor{black}{\lr{\TimesNormal{#1\hfill}}}}{\rl{\Roya{#2\hfill}}}\noindent\textcolor{black}{\lr{\TimesNormal{#1\hfill}}\ifthenelse{\equal{#1}{}}{}{\ifthenelse{\lengthtest{\remainingEntryColumnWidth < \TranslationLineWidth}}{\newline}{\hspace*{2mm}}}\rl{\Roya{#2\hfill}}}\newline}%

%\hspace*{-5mm}

% here lies ;) the refcomb
% usage: \refcomb{reference/combination}
% example: \refcomb{|| hierzu: Absicht...} -> a reference without translation equivalents
% example: \refcomb{nachdenken über, denken nach...} -> a set of combinations without translation equivalents


% current version
%\DeclareRobustCommand{\refcomb}[1]{\TimesNormal{\textit{\textcolor{black}{#1}}}\newline}%

%\newlength{\imagewidth}
%\newlength{\imageheight}

% here lies ;) the picture
%%%%%%%%%%%%FIXME: add title/translation to the generated indices
% usage: \picture{filename}{title}{translation}{1|2}
% example: \picture{balloon.eps}{title}{translation}{1}
% %\includegraphics[width=0.5\textwidth]{#2}
\DeclareRobustCommand{\picture}[4]{
%\settowidth{\imagewidth}{\includegraphics[keepaspectratio]{#1}}% determine image width
%\settoheight{\imageheight}{\includegraphics[keepaspectratio]{#1}}% determine image height
%\printlength{\imagewidth}
\ifthenelse{\equal{#4}{1}}% signle-column image
{
\begin{figure}[H]
\vspace{-5mm}
\IfEndWith{#1}{.eps}{
\centering
\includegraphics[width=4.5cm,keepaspectratio]{#1}
}{
\includegraphics[width=\columnwidth,keepaspectratio]{#1}
}
\vspace{-5mm}
\end{figure}
}
{
\end{multicols*}
%\vspace{-5mm}
\begin{figure}[!th]
\noindent
\centering
\includegraphics[width=\linewidth,keepaspectratio]{#1}
\end{figure}
\vspace{-3mm}
\begin{multicols*}{2}
}
}