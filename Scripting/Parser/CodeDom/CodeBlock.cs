﻿using System.CodeDom;

namespace IronAHK.Scripting
{
    class CodeBlock
    {
        public enum BlockType { None, Expect, Within };

        public enum BlockKind { Dummy, IfElse, Function, Label, Loop };

        CodeLine line;
        string method;
        CodeStatementCollection statements;
        BlockType type;
        BlockKind kind;
        CodeBlock parent;
        int level;
        string name;
        string endLabel, exitLabel;

        public CodeBlock(CodeLine line, string method, CodeStatementCollection statements, BlockKind kind, CodeBlock parent)
            : this(line, method, statements, kind, parent, null, null) { }

        public CodeBlock(CodeLine line, string method, CodeStatementCollection statements, BlockKind kind, CodeBlock parent, string endLabel, string exitLabel)
        {   
            this.line = line;
            this.method = method;
            this.statements = statements;
            this.type = BlockType.Expect;
            this.kind = kind;
            this.parent = parent;
            this.level = int.MaxValue;
            this.endLabel = endLabel;
            this.exitLabel = exitLabel;
        }

        public CodeLine Line
        {
            get { return line; }
        }

        public string Method
        {
            get { return method; }
        }

        public CodeStatementCollection Statements
        {
            get { return statements; }
        }

        public BlockType Type
        {
            get { return type; }
            set { type = value; }
        }

        public BlockKind Kind
        {
            get { return kind; }
        }

        public CodeBlock Parent
        {
            get { return parent; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string EndLabel
        {
            get { return endLabel; }
        }

        public string ExitLabel
        {
            get { return exitLabel; }
        }

        public bool IsSingle
        {
            get { return level != int.MaxValue; }
        }
    }
}
