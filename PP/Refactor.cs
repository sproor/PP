using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP
{
    class Refactor
    {
        public string renameVariable(string row, string newName, string oldName)
        {
            string text = "";
            string[] variables = row.Split(new char[] { ' ' });
            for (int i = 0; i < variables.Length; i++)
            {
                if (variables[i].CompareTo(oldName) == 0) variables[i] = newName;
                if (i == variables.Length - 1)
                    text += variables[i];
                else
                    text += variables[i] + " ";
            }
            return text;
        }
        public string renameWithQuote(string row, string newName, string oldName)
        {
            string text = "";

            int indexQuote = row.IndexOf('\"');

            if (indexQuote != 1)
            {
                string[] quotes = row.Split(new char[] { '\"' });
                for (int i = 0; i < quotes.Length; i++)
                {
                    if (i % 2 == 0) text += renameVariable(quotes[i], newName, oldName);
                    else text += "\"" + quotes[i] + "\"";
                }
            }
            return text;
        }

        public string renameWithSummary(string row, string newName, string oldName)
        {
            string text = "";

            int indexSummary = row.IndexOf("//");

            if (indexSummary != -1)
            {
                string[] summury = row.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (row.IndexOf('\"') != 1)
                    text += renameWithQuote(summury[0], newName, oldName);
                else
                    text += renameVariable(summury[0], newName, oldName);
                text += "//" + summury[1];
            }
            else
            {
                text += renameVariable(row, newName, oldName);
            }
            return text;
        }
        public string rename(string text, string newName, string oldName)
        {
            string copyText = text;
            if (string.Compare(newName, oldName) == 0)
                return text;
            else
            {
                string[] rows = text.Split(new char[] { '\n' });
                text = "";
                foreach (string row in rows)
                {
                    int indexSummary = row.IndexOf("//");
                    int indexQuote = row.IndexOf('\"');
                    if (indexQuote != -1)
                    {
                        text += renameWithQuote(row, newName, oldName) + "\n";
                    }
                    else if (indexSummary != -1)
                    {
                        text += renameWithSummary(row, newName, oldName) + "\n";
                    }
                    else if (row != "") text += renameVariable(row, newName, oldName) + "\n";
                }
            }
            if (text == "") text = renameVariable(copyText, newName, oldName);

            return text;
        }

        public string format(string text)
        {

            return text;
        }
    }
}
