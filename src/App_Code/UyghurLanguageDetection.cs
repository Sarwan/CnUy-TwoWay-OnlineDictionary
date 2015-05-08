using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for UyghurLanguageDetection
/// </summary>
public class UyghurLanguageDetection
{
 
    string rtlChars	;
    string controlChars;
	public UyghurLanguageDetection()
	{
    //Arabic - Range:
    //0600–06FF
     rtlChars		= "\u0600-\u06FF";

    //Arabic Supplement - Range:
    //0750–077F
    rtlChars		+= "\u0750-\u077F";

    //Arabic Presentation Forms-A - Range:
    //FB50–FDFF
    rtlChars		+= "\uFB50-\uFDFF";

    //Arabic Presentation Forms-B - Range:
    //FE70–FEFF
    rtlChars		+= "\uFE70-\uFEFF";

    //ASCII Punctuation - Range:
    //0000-0020
    controlChars = "\u0000-\u0020";

    //General Punctuation - Range
    //2000-200D
    controlChars 	+= "\u2000-\u200D";

//Start Regular Expression magic
//var reRTL     = new RegExp('^[' + controlChars + ']*[' + rtlChars + ']');
//var reControl = new RegExp('^[' + controlChars + ']*$');
        

	}

    public bool isUyghur(string str)
    {
    Regex rx=new Regex("^[" + controlChars + "]*[" + rtlChars + "]");
       if( rx.IsMatch(str))
       {
        return true;
       }
       else
       {
        return false;
       }
           
    }
}