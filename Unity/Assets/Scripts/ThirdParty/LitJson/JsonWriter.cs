#region Header
//**
//* JsonWriter.cs
//*   Stream-like facility to output JSON text.
//*
//* The authors disclaim copyright to this source code. For more details, see
//* the COPYING file included with this distribution.
//**
#endregion


using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;


namespace LitJson
{
    internal enum Condition
    {
        InArray,
        InObject,
        NotAProperty,
        Property,
        Value
    }

    internal class WriterContext
    {
        public int  Count;
        public bool InArray;
        public bool InObject;
        public bool ExpectingValue;
        public int  Padding;
    }

    public class JsonWriter
    {
        #region Fields
        private static readonly NumberFormatInfo NumberFormat;

        private WriterContext        _context;
        private Stack<WriterContext> _ctxStack;
        private bool                 _hasReachedEnd;
        private char[]               _hexSeq;
        private int                  _indentation;
        private int                  _indentValue;
        private StringBuilder        inst_string_builder;
        private bool                 _prettyPrint;
        private bool                 _validate;
        private bool                 _lowerCaseProperties;
        private TextWriter           writer;
        #endregion


        #region Properties
        public int IndentValue {
            get { return _indentValue; }
            set {
                _indentation = (_indentation / _indentValue) * value;
                _indentValue = value;
            }
        }

        public bool PrettyPrint {
            get { return _prettyPrint; }
            set { _prettyPrint = value; }
        }

        public TextWriter TextWriter {
            get { return writer; }
        }

        public bool Validate {
            get { return _validate; }
            set { _validate = value; }
        }

        public bool LowerCaseProperties {
            get { return _lowerCaseProperties; }
            set { _lowerCaseProperties = value; }
        }
        #endregion


        #region Constructors
        static JsonWriter ()
        {
            NumberFormat = NumberFormatInfo.InvariantInfo;
        }

        public JsonWriter ()
        {
            inst_string_builder = new StringBuilder ();
            writer = new StringWriter (inst_string_builder);

            Init ();
        }

        public JsonWriter (StringBuilder sb) :
            this (new StringWriter (sb))
        {
        }

        public JsonWriter (TextWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException ("writer");

            this.writer = writer;

            Init ();
        }
        #endregion


        #region Private Methods
        private void DoValidation (Condition cond)
        {
            if (! _context.ExpectingValue)
                _context.Count++;

            if (! _validate)
                return;

            if (_hasReachedEnd)
                throw new JsonException (
                    "A complete JSON symbol has already been written");

            switch (cond) {
            case Condition.InArray:
                if (! _context.InArray)
                    throw new JsonException (
                        "Can't close an array here");
                break;

            case Condition.InObject:
                if (! _context.InObject || _context.ExpectingValue)
                    throw new JsonException (
                        "Can't close an object here");
                break;

            case Condition.NotAProperty:
                if (_context.InObject && ! _context.ExpectingValue)
                    throw new JsonException (
                        "Expected a property");
                break;

            case Condition.Property:
                if (! _context.InObject || _context.ExpectingValue)
                    throw new JsonException (
                        "Can't add a property here");
                break;

            case Condition.Value:
                if (! _context.InArray &&
                    (! _context.InObject || ! _context.ExpectingValue))
                    throw new JsonException (
                        "Can't add a value here");

                break;
            }
        }

        private void Init ()
        {
            _hasReachedEnd = false;
            _hexSeq = new char[4];
            _indentation = 0;
            _indentValue = 4;
            _prettyPrint = true;
            _validate = true;
            _lowerCaseProperties = false;

            _ctxStack = new Stack<WriterContext> ();
            _context = new WriterContext ();
            _ctxStack.Push (_context);
        }

        private static void IntToHex (int n, char[] hex)
        {
            int num;

            for (int i = 0; i < 4; i++) {
                num = n % 16;

                if (num < 10)
                    hex[3 - i] = (char) ('0' + num);
                else
                    hex[3 - i] = (char) ('A' + (num - 10));

                n >>= 4;
            }
        }

        private void Indent ()
        {
            if (_prettyPrint)
                _indentation += _indentValue;
        }


        private void Put (string str)
        {
            if (_prettyPrint && ! _context.ExpectingValue)
                for (int i = 0; i < _indentation; i++)
                    writer.Write (' ');

            writer.Write (str);
        }

        private void PutNewline ()
        {
            PutNewline (true);
        }

        private void PutNewline (bool addComma)
        {
            if (addComma && ! _context.ExpectingValue &&
                _context.Count > 1)
                writer.Write (',');

            if (_prettyPrint && ! _context.ExpectingValue)
                writer.Write (Environment.NewLine);
        }

        private void PutString (string str)
        {
            Put (String.Empty);

            writer.Write ('"');

            int n = str.Length;
            for (int i = 0; i < n; i++) {
                switch (str[i]) {
                case '\n':
                    writer.Write ("\\n");
                    continue;

                case '\r':
                    writer.Write ("\\r");
                    continue;

                case '\t':
                    writer.Write ("\\t");
                    continue;

                case '"':
                case '\\':
                    writer.Write ('\\');
                    writer.Write (str[i]);
                    continue;

                case '\f':
                    writer.Write ("\\f");
                    continue;

                case '\b':
                    writer.Write ("\\b");
                    continue;
                }

                if (str[i] >= 32 && str[i] <= 126) {
                    writer.Write (str[i]);
                    continue;
                }

                // Default, turn into a \uXXXX sequence
                IntToHex (str[i], _hexSeq);
                writer.Write ("\\u");
                writer.Write (_hexSeq);
            }

            writer.Write ('"');
        }

        private void Unindent ()
        {
            if (_prettyPrint)
                _indentation -= _indentValue;
        }
        #endregion


        public override string ToString ()
        {
            if (inst_string_builder == null)
                return String.Empty;

            return inst_string_builder.ToString ();
        }

        public void Reset ()
        {
            _hasReachedEnd = false;

            _ctxStack.Clear ();
            _context = new WriterContext ();
            _ctxStack.Push (_context);

            if (inst_string_builder != null)
                inst_string_builder.Remove (0, inst_string_builder.Length);
        }

        public void Write (bool boolean)
        {
            DoValidation (Condition.Value);
            PutNewline ();

            Put (boolean ? "true" : "false");

            _context.ExpectingValue = false;
        }

        public void Write (decimal number)
        {
            DoValidation (Condition.Value);
            PutNewline ();

            Put (Convert.ToString (number, NumberFormat));

            _context.ExpectingValue = false;
        }

        public void Write (double number)
        {
            DoValidation (Condition.Value);
            PutNewline ();

            string str = Convert.ToString (number, NumberFormat);
            Put (str);

            if (str.IndexOf ('.') == -1 &&
                str.IndexOf ('E') == -1)
                writer.Write (".0");

            _context.ExpectingValue = false;
        }

        public void Write(float number)
        {
            DoValidation(Condition.Value);
            PutNewline();

            string str = Convert.ToString(number, NumberFormat);
            Put(str);

            _context.ExpectingValue = false;
        }

        public void Write (int number)
        {
            DoValidation (Condition.Value);
            PutNewline ();

            Put (Convert.ToString (number, NumberFormat));

            _context.ExpectingValue = false;
        }

        public void Write (long number)
        {
            DoValidation (Condition.Value);
            PutNewline ();

            Put (Convert.ToString (number, NumberFormat));

            _context.ExpectingValue = false;
        }

        public void Write (string str)
        {
            DoValidation (Condition.Value);
            PutNewline ();

            if (str == null)
                Put ("null");
            else
                PutString (str);

            _context.ExpectingValue = false;
        }

        public void Write (ulong number)
        {
            DoValidation (Condition.Value);
            PutNewline ();

            Put (Convert.ToString (number, NumberFormat));

            _context.ExpectingValue = false;
        }

        public void WriteArrayEnd ()
        {
            DoValidation (Condition.InArray);
            PutNewline (false);

            _ctxStack.Pop ();
            if (_ctxStack.Count == 1)
                _hasReachedEnd = true;
            else {
                _context = _ctxStack.Peek ();
                _context.ExpectingValue = false;
            }

            Unindent ();
            Put ("]");
        }

        public void WriteArrayStart ()
        {
            DoValidation (Condition.NotAProperty);
            PutNewline ();

            Put ("[");

            _context = new WriterContext ();
            _context.InArray = true;
            _ctxStack.Push (_context);

            Indent ();
        }

        public void WriteObjectEnd ()
        {
            DoValidation (Condition.InObject);
            PutNewline (false);

            _ctxStack.Pop ();
            if (_ctxStack.Count == 1)
                _hasReachedEnd = true;
            else {
                _context = _ctxStack.Peek ();
                _context.ExpectingValue = false;
            }

            Unindent ();
            Put ("}");
        }

        public void WriteObjectStart ()
        {
            DoValidation (Condition.NotAProperty);
            PutNewline ();

            Put ("{");

            _context = new WriterContext ();
            _context.InObject = true;
            _ctxStack.Push (_context);

            Indent ();
        }

        public void WritePropertyName (string property_name)
        {
            DoValidation (Condition.Property);
            PutNewline ();
            string propertyName = (property_name == null || !_lowerCaseProperties)
                ? property_name
                : property_name.ToLowerInvariant();

            PutString (propertyName);

            if (_prettyPrint) {
                if (propertyName.Length > _context.Padding)
                    _context.Padding = propertyName.Length;

                for (int i = _context.Padding - propertyName.Length;
                     i >= 0; i--)
                    writer.Write (' ');

                writer.Write (": ");
            } else
                writer.Write (':');

            _context.ExpectingValue = true;
        }
    }
}
