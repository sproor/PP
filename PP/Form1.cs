using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP
{
    public partial class Form1 : Form
    {

        public static string magicNumber(string src, string number, string nameConst, string type)
            {
                return src;
            }
        

        public static string RemoveMethod( string InUseCode, string InFuncName, string InFuncCode )
        {
            int             IndexReturn         = InFuncCode.IndexOf("return ");
            if ( IndexReturn >= 0 )
            {
                InFuncCode                      = InFuncCode.Remove( IndexReturn, 7 );       // 6 is size of word 'return '
                int         IndexSemicolon      = InFuncCode.LastIndexOf(';');
                if ( IndexSemicolon >= 0 )
                {
                    InFuncCode = InFuncCode.Remove( IndexSemicolon, 1 );
                }
            }

            string          FunctionSemantic    = InFuncName + "();";
            if ( InUseCode.Contains( FunctionSemantic ) )
            {
                string      CodeFormat = "";
                int         Index = InUseCode.IndexOf(FunctionSemantic);
                if ( Index >= 0 )
                {
                    string[]    Parts = InUseCode.Split( new[] { FunctionSemantic }, StringSplitOptions.RemoveEmptyEntries );
                   if ( Parts.Length > 0 && Parts[0].StartsWith(" "))
                    {
                        Parts[0] = Parts[0].Remove(0, 1);
                    }
                    
                    if ( Parts.Length > 0 && Index > InUseCode.IndexOf( Parts[0] ) )
                    {
                        CodeFormat = Parts[ 0 ] + "{0};";
                    }
                    else if ( Parts.Length > 0 )
                    {
                        CodeFormat = "{0}; " + Parts[0];
                    }
                    else
                    {
                        CodeFormat = "{0};";
                    }

                    for ( int Idx = 1; Idx < Parts.Length; ++Idx )
                    {
                        CodeFormat += Parts[ Idx ];
                    }

                }

                return string.Format( CodeFormat, InFuncCode );
            }
            else
            {
                return InUseCode;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
