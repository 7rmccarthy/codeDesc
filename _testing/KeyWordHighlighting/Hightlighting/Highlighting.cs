using System.Drawing;
using SN = ScintillaNET;

namespace Highlighting
{
    /*
        ToDo:   Overload Initialise method to accept both custom and detected languages
                Let user customise colour schemes
                Customise autocompletion to accept custom variable names loaded into the form
        Also:   maybe try to introduce code folding using #region
    */
    
    //  Static class to be used in codeDesc for text visualisation
    public static class Highlighting
    {
        //  Scintilla object
        private static SN.Scintilla languageEditor;

        //  Property
        public static SN.Scintilla LanguageEditor
        {
            get { if (languageEditor != null) return languageEditor;
                    else return new SN.Scintilla(); }
            set { languageEditor = value; }
        }

        //  Initialisation method
        public static void Initialise()
        {
            languageEditor = new SN.Scintilla();

            //  Add event handler
            languageEditor.CharAdded += charAdded;

            LoadConfiguration();
            AutomaticCodeFolding();
        }

        //  Lets the user add text
        public static void AddText(string source)
        {
            languageEditor.AddText(source);
        }

        //  Loads a (momentarily) custom c# configuration
        private static void LoadConfiguration()
        {
            //  Restore default values
            languageEditor.StyleResetDefault();
            languageEditor.Styles[SN.Style.Default].Font = "Consolas";
            languageEditor.Styles[SN.Style.Default].Size = 10;
            languageEditor.StyleClearAll();

            //  Configure the style settings (Cpp standard language used for values we do not define)
            languageEditor.Margins[0].Width = 40;
            languageEditor.Styles[SN.Style.Cpp.Default].ForeColor = Color.Silver;

            //  Comments
            languageEditor.Styles[SN.Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0);            //    Green
            languageEditor.Styles[SN.Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0);        //    Green
            languageEditor.Styles[SN.Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); //    Gray

            //  Numbers
            languageEditor.Styles[SN.Style.Cpp.Number].ForeColor = Color.Olive;

            //  Keywords
            languageEditor.Styles[SN.Style.Cpp.Word].ForeColor = Color.Blue;
            languageEditor.Styles[SN.Style.Cpp.Word2].ForeColor = Color.Turquoise;

            //  Strings and characters
            languageEditor.Styles[SN.Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21);           //    Red
            languageEditor.Styles[SN.Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21);        //    Red
            languageEditor.Styles[SN.Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21);         //    Red
            languageEditor.Styles[SN.Style.Cpp.StringEol].BackColor = Color.Pink;

            //  Misc
            languageEditor.Styles[SN.Style.Cpp.Operator].ForeColor = Color.Purple;
            languageEditor.Styles[SN.Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
            languageEditor.Styles[SN.Style.Cpp.GlobalClass].ForeColor = Color.LightGreen;

            //  Set the standard language to c++
            languageEditor.Lexer = SN.Lexer.Cpp;

            //  Set keywords
            languageEditor.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");
            languageEditor.SetKeywords(1, "Console Stream StreamReader OpenFileDialog"); // Own highlighted keywords
        }

        //  Automatically folds the code using braces
        private static void AutomaticCodeFolding()
        {
            //  Instruct the lexer to calculate folding
            languageEditor.SetProperty("fold", "1");
            languageEditor.SetProperty("fold.compact", "1");

            //  Configure a margin to display folding symbols
            languageEditor.Margins[2].Type = SN.MarginType.Symbol;
            languageEditor.Margins[2].Mask = SN.Marker.MaskFolders;
            languageEditor.Margins[2].Sensitive = true;
            languageEditor.Margins[2].Width = 20;

            //  Set colours for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                languageEditor.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                languageEditor.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            //  Configure folding markers with respective symbols
            languageEditor.Markers[SN.Marker.Folder].Symbol = SN.MarkerSymbol.BoxPlus;
            languageEditor.Markers[SN.Marker.FolderOpen].Symbol = SN.MarkerSymbol.BoxMinus;
            languageEditor.Markers[SN.Marker.FolderEnd].Symbol = SN.MarkerSymbol.BoxPlusConnected;
            languageEditor.Markers[SN.Marker.FolderMidTail].Symbol = SN.MarkerSymbol.TCorner;
            languageEditor.Markers[SN.Marker.FolderOpenMid].Symbol = SN.MarkerSymbol.BoxMinusConnected;
            languageEditor.Markers[SN.Marker.FolderSub].Symbol = SN.MarkerSymbol.VLine;
            languageEditor.Markers[SN.Marker.FolderTail].Symbol = SN.MarkerSymbol.LCorner;

            //  Enable automatic folding
            languageEditor.AutomaticFold = (SN.AutomaticFold.Show | SN.AutomaticFold.Click | SN.AutomaticFold.Change);
        }

        //  Simple word autocompletion method
        private static void charAdded(object sender, SN.CharAddedEventArgs e)
        {
            //  Find the word start
            int currentPos = languageEditor.CurrentPosition;
            int wordStartPos = languageEditor.WordStartPosition(currentPos, true);

            //  Display the autocompletion list
            int lenEntered = currentPos - wordStartPos;
            if (lenEntered > 0)
            {
                if (!languageEditor.AutoCActive)
                    languageEditor.AutoCShow(lenEntered, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while void Console System");
            }
        }
    }
}