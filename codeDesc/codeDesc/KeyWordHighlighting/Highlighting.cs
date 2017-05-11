using codeDesc.KeyWordHighlighting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Documents;
using System.Windows.Media;

namespace codeDesc
{
    public class Highlighting
    {
        private List<KeyWord> keywords = new List<KeyWord>();
        public Highlighting()
        {
            string[] gs;
            using (StreamReader sr = new StreamReader("../../KeyWordHighlighting/C#Keywords.txt"))
            {
                while (!sr.EndOfStream)
                {
                    gs = sr.ReadLine().Split(';');
                    keywords.Add(new KeyWord(gs[0], gs[1], gs[2]));
                }
            }
        }
        public FlowDocument createDocument(string text)
        {
            string zeile;
            var document = new FlowDocument();
            Paragraph p;
            char firstind;
            var converter = new System.Windows.Media.BrushConverter();
            string word = string.Empty;
            bool specialkeyword = false, IsKeyword;
            typeOfKeyword type = typeOfKeyword.normal;
            string color = "0";
            text = text.Replace(Environment.NewLine, "-/-");
            if (text.Contains("-/-"))
            {
                do
                {
                    p = new Paragraph();
                    zeile = text.Substring(0, text.IndexOf("-/-"));
                    while (zeile != "")
                    {
                        if (zeile.Length>2&&zeile.Substring(0, 2) == "//")
                        {
                            p.Inlines.Add(new Run(zeile)
                            {
                                Foreground = Brushes.Green
                            });
                            zeile = "";
                        }
                        else
                        {
                            IsKeyword = false;
                            firstind = getfirstindex(zeile);
                            if (firstind != 'n')
                            {
                                word = zeile.Substring(0, zeile.IndexOf(firstind));
                                if (specialkeyword)
                                {
                                    if (type == typeOfKeyword.allgreen)
                                    {
                                        p.Inlines.Add(new Run(zeile)
                                        {
                                            Foreground = (Brush)converter.ConvertFromString(color)
                                        });
                                        specialkeyword = false;
                                        type = typeOfKeyword.normal;
                                        break;
                                    }
                                    else
                                        p.Inlines.Add(new Run(word)
                                        {
                                            Foreground = (Brush)converter.ConvertFromString(color)
                                        });
                                    specialkeyword = false;
                                    type = typeOfKeyword.normal;
                                }
                                else
                                {
                                    foreach (var keyword in keywords)
                                    {
                                        if (keyword.Name == word.ToLower())
                                        {
                                            IsKeyword = true;
                                            if (keyword.Type == typeOfKeyword.green)
                                            {
                                                p.Inlines.Add(new Run(word)
                                                {
                                                    Foreground = (Brush)converter.ConvertFromString(keyword.Color)
                                                });
                                                continue;
                                            }
                                            else
                                            {
                                                p.Inlines.Add(new Run(word)
                                                {
                                                    Foreground = (Brush)converter.ConvertFromString(keyword.Color)
                                                });
                                            }
                                            if (keyword.Type != typeOfKeyword.normal)
                                            {
                                                specialkeyword = true;
                                                type = keyword.Type;
                                                if (type == typeOfKeyword.allgreen)
                                                    color = "#4ac9a7";
                                                else
                                                    color = "#b8c068";
                                            }

                                        }
                                    }
                                    if (!IsKeyword)
                                    {
                                        p.Inlines.Add(new Run(word));
                                    }
                                }
                                zeile = zeile.Remove(0, word.Length + 1);
                                p.Inlines.Add(new Run(firstind.ToString()));
                            }
                            else
                            {
                                if (specialkeyword)
                                {
                                    if (type == typeOfKeyword.allgreen)
                                    {
                                        p.Inlines.Add(new Run(zeile)
                                        {
                                            Foreground = (Brush)converter.ConvertFromString(color)
                                        });
                                        specialkeyword = false;
                                        type = typeOfKeyword.normal;
                                        break;
                                    }
                                    else
                                        p.Inlines.Add(new Run(word)
                                        {
                                            Foreground = (Brush)converter.ConvertFromString(color)
                                        });
                                    specialkeyword = false;
                                    type = typeOfKeyword.normal;
                                }
                                else
                                {
                                    p.Inlines.Add(new Run(zeile));
                                }
                                break;
                            }
                        }                      
                    }
                    document.Blocks.Add(p);
                    text = text.Remove(0, text.IndexOf("-/-") + 3);
                } while (text.IndexOf("-/-") != text.LastIndexOf("-/-"));

            }

            else
                document.Blocks.Add(new Paragraph(new Run(text)));           
            return document;
        }       
        public char getfirstindex(string zeile)
        {
            int IndSpace = zeile.IndexOf(' ');
            int Indpoint = zeile.IndexOf('.');
            int Indsemicolon = zeile.IndexOf(';');
            int Indclipo = zeile.IndexOf('(');
            int Indclipc = zeile.IndexOf(')');
            int Indlt = zeile.IndexOf('<');
            int Indgt = zeile.IndexOf('>');
            int Indcolon = zeile.IndexOf(':');
            int Indcomma = zeile.IndexOf(',');
            int[] numbers = new int[] { IndSpace, Indpoint, Indsemicolon, Indclipo, Indclipc, Indlt, Indgt, Indcolon, Indcomma };
            numbers = numbers.Where(val => val != -1).ToArray();
            if (numbers.Length != 0)
            {
                int min = numbers.Min();

                if (min == IndSpace)
                    return ' ';
                if (min == Indpoint)
                    return '.';
                if (min == Indsemicolon)
                    return ';';
                if (min == Indclipo)
                    return '(';
                if (min == Indclipc)
                    return ')';
                if (min == Indlt)
                    return '<';
                if (min == Indgt)
                    return '>';
                if (min == Indcolon)
                    return ':';
                if (min == Indcomma)
                    return ',';
            }
            return 'n';
        }
    }
}
